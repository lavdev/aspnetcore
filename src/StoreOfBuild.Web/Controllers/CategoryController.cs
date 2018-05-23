using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreOfBuild.Domain.Dtos;
using StoreOfBuild.Domain.Products;
using StoreOfBuild.Web.Models;

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
        public IActionResult CreateOrEdit(CategoryDto dto)
        {
           _service.Store(dto);
           return View();
        }        

    }
}
