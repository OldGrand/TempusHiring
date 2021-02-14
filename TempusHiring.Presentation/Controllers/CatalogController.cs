using System.Collections.Generic;
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
        public IActionResult Index(int pageNum = 1, int itemsOnPage = 12)
        {
            var pagedResultWithDto = _catalogService.ReadUnisex(Filter.Deafult, pageNum, itemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            var filteredWatchViewModel = new FilteredWatchViewModel
            {
                PageResult = pagedResultWithViewModels,
            };

            return View(filteredWatchViewModel);
        }

        [HttpPost]
        public IActionResult Index(FilteredWatchViewModel filteredVM, int pageNum = 1)
        {
            var pagedResultWithDto = _catalogService.ReadUnisex(Filter.Deafult, pageNum, filteredVM.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDto);

            filteredVM.PageResult = pagedResultWithViewModels;
            filteredVM.ItemsOnPageViewModel = ITEMS_ON_PAGE;

            return View(filteredVM);
        }

        [HttpGet]
        public IActionResult MensWatches(int pageNum = 1, int itemsOnPage = 12)
        {
            return View(nameof(Index));
        }

        [HttpGet]
        public IActionResult WomensWatches(int pageNum = 1, int itemsOnPage = 12)
        {
            return View(nameof(Index));
        }

        public IActionResult GetPriceRange() => Json(_catalogService.GetWatchesPriceRange());
    }
}