using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Domain.Products
{
    /// <summary>
    /// Class Service
    /// </summary>
    public class ProductService
    {
        private readonly IRepository<Product> _productyRepository;
        private readonly IRepository<Category> _categoryRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<Category> categoryRespository)
        {
            _productyRepository = productRepository;
            _categoryRepository = categoryRespository;
            
        }
        public void Store(ProductDto dto)
        {
            var category = _categoryRepository.GetId(dto.CategoryId);

            DomainException.When(category == null, "Category is required");

            var product = _productyRepository.GetId(dto.Id);
            if(product == null){
                product = new Product(dto.Name,category, dto.Price, dto.StockQuantity);
                _productyRepository.Save(product);
            }else{
                product.Update(dto.Name,category, dto.Price, dto.StockQuantity);
            }
        }
    }
}