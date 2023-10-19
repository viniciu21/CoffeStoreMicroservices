using Microsoft.EntityFrameworkCore;
using Products.Api.Core.Models.Entities.Base;

namespace Products.Api.Core.Common.Data.Configuration
{
    public static class ContextConfiguration
    {
        public static ModelBuilder ApplyGlobalStandards(this ModelBuilder builder)
        {
            foreach (var EntityBaseType in builder.Model.GetEntityTypes())
            {

                EntityBaseType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade).ToList()
                    .ForEach(fe => fe.DeleteBehavior = DeleteBehavior.Restrict);

                foreach (var property in EntityBaseType.GetProperties())
                {
                    switch (property.Name)
                    {
                        case nameof(EntityBase.Id):
                            property.IsKey();
                            break;
                        case nameof(EntityBase.ModifiedDate):
                            property.IsNullable = true;
                            break;
                        case nameof(EntityBase.CreatedDate):
                            property.IsNullable = false;
                            property.SetDefaultValueSql("NOW()");
                            break;
                        case nameof(EntityBase.IsDeleted):
                            property.IsNullable = false;
                            property.SetDefaultValue(false);
                            break;
                    }

                    if (property.ClrType == typeof(string) && string.IsNullOrEmpty(property.GetColumnType()))
                        property.SetColumnType($"varchar({property.GetMaxLength() ?? 100})");

                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                        property.SetColumnType("timestamp");
                }
            }

            return builder;
        }
    }
}
