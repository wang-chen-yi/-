using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lunch.Service;
using Lunch.Service.Dto;
using Lunch.Admin.Models;

namespace Lunch.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _Service;

        public CategoryController(CategoryService service )
        {
            _Service = service;
        }

        [Authorize(Roles = "1")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public IActionResult GetCategorys()
        {
            var data = _Service.GetCategory();
            return Json(new ResponseModel(true, data, 0));
        }

        [Authorize(Roles = "1")]
        public IActionResult EditCategory([FromBody]CategoryDto dto)
        {
            var data = _Service.EditCategory(dto);
            return Json(new ResponseModel(data, null, 0));
        }

        [Authorize(Roles = "1")]
        public IActionResult DeleteCategory(int id)
        {
            var data = _Service.DeleteCategory(id);
            return Json(new ResponseModel(data, null, 0));
        }
    }
}