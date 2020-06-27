using System.Linq;
using Lunch.Data;
using Microsoft.AspNetCore.Mvc;
using Lunch.Admin.Models;
using Lunch.Service;
using Lunch.Service.Dto;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Lunch.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "1")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "1")]
        public IActionResult GetOrders(QueryDto dto)
        {
            var orders = _orderService.GetOrders(dto, out int total);
            return Json(new ResponseModel(true, orders, total));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            return Json(new ResponseModel(await _orderService.UpdateOrderStatus(id, status)));
        }

    }
}