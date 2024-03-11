using System.ComponentModel.DataAnnotations;

namespace Service.Catalog.API.Application.Dtos
{
    public class ShopProductDto
    {
        public List<ProductDto> ProductDto { get; set; }
        public CategoryDto CategoryDto { get; set; }
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }

    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
    }

    //Add product
    public class AddProductDto
    {
        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Display(Name = "نام محصول")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Display(Name = "قیمت محصول")]
        [Range(1000,10000)]
        public double Price { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Display(Name = "توضیحات محصول")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "{0} را وارد کنید")]
        [Display(Name = "تصویر محصول")]
        public required IFormFile ImageFile { get; set; }
    }

    //Edit product
    public class EditProductDto
    {
        [Required]
        [Display(Name = "شناسه محصول")]
        public int ProductId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public required string Name { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public double Price { get; set; }

        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public required string Description { get; set; }

        [Display(Name = "تصویر محصول")]
        public IFormFile? ImageFile { get; set; }
    }
}