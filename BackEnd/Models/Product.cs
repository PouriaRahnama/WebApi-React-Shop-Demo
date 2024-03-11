using System.ComponentModel.DataAnnotations;

namespace Service.Catalog.API.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
    }
}