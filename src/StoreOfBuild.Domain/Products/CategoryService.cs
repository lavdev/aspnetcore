using System.Collections.Generic;

namespace StoreOfBuild.Domain.Products
{
    public class CategoryService
    {
        private readonly IRepository<Category> _categoryRespository;

        public CategoryService(IRepository<Category> categoryRespository){
            _categoryRespository = categoryRespository;
        }


        public IEnumerable<Category>  GetList()
        {
            return _categoryRespository.GetList();
        }

        public Category GetCategory(int id)
        {
            return _categoryRespository.GetId(id);
        }

        public void Store(int id, string name)
        {
            var category = _categoryRespository.GetId(id);
            if(category == null)
            {
                category = new Category(name);
                _categoryRespository.Save(category);
            }else
            {
                category.Update(name);
            }
        }
    }
}