using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Lunch.Service;
using Lunch.Service.Dto;
using Lunch.Data;
using Lunch.DataAccess;
using Lunch.Admin.Models;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using SixLabors.Primitives;

namespace Lunch.Admin.Controllers
{
    public class FoodMenuController : Controller
    {
        private readonly FoodService _foodService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FoodMenuController(FoodService foodService, IHostingEnvironment hostingEnvironment)
        {
            _foodService = foodService;
            _hostingEnvironment = hostingEnvironment;
        }

        [Authorize(Roles = "1")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetFoodMenus(string keyword, string type, int pageSize, int pageIndex)
        {
            var foods = _foodService.QueryFoods(keyword, type,  pageSize,  pageIndex, out int total);
            return Json(new ResponseModel(true, foods, total));
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult UploadImg()
        {
            try
            {
                var fileCount = Request.Form.Files.Count;
                if (fileCount == 0) return Json(new { Success = false });

                var file = Request.Form.Files[0];
                var folder = _hostingEnvironment.WebRootPath + "/upload";
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var physicalPath = Path.Combine(folder, Path.GetFileName(file.FileName));
                using (FileStream fs = System.IO.File.Create(physicalPath))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }

                return Json(new { Success = true, fileName = $"/upload/{Path.GetFileName(file.FileName)}", type=file.ContentType });
            }
            catch
            {
                return Json(new { Success = false });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public ActionResult AddFoodMenu([FromBody]FoodMenuDto food)
        {
            string webrootpath = _hostingEnvironment.WebRootPath;
            string path = webrootpath + food.ImgUrl;
            FileStream fs = new FileStream(path, FileMode.Open);
            MemoryStream memory = new MemoryStream();
            fs.CopyTo(memory);
            var photo = memory.ToArray();
            fs.Close();

            var result = _foodService.AddFoodMenu(food, photo, food.ContentType);

            return Json(new ResponseModel(result > 0, null, 0));
        }

        public IActionResult ViewImge(int id)
        {
            var food = _foodService.GetFood(id);
            if (food == null || food.Image.Length == 0) return Content("Error");

            MemoryStream ms = new MemoryStream(food.Image);
            return new FileStreamResult(ms, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue(food.ImageType));
        }

        [Authorize(Roles = "1")]
        public IActionResult DeleteFoodMenu(int id)
        {
            var data = _foodService.Delete(id);
            return Json(new ResponseModel(data, null, 0));
        }
    }
}