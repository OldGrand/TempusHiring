using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Extensions;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Presentation.Models.ViewModels;

namespace TempusHiring.Presentation.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public ShoppingCartController(IShoppingCartService cartService, IMapper mapper)
        {
            _shoppingCartService = cartService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Items()
        {
            var userId = User.GetId();

            var shoppingCartDto = _shoppingCartService.ReadUserCart(userId);
            var userShoppingCartViewModels = _mapper.Map<IEnumerable<ShoppingCartViewModel>>(shoppingCartDto);

            var orderSummaryDto = _shoppingCartService.GetSummary(userId);
            var orderSummaryViewModel = _mapper.Map<OrderSummaryViewModel>(orderSummaryDto);

            var cartWrapper = new CartWrapperViewModel
            {
                OrderSummaryViewModel = orderSummaryViewModel,
                ShoppingCarts = userShoppingCartViewModels
            };

            return View(cartWrapper);
        }

        [HttpGet]
        public IActionResult GetOrderSummary()
        {
            var userId = User.GetId();
            var orderSummary = _shoppingCartService.GetSummary(userId);
            var orderSummaryViewModel = _mapper.Map<OrderSummaryViewModel>(orderSummary);

            return Json(orderSummaryViewModel);
        }

        [HttpGet]
        public IActionResult GetWatchPrice(int watchId)
        {
            var watchPrice = _shoppingCartService.GetWatchPrice(watchId);

            return Json(watchPrice);
        }

        [HttpGet]
        public IActionResult GetWatchCountInStock(int watchId)
        {
            var count = _shoppingCartService.GetWatchCountInStock(watchId);

            return Json(count);
        }

        [HttpPost]
        public IActionResult ChangeSelection(int watchId, bool isChecked)
        {
            var userId = User.GetId();
            _shoppingCartService.UpdateSelection(userId, watchId, isChecked);

            return Json(Url.Action(nameof(Items), "ShoppingCart"));
        }

        public IActionResult Buy()
        {
            return RedirectToAction("CreateOrder", "Orders");
        }
        
        public IActionResult ChangeCount(int watchId, int count)
        {
            var userId = User.GetId();
            _shoppingCartService.ChangeItemsCountInCart(userId, watchId, count);

            return RedirectToAction(nameof(Items), "ShoppingCart");
        }

        public IActionResult Remove(int cartId)
        {
            _shoppingCartService.DeleteFromCart(cartId);
            return RedirectToAction(nameof(Items), "ShoppingCart");
        }
    }
}