using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsApi.Core.Common.Data.Configuration;
using ProductsApi.Core.Models;
using ProductsApi.Core.Models.Entities;
using ProductsApi.Core.Models.Entities.Base;
using ProductsApi.Core.Models.Types;
using System.Diagnostics;

namespace ProductsApi.Core.Common.Data
{
    public class ProductsDbContext : DbContext 
    {

        private readonly ConnectionStringsType _connectionStrings;

        public ProductsDbContext(
                        DbContextOptions<ProductsDbContext> opt,
                        IOptions<ConnectionStringsType> _optionsConnectionStrings) 
                    : base(opt) 
        {
            _connectionStrings = _optionsConnectionStrings.Value;
        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductsDbContext).Assembly);
            modelBuilder.ApplyGlobalStandards();
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         //   if (!optionsBuilder.IsConfigured)
         //   {
                optionsBuilder.UseNpgsql(_connectionStrings.ProductsContext)
                              .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
          //  }

            optionsBuilder.EnableSensitiveDataLogging();

        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            ChangeTracker.Entries().ToList().ForEach(entry =>
            {
                if (entry.Entity is not EntityBase trackableEntity)
                    return;

                switch (entry.State)
                {
                    case EntityState.Added:
                        trackableEntity.CreatedDate = DateTime.Now;
                        trackableEntity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        trackableEntity.ModifiedDate = DateTime.Now;
                        break;
                }
            });
        }
    }
}
