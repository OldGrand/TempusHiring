using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.Watch;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{Watch}/{action}/{watchId?}")]
    public class WatchController : Controller
    {
        private readonly IWatchService _watchService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "Watch";

        public WatchController(IWatchService watchService, IMapper mapper)
        {
            _watchService = watchService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWatchList(PaginationViewModel<WatchViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _watchService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WatchViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;

            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteWatch(int mechanismId)
        {
            var mechanismDto = await _watchService.ReadAsync(mechanismId);
            _watchService.Delete(mechanismDto);
            await _watchService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWatchList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditWatch(int mechanismId)
        {
            var mechanismDto = await _watchService.ReadAsync(mechanismId);
            var editWatchViewModel = _mapper.Map<EditWatchViewModel>(mechanismDto);

            return View(editWatchViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditWatch(EditWatchViewModel editWatchViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editWatchViewModel);
            }

            var mechanismDto = _mapper.Map<WatchDTO>(editWatchViewModel);
            _watchService.Update(mechanismDto);
            await _watchService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWatchList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateWatch()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWatch(CreateWatchViewModel createWatchViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createWatchViewModel);
            }

            var mechanismDto = _mapper.Map<WatchDTO>(createWatchViewModel);
            await _watchService.AddAsync(mechanismDto);
            await _watchService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWatchList), CURRENT_CONTROLLER_NAME);
        }
    }
}
