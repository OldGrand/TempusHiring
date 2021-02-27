using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.DataTransferObjects.Order;
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

        private const string CONTROLLER_NAME = "Orders";

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Items()
        {
            var userId = User.GetId();
            var orderDtos = _orderService.GetOrders(userId);
            var orderViewModels = _mapper.Map<IEnumerable<OrderViewModel>>(orderDtos);

            return View(orderViewModels);
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateOrder(CreateOrderViewModel createOrder)
        {
            var userId = User.GetId();

            var orderDto = _mapper.Map<OrderDTO>(createOrder);
            _orderService.CreateOrder(orderDto, userId);

            return RedirectToAction(nameof(Items), CONTROLLER_NAME);
        }
    }
}
