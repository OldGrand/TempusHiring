using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Extensions;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.Presentation.Models.ViewModels;

namespace TempusHiring.Presentation.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _cartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Items()
        {
            var userId = User.GetId();

            var cartWrapper = new CartWrapperViewModel
            {
                OrderSummary = _mapper.Map<OrderSummaryViewModel>(_cartService.GetSummary(userId)),
                ShoppingCarts = _mapper.Map<IEnumerable<ShoppingCartViewModel>>(_cartService.ReadUserCart(userId))
            };

            return View(cartWrapper);
        }

        public IActionResult ChangeSelection(int watchId, bool isChecked)
        {
            var userId = User.GetId();
            _cartService.UpdateSelection(userId, watchId, isChecked);

            return Json(Url.Action(nameof(Items), "ShoppingCart"));
        }

        public IActionResult Buy()
        {
            return RedirectToAction("CreateOrder", "Orders");
        }
        
        public IActionResult ChangeCount(int watchId, Operations operation)
        {
            var userId = User.GetId();
            _cartService.ChangeCount(userId, watchId, operation);

            return RedirectToAction(nameof(Items), "ShoppingCart");
        }

        public IActionResult Remove(int cartId)
        {
            _cartService.DeleteFromCart(cartId);
            return RedirectToAction(nameof(Items), "ShoppingCart");
        }
    }
}