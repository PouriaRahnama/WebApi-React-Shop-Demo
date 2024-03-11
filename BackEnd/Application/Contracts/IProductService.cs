using Service.Catalog.API.Application.Dtos;

namespace Service.Catalog.API.Application.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProduct();
        Task<ProductDto> GetProductById(int ProductId);
        Task<ProductDto> CreateProduct(AddProductDto AddproductDto);
        Task<ProductDto> UpdateProduct(EditProductDto EditproductDto);
        Task<bool> DeleteProduct(int ProductId);
        Task<ShopProductDto>? GetProductsWithCategoriesByCategoryName(string Title);
        Task<IEnumerable<CategoryDto>> GetAllCategory();
    }
}