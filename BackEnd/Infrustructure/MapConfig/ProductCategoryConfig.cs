using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Service.Catalog.API.Models;

namespace Service.Catalog.API.Infrustructure.MapConfig
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(p => new {p.ProductId,p.CategoryId });

            #region  Seed Data
            builder.HasData(
                new ProductCategory
                {
                    CategoryId = 4,
                    ProductId = 1,

                },
                new ProductCategory
                {
                    CategoryId = 1,
                    ProductId = 2,

                },
                new ProductCategory
                {
                    CategoryId = 3,
                    ProductId = 3,
                },
                new ProductCategory
                {
                    CategoryId = 2,
                    ProductId = 4,
                },
                new ProductCategory
                {
                    CategoryId = 1,
                    ProductId = 5,
                },
                new ProductCategory
                {
                    CategoryId = 5,
                    ProductId = 6,
                }
            );
            #endregion
        }
    }
}