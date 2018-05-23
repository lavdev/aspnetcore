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
            return View();
        }

        public IActionResult CreateOrEdit()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateOrEdit(CategoryViewModel viewModel)
        {
           _service.Store(viewModel.Id, viewModel.Name);
           return View();
        }        

    }
}
