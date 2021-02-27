using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.DataTransferObjects;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
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
        public async Task<IActionResult> DeleteWatch(int watchId)
        {
            var watchDto = await _watchService.ReadAsync(watchId);
            _watchService.Delete(watchDto);
            await _watchService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWatchList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditWatch(int watchId)
        {
            var watchDto = await _watchService.ReadAsync(watchId);
            var editWatchViewModel = _mapper.Map<EditWatchViewModel>(watchDto);

            return View(editWatchViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditWatch(EditWatchViewModel editWatchViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editWatchViewModel);
            }

            var watchDto = _mapper.Map<WatchDTO>(editWatchViewModel);
            _watchService.Update(watchDto);
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

            var watchDto = _mapper.Map<WatchDTO>(createWatchViewModel);
            await _watchService.AddAsync(watchDto);
            await _watchService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWatchList), CURRENT_CONTROLLER_NAME);
        }
    }
}
