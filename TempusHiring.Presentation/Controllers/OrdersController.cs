using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Extensions;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Presentation.Models.ViewModels.Order;

namespace TempusHiring.Presentation.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Items()
        {
            var userId = User.GetId();
            var orderDtos = _orderService.GetOrders(userId).ToList();
            var orderViewModels = _mapper.Map<IEnumerable<OrderViewModel>>(orderDtos);

            return View(orderViewModels);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            var userId = User.GetId();
            _orderService.AddItemsToOrder(userId);

            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderViewModel createOrder)
        {
            var userId = User.GetId();
            _orderService.AddItemsToOrder(userId);

            return RedirectToAction(nameof(Items), "Orders");
        }
    }
}
