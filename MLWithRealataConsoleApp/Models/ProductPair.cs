using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLWithRealataConsoleApp.Models
{
    public class ProductPair
    {
        [LoadColumn(0)] public float FirstProductId;
        [LoadColumn(1)] public float SecondProductId;
        [LoadColumn(2)] public float Label; //Lift
    }
}
