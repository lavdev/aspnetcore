using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Web.Models;

namespace StoreOfBuild.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Product";
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
