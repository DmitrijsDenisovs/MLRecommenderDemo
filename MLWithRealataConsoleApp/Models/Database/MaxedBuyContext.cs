using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace MLWithRealataConsoleApp.Models.Database
{
    public partial class MaxedBuyContext : DbContext
    {
        public MaxedBuyContext()
        {
        }

        public MaxedBuyContext(DbContextOptions<MaxedBuyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<AdminPortalUser> AdminPortalUsers { get; set; }
        public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }
        public virtual DbSet<AggregatedCounter1> AggregatedCounters1 { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Counter> Counters { get; set; }
        public virtual DbSet<Counter1> Counters1 { get; set; }
        public virtual DbSet<GoogleFeedProduct> GoogleFeedProducts { get; set; }
        public virtual DbSet<Hash> Hashes { get; set; }
        public virtual DbSet<Hash1> Hashes1 { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Job1> Jobs1 { get; set; }
        public virtual DbSet<JobParameter> JobParameters { get; set; }
        public virtual DbSet<JobParameter1> JobParameters1 { get; set; }
        public virtual DbSet<JobQueue> JobQueues { get; set; }
        public virtual DbSet<JobQueue1> JobQueues1 { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<List1> Lists1 { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public virtual DbSet<PriceExtra> PriceExtras { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBlackList> ProductBlackLists { get; set; }
        public virtual DbSet<ProductImportJob> ProductImportJobs { get; set; }
        public virtual DbSet<ProductImportJobItem> ProductImportJobItems { get; set; }
        public virtual DbSet<ProductImportLog> ProductImportLogs { get; set; }
        public virtual DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
        public virtual DbSet<ProductVariant> ProductVariants { get; set; }
        public virtual DbSet<RetailerAccount> RetailerAccounts { get; set; }
        public virtual DbSet<Schema> Schemas { get; set; }
        public virtual DbSet<Schema1> Schemas1 { get; set; }
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Server1> Servers1 { get; set; }
        public virtual DbSet<Set> Sets { get; set; }
        public virtual DbSet<Set1> Sets1 { get; set; }
        public virtual DbSet<ShippingOption> ShippingOptions { get; set; }
        public virtual DbSet<SitePageBlock> SitePageBlocks { get; set; }
        public virtual DbSet<SiteSetting> SiteSettings { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<State1> States1 { get; set; }
        public virtual DbSet<VCategory> VCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=54.39.185.161;Database=MaxedBuy;User ID=maksim;Password=93=4=OQtkLJ--VN;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");
            });

            modelBuilder.Entity<AggregatedCounter>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangfireAdminPortal");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<AggregatedCounter1>(entity =>
            {
                entity.HasKey(e => e.Key)
                    .HasName("PK_HangFire_CounterAggregated");

                entity.ToTable("AggregatedCounter", "HangfireWebApi");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.ParentCategoryId, "IX_Categories_ParentCategoryId");

                entity.HasOne(d => d.ParentCategory)
                    .WithMany(p => p.InverseParentCategory)
                    .HasForeignKey(d => d.ParentCategoryId);
            });

            modelBuilder.Entity<Counter>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangfireAdminPortal");

                entity.HasIndex(e => e.Key, "CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Counter1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Counter", "HangfireWebApi");

                entity.HasIndex(e => e.Key, "CX_HangFire_Counter")
                    .IsClustered();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GoogleFeedProduct>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CustomLabel3).HasMaxLength(110);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.GoogleFeedProduct)
                    .HasForeignKey<GoogleFeedProduct>(d => d.Id);
            });

            modelBuilder.Entity<Hash>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangfireAdminPortal");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Hash1>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Field })
                    .HasName("PK_HangFire_Hash");

                entity.ToTable("Hash", "HangfireWebApi");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(100);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.HasIndex(e => e.ProductId, "IX_Image_ProductId");

                entity.Property(e => e.Url)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job", "HangfireAdminPortal");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt");

                entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<Job1>(entity =>
            {
                entity.ToTable("Job", "HangfireWebApi");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt");

                entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName");

                entity.Property(e => e.Arguments).IsRequired();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.InvocationData).IsRequired();

                entity.Property(e => e.StateName).HasMaxLength(20);
            });

            modelBuilder.Entity<JobParameter>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangfireAdminPortal");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameters)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobParameter1>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Name })
                    .HasName("PK_HangFire_JobParameter");

                entity.ToTable("JobParameter", "HangfireWebApi");

                entity.Property(e => e.Name).HasMaxLength(40);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobParameter1s)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_JobParameter_Job");
            });

            modelBuilder.Entity<JobQueue>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangfireAdminPortal");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<JobQueue1>(entity =>
            {
                entity.HasKey(e => new { e.Queue, e.Id })
                    .HasName("PK_HangFire_JobQueue");

                entity.ToTable("JobQueue", "HangfireWebApi");

                entity.Property(e => e.Queue).HasMaxLength(50);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangfireAdminPortal");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<List1>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Id })
                    .HasName("PK_HangFire_List");

                entity.ToTable("List", "HangfireWebApi");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("Log");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.CustomerAddressId, "IX_Orders_CustomerAddressId");

                entity.HasIndex(e => e.PublicId, "IX_Orders_PublicId")
                    .IsUnique();

                entity.HasIndex(e => e.ShippingId, "IX_Orders_ShippingId");

                entity.Property(e => e.ShippingPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CustomerAddress)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerAddressId);

                entity.HasOne(d => d.Shipping)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShippingId);
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "IX_OrderProducts_OrderId");

                entity.HasIndex(e => e.ProductId, "IX_OrderProducts_ProductId");

                entity.HasIndex(e => e.RetailerAccountId, "IX_OrderProducts_RetailerAccountId");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.RetailerAccount)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.RetailerAccountId);
            });

            modelBuilder.Entity<OrderStatusHistory>(entity =>
            {
                entity.ToTable("OrderStatusHistory");

                entity.HasIndex(e => e.OrderProductId, "IX_OrderStatusHistory_OrderProductId");

                entity.HasOne(d => d.OrderProduct)
                    .WithMany(p => p.OrderStatusHistories)
                    .HasForeignKey(d => d.OrderProductId);
            });

            modelBuilder.Entity<PriceExtra>(entity =>
            {
                entity.ToTable("PriceExtra");

                entity.Property(e => e.MinProfitAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProfitAmount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProfitPercent).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ToAmount).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ExternalId, "IX_NonClustered_Products_ExternalId");

                entity.HasIndex(e => e.CategoryId, "IX_Products_CategoryId");

                entity.HasIndex(e => e.ExternalIdComputed, "IX_Products_ExternalIdComputed");

                entity.Property(e => e.Brand).HasMaxLength(100);

                entity.Property(e => e.Color).HasMaxLength(200);

                entity.Property(e => e.Ean).HasMaxLength(15);

                entity.Property(e => e.ExternalId).HasMaxLength(10);

                entity.Property(e => e.Mpn).HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PriceMarkup).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Upc).HasMaxLength(15);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<ProductBlackList>(entity =>
            {
                entity.ToTable("ProductBlackList");
            });

            modelBuilder.Entity<ProductImportJobItem>(entity =>
            {
                entity.HasIndex(e => e.ProductImportJobId, "IX_ProductImportJobItems_ProductImportJobId");

                entity.HasOne(d => d.ProductImportJob)
                    .WithMany(p => p.ProductImportJobItems)
                    .HasForeignKey(d => d.ProductImportJobId);
            });

            modelBuilder.Entity<ProductImportLog>(entity =>
            {
                entity.ToTable("ProductImportLog");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.ProductImportJobItem)
                    .WithMany(p => p.ProductImportLogs)
                    .HasForeignKey(d => d.ProductImportJobItemId);
            });

            modelBuilder.Entity<ProductPriceHistory>(entity =>
            {
                entity.ToTable("ProductPriceHistory");

                entity.HasIndex(e => e.ProductId, "IX_ProductPriceHistory_ProductId");

                entity.Property(e => e.NewPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OldPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPriceHistories)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductVariant>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_ProductVariants_ProductId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVariants)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Schema>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangfireAdminPortal");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Schema1>(entity =>
            {
                entity.HasKey(e => e.Version)
                    .HasName("PK_HangFire_Schema");

                entity.ToTable("Schema", "HangfireWebApi");

                entity.Property(e => e.Version).ValueGeneratedNever();
            });

            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "HangfireAdminPortal");

                entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Server1>(entity =>
            {
                entity.ToTable("Server", "HangfireWebApi");

                entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

                entity.Property(e => e.Id).HasMaxLength(100);

                entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangfireAdminPortal");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt");

                entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<Set1>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.Value })
                    .HasName("PK_HangFire_Set");

                entity.ToTable("Set", "HangfireWebApi");

                entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt");

                entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(256);

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShippingOption>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<SitePageBlock>(entity =>
            {
                entity.Property(e => e.BlockKey).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(150);
            });

            modelBuilder.Entity<SiteSetting>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangfireAdminPortal");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<State1>(entity =>
            {
                entity.HasKey(e => new { e.JobId, e.Id })
                    .HasName("PK_HangFire_State");

                entity.ToTable("State", "HangfireWebApi");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.State1s)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_HangFire_State_Job");
            });

            modelBuilder.Entity<VCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vCategories");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
