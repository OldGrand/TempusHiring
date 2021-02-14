using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.Presentation.Models.ViewModels;

namespace TempusHiring.Presentation.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _catalogService;
        private readonly IMapper _mapper;
        private readonly SelectList ITEMS_ON_PAGE = new SelectList(new[] { 12, 24, 36 });

        public CatalogController(ICatalogService shopService, IMapper mapper)
        {
            _catalogService = shopService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Index(FilteredWatchViewModel filteredVM, int pageNum = 1)
        {
            var pagedResultWithDto = _catalogService.ReadUnisex(Filter.Deafult, pageNum, filteredVM.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredVM.PageResult = pagedResultWithViewModels;
            filteredVM.ItemsOnPageViewModel = ITEMS_ON_PAGE;

            return View(filteredVM);
        }
        
        [HttpGet]
        public IActionResult MensWatches(FilteredWatchViewModel filteredVM, int pageNum = 1)
        {
            var pagedResultWithDto = _catalogService.ReadMen(Filter.Deafult, pageNum, filteredVM.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredVM.PageResult = pagedResultWithViewModels;
            filteredVM.ItemsOnPageViewModel = ITEMS_ON_PAGE;

            return View(nameof(Index), filteredVM);
        }
        
        [HttpGet]
        public IActionResult WomensWatches(FilteredWatchViewModel filteredVM, int pageNum = 1)
        {
            var pagedResultWithDto = _catalogService.ReadWomen(Filter.Deafult, pageNum, filteredVM.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredVM.PageResult = pagedResultWithViewModels;
            filteredVM.ItemsOnPageViewModel = ITEMS_ON_PAGE;

            return View(nameof(Index), filteredVM);
        }

        public IActionResult GetPriceRange() => Json(_catalogService.GetWatchesPriceRange());
    }
}