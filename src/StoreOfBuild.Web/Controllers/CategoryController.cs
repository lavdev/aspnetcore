using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.ViewModel;

namespace StoreOfBuild.Web.Controllers
{
    public class CategoryController : Controller
    {
        public CategoryService _service { get; }

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categories = _service.GetList();
            var viewModels = categories.Select(c => new CategoryViewModel {Id = c.Id, Name = c.Name});

            return View(viewModels);
        }

        public IActionResult CreateOrEdit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateOrEdit(int id)
        {
            var category = _service.GetCategory(id);
            if (category == null) return View();
            var viewModel = new CategoryViewModel
            {
                Name = category.Name,
                Id = category.Id
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
           _service.Store(viewModel.Id, viewModel.Name);
            return RedirectToAction("Index");
        }        

    }
}
