using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Service.Catalog.API.Application.Contracts;
using Service.Catalog.API.Application.Dtos;
using Service.Catalog.API.Infrustructure.Persistence;
using Service.Catalog.API.Models;

namespace Service.Catalog.API.Application.Services
{
    public class ProductService : IProductService
    {
        #region Fields
        private SqlServerApplicationDB context;
        private readonly IHttpContextAccessor httpContextAccessor;
        private IMapper mapper;
        public ProductService(SqlServerApplicationDB Context, IMapper Mapper, IHttpContextAccessor HttpContextAccessor)
        {
            context = Context;
            mapper = Mapper;
            httpContextAccessor = HttpContextAccessor;
        }
        #endregion

        public async Task<ProductDto> CreateProduct(AddProductDto AddproductDto)
        {
            Product product = mapper.Map<Product>(AddproductDto);

            var imageFile = AddproductDto.ImageFile;
            var fileName = imageFile.FileName;
            fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                          .Replace(":", "")
                                          .Replace(".", "") + Path.GetExtension(fileName);

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blogPost".Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var Url = Path.Combine(folderName, fileName);
            using var stream = new FileStream(Url, FileMode.Create);
            await imageFile.CopyToAsync(stream);

            product.ImageURL = fileName; 
            await context.Product.AddAsync(product);
            await context.SaveChangesAsync();
            var productDto = mapper.Map<ProductDto>(product);
            productDto.ImageURL = GetProductImage(fileName, httpContextAccessor.HttpContext?.Request.Host.Value);
            return productDto;

        }

        public async Task<bool> DeleteProduct(int ProductId)
        {
            var product = await context.Product.FindAsync(ProductId);
            if (product is not null)
            {
                context.Product.Remove(product);
                await context.SaveChangesAsync();
                return true;
            }
            return false;
        }
      
        public async Task<IEnumerable<ProductDto>> GetAllProduct()
        {
            IEnumerable<Product> products = await context.Product.ToListAsync();
            var baseUrl = httpContextAccessor.HttpContext?.Request.Host.Value;
            foreach (var item in products)          
                item.ImageURL = GetProductImage(item.ImageURL, baseUrl);

            return mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductById(int ProductId)
        {
            Product? product = await context.Product.FindAsync(ProductId);
            if (product == null)
                return new ProductDto();

            var baseUrl = httpContextAccessor.HttpContext?.Request.Host.Value;
            product.ImageURL = GetProductImage(product.ImageURL, baseUrl);

            return mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateProduct(EditProductDto EditproductDto)
        {
            Product? product = await context.Product.FindAsync(EditproductDto.ProductId);

            if (product == null)
                return new ProductDto();

            string oldImage = product.ImageURL;
            var imageFile = EditproductDto.ImageFile;

            if (imageFile != null)
            {
                var fileName = imageFile.FileName;
                fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                              .Replace(":", "")
                                              .Replace(".", "") + Path.GetExtension(fileName);

                var folderName = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/blogPost".Replace("/", "\\"));
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);
                var Url = Path.Combine(folderName, fileName);
                using var stream = new FileStream(Url, FileMode.Create);
                await imageFile.CopyToAsync(stream);

                product.ImageURL = fileName;
            }

            product.Price = EditproductDto.Price;
            product.Name = EditproductDto.Name;
            product.Description = EditproductDto.Description;

            context.Product.Update(product);
            await context.SaveChangesAsync();
            var dto = mapper.Map<ProductDto>(product);
            dto.ImageURL = GetProductImage(dto.ImageURL, httpContextAccessor.HttpContext?.Request.Host.Value);

            if (imageFile != null)
            {
                if (File.Exists(oldImage))
                    File.Delete(oldImage);
            }
            return dto;
        }

        public async Task<ShopProductDto>? GetProductsWithCategoriesByCategoryName(string Title)
        {

            var result2 = await context.Category.Include(c => c.productCategories).ThenInclude(c => c.Product)
                .Where(c => c.Title == Title).SelectMany(c => c.productCategories).Select(c => c.Product).ToListAsync();

            if (result2.Count == 0)
            {
                return new ShopProductDto();
            }
            List<ProductDto> productDtos = new List<ProductDto>();

            result2.ForEach(c => productDtos.Add(new ProductDto()
            {
                Description = c.Description,
                ImageURL = c.ImageURL,
                Name = c.Name,
                Price = c.Price,
                ProductId = c.ProductId
            }));

            foreach (var item in productDtos)
                item.ImageURL = GetProductImage(item.ImageURL, httpContextAccessor.HttpContext?.Request.Host.Value!);

            var result4 = await context.Category.Where(c => c.Title == Title).Select(c => new CategoryDto()
            {
                Title = c.Title,
                CategoryId = c.CategoryId
            }).FirstAsync();

            ShopProductDto productDtoForShop = new ShopProductDto()
            {
                CategoryDto = result4,
                ProductDto = productDtos
            };

            return productDtoForShop;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategory()
        {
            IEnumerable<Category> categories = await context.Category.ToListAsync();

            return mapper.Map<List<CategoryDto>>(categories);
        }

        public static string GetProductImage(string imageName,string ServerPath)
        {
            ServerPath = $"http://{ServerPath}";
            string Images = "/images/ProductImage";

            return $"{ServerPath}{Images}/{imageName}";
        }

    }
}