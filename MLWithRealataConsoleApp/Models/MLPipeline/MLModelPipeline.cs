using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Trainers;
using Microsoft.ML.Data;
using MLWithRealataConsoleApp.Models.Exceptions;

namespace MLWithRealataConsoleApp.Models.MLPipeline
{
    public class MLModelPipeline
    {
        private const int IterationNumber = 3500;   
        private const float TestFraction = 0.01f;
        private MLContext MLContext { get; set; }
        private IDataView TestDataView { get; set; }
        private IDataView TrainDataView { get; set; }
        private IDataView DataView { get; set; }
        public double RootMeanSquareError { get; set; }
        public double RSquared { get; set; }
        private ITransformer Model { get; set; }
        public MLModelPipeline()
        {
            MLContext = new MLContext();
        }

        public void LoadModel()
        {
            DataViewSchema modelSchema;
            Model = MLContext.Model.Load("RecommenderModel.zip", out modelSchema);
        }

        public void CreateAndTrainModel()
        {
            LoadData();
            BuildModel();
            EvaluateModel();
        }
        private void LoadData()
        {
            string dataPath = Path.Combine("C:\\Users\\dod30\\source\\repos\\MLWithRealDataConsoleAppAugmented\\MLWithRealataConsoleApp\\Data", "PairToLift.txt");
            DataView = MLContext.Data.LoadFromTextFile<ProductPair>(dataPath, hasHeader: true, separatorChar: '\t');
            DataOperationsCatalog.TrainTestData splitView = MLContext.Data.TrainTestSplit(DataView, TestFraction);

            TestDataView = splitView.TestSet;
            TrainDataView = splitView.TrainSet;
        }

        private void BuildModel()
        {
            IEstimator<ITransformer> estimator = MLContext.Transforms.Conversion
                .MapValueToKey(outputColumnName: "FirstProductIdEncoded", inputColumnName: "FirstProductId")
                .Append(MLContext.Transforms.Conversion.MapValueToKey(outputColumnName: "SecondProductIdEncoded", inputColumnName: "SecondProductId"));

            MatrixFactorizationTrainer.Options options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "FirstProductIdEncoded",
                MatrixRowIndexColumnName = "SecondProductIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = IterationNumber
            };

            var trainerEstimator = estimator.Append(MLContext.Recommendation().Trainers.MatrixFactorization(options));

            Model = trainerEstimator.Fit(TrainDataView);
        }

        private void EvaluateModel()
        {
            IDataView prediction = Model.Transform(TestDataView);
            RegressionMetrics metrics = MLContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName:"Score");

            RootMeanSquareError = metrics.RootMeanSquaredError;
            RSquared = metrics.RSquared;
        }

        public void SaveModel()
        {
            MLContext.Model.Save(Model, DataView.Schema, "22813371488model.zip");
        }

        public float MakeSinglePrediction(int firstProductId, int secondProductId)
        {
            PredictionEngine<ProductPair, ProductPairPrediction> predictionEngine = MLContext.Model.CreatePredictionEngine<ProductPair, ProductPairPrediction>(Model);

            ProductPair productPair = new ProductPair
            {
                FirstProductId = firstProductId,
                SecondProductId = secondProductId
            };

            ProductPairPrediction predictionNormal = predictionEngine.Predict(productPair);

            ProductPair productPairInverted = new ProductPair
            {
                FirstProductId = secondProductId,
                SecondProductId = firstProductId
            };

            ProductPairPrediction predictionInverted = predictionEngine.Predict(productPairInverted);
 
            if (predictionInverted.Score > predictionNormal.Score)
            {
                return predictionInverted.Score;
            }
            else
            {
                return predictionNormal.Score;
            }
        }

        public Dictionary<int, float> GetRelevantProductList(int productId, List<int> globalIds)
        {
            if (!globalIds.Contains(productId))
            {
                throw new IdNotPresentException("Id not found in Id list");
            }

            globalIds.Remove(productId);
            Dictionary<int, float> idToLift = new Dictionary<int, float>();

            foreach (int secondProductId in globalIds)
            {
                float score = MakeSinglePrediction(productId, secondProductId);

                idToLift.Add(secondProductId, score);
            }

            return idToLift.OrderByDescending(idLift => idLift.Value).ToDictionary(idLift => idLift.Key, idToLift => idToLift.Value);
        }
    }
}