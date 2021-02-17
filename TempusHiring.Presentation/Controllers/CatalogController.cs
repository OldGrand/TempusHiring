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
        private readonly SelectList ITEMS_ON_PAGE = new SelectList(new[] { 12, 24, 36 });

        public CatalogController(ICatalogService shopService, IMapper mapper, IShoppingCartService shoppingCartService)
        {
            _catalogService = shopService;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }
        
        public IActionResult Index(FilteredWatchViewModel filteredVM, int pageNum = 1)
        {
            var pagedResultWithDto = _catalogService.ReadUnisex(Filter.Deafult, pageNum, filteredVM.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredVM.PageResult = pagedResultWithViewModels;
            filteredVM.ItemsOnPageViewModel = ITEMS_ON_PAGE;

            return View(filteredVM);
        }
        
        public IActionResult MensWatches(FilteredWatchViewModel filteredVM, int pageNum = 1)
        {
            var pagedResultWithDto = _catalogService.ReadMen(Filter.Deafult, pageNum, filteredVM.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredVM.PageResult = pagedResultWithViewModels;
            filteredVM.ItemsOnPageViewModel = ITEMS_ON_PAGE;

            return View(nameof(Index), filteredVM);
        }
        
        public IActionResult WomensWatches(FilteredWatchViewModel filteredVM, int pageNum = 1)
        {
            var pagedResultWithDto = _catalogService.ReadWomen(Filter.Deafult, pageNum, filteredVM.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredVM.PageResult = pagedResultWithViewModels;
            filteredVM.ItemsOnPageViewModel = ITEMS_ON_PAGE;

            return View(nameof(Index), filteredVM);
        }

        [HttpPost]
        public IActionResult Details(int watchId)
        {
            var watchDto = _catalogService.ReadById(watchId);
            var watchViewModel = _mapper.Map<WatchViewModel>(watchDto);
            return View(watchViewModel);
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