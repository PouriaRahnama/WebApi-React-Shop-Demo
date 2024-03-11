using Microsoft.AspNetCore.Mvc;
using Service.Catalog.API;
using Service.Catalog.API.Application.Contracts;
using Service.Catalog.API.Application.Dtos;

namespace MyApp.Namespace
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ResponseDto responseDto;
        private IProductService productService;
        public ProductController(IProductService ProductService)
        {
            productService = ProductService;
            responseDto = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                var productDtos = await productService.GetAllProduct();
                responseDto.Result = productDtos;
                responseDto.IsSuccess=true;
                responseDto.DisplayMessage="عملیات با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.Message };
                responseDto.DisplayMessage="عملیات با موفقیت انجام نشد";
            }

            return responseDto;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> GetById(int id)
        {
            try
            {
                ProductDto product = await productService.GetProductById(id);
                responseDto.Result = product;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.Message };
            }

            return responseDto;
        }

        [HttpPost]
        public async Task<object> AddProduct([FromForm] AddProductDto addProductDto)
        {
            try
            {
                ProductDto product = await productService.CreateProduct(addProductDto);
                responseDto.Result = product;
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.Message };
            }

            return responseDto;
        }

        [HttpPut]
        public async Task<object> UpdateProduct([FromForm] EditProductDto editProductDto)
        {
            try
            {
                ProductDto product = await productService.UpdateProduct(editProductDto);
                responseDto.Result = product;               
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.Message };
            }

            return responseDto;
        }

        [HttpDelete]
        public async Task<object> DeleteProduct(int ProductId)
        {
            try
            {
                bool Sucess = await productService.DeleteProduct(ProductId);
                responseDto.DisplayMessage = "Product deleted successfully";
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.Message };
            }
            return responseDto;
        }

        [HttpGet]
        [Route("GetProductsByCategoryTitle")]
        public async Task<object>? GetProductsWithCategoryTitleForShop(string CategoryTitle)
        {
            try
            {
                var productDtos = await productService.GetProductsWithCategoriesByCategoryName(CategoryTitle);
                responseDto.Result = productDtos;
                responseDto.IsSuccess = true;
                responseDto.DisplayMessage = "عملیات با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.Message };
            }
            return responseDto;
        }

        [HttpGet]
        [Route("Category")]
        public async Task<object> GetAllCategory()
        {
            try
            {
                var categoryDtos = await productService.GetAllCategory();
                responseDto.Result = categoryDtos;
                responseDto.IsSuccess = true;
                responseDto.DisplayMessage = "عملیات با موفقیت انجام شد";
            }
            catch (Exception ex)
            {
                responseDto.IsSuccess = false;
                responseDto.ErrorMessage = new List<string> { ex.Message };
                responseDto.DisplayMessage = "عملیات با موفقیت انجام نشد";
            }

            return responseDto;
        }
    }
}
