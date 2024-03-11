using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Service.Catalog.API.Models;

namespace Service.Catalog.API.Infrustructure.MapConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(p => p.CategoryId);

            #region  Seed Data
            builder.HasData(
                new Category
                {
                    CategoryId = 1,
                    Title = "Phone"                   
                },
                new Category
                {
                    CategoryId = 2,
                    Title = "Watch",
                },
                new Category
                {
                    CategoryId = 3,
                    Title = "AirPod",
                },
                new Category
                {
                    CategoryId = 4,
                    Title = "Laptop",
                },
                new Category
                {
                    CategoryId = 5,
                    Title = "Mouse",
                }
            );
            #endregion
        }
    }
}
