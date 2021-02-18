using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.Extensions;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.Presentation.Models.ViewModels;

namespace TempusHiring.Presentation.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IMapper _mapper;

        public CatalogController(ICatalogService shopService, IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _catalogService = shopService;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }
        
        public IActionResult Index(FilteredWatchViewModel filteredViewModel, int pageNum = 1)
        {
            var filter = _mapper.Map<Filter>(filteredViewModel.Filter);
            var pagedResultWithDto = _catalogService.ReadUnisex(filter, pageNum, filteredViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredViewModel.PageResult = pagedResultWithViewModels;
            filteredViewModel.ItemsOnPageViewModel = new SelectList(new[] { 12, 24, 36 }, filteredViewModel.ItemsOnPage);

            return View(filteredViewModel);
        }
        
        public IActionResult MensWatches(FilteredWatchViewModel filteredViewModel, int pageNum = 1)
        {
            var filter = _mapper.Map<Filter>(filteredViewModel.Filter);
            var pagedResultWithDto = _catalogService.ReadMen(filter, pageNum, filteredViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredViewModel.PageResult = pagedResultWithViewModels;
            filteredViewModel.ItemsOnPageViewModel = new SelectList(new[] { 12, 24, 36 }, filteredViewModel.ItemsOnPage);

            return View(nameof(Index), filteredViewModel);
        }
        
        public IActionResult WomensWatches(FilteredWatchViewModel filteredViewModel, int pageNum = 1)
        {
            var filter = _mapper.Map<Filter>(filteredViewModel.Filter);
            var pagedResultWithDto = _catalogService.ReadWomen(filter, pageNum, filteredViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredViewModel.PageResult = pagedResultWithViewModels;
            filteredViewModel.ItemsOnPageViewModel = new SelectList(new[] { 12, 24, 36 }, filteredViewModel.ItemsOnPage);

            return View(nameof(Index), filteredViewModel);
        }

        [HttpPost]
        public IActionResult Details(int watchId)
        {
            var watchDto = _catalogService.ReadById(watchId);
            var watchViewModel = _mapper.Map<WatchViewModel>(watchDto);
            return View(watchViewModel);
        }

        [HttpPost]
        public IActionResult UpdatePriceRange(int startPrice, int endPrice)
        {
            try
            {
                _catalogService.ChangePriceRange(startPrice, endPrice);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpGet]
        public IActionResult GetPriceRange()
        {
            return Json(_catalogService.GetWatchesPriceRange());
        }
        
        [HttpGet]
        public async Task<IActionResult> AddToCart(int watchId)
        {
            var userId = User.GetId();
            await _shoppingCartService.AddToCartAsync(userId, watchId);
            return Ok();
        }
    }
}