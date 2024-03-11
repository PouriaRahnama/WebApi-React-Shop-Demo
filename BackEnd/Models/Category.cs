namespace Service.Catalog.API.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<ProductCategory> productCategories { get; set; }
    }
}
