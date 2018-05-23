using StoreOfBuild.Domain.Dtos;

namespace StoreOfBuild.Domain.Products
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRespository;

        public CategoryService(IRepository<Category> categoryRespository){
            _categoryRespository = categoryRespository;
        }

        public void Store(CategoryDto dto)
        {
            var category = _categoryRespository.GetId(dto.Id);
            if(category == null)
            {
                category = new Category(dto.Name);
                _categoryRespository.Save(category);
            }else
            {
                category.Update(dto.Name);
            }
        }
    }
}