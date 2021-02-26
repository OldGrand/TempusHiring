using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.WristSize;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{WristSize}/{action}/{wristSizeId?}")]
    public class WristSizeController : Controller
    {
        private readonly IWristSizeService _wristSizeService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "WristSize";

        public WristSizeController(IWristSizeService wristSizeService, IMapper mapper)
        {
            _wristSizeService = wristSizeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetWristSizeList(PaginationViewModel<WristSizeViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _wristSizeService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<WristSizeViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;

            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteWristSize(int wristSizeId)
        {
            var wristSizeDto = await _wristSizeService.ReadAsync(wristSizeId);
            _wristSizeService.Delete(wristSizeDto);
            await _wristSizeService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWristSizeList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditWristSize(int wristSizeId)
        {
            var wristSizeDto = await _wristSizeService.ReadAsync(wristSizeId);
            var editWristSizeViewModel = _mapper.Map<EditWristSizeViewModel>(wristSizeDto);

            return View(editWristSizeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditWristSize(EditWristSizeViewModel editWristSizeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editWristSizeViewModel);
            }

            var wristSizeDto = _mapper.Map<WristSizeDTO>(editWristSizeViewModel);
            _wristSizeService.Update(wristSizeDto);
            await _wristSizeService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWristSizeList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateWristSize()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateWristSize(CreateWristSizeViewModel createWristSizeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createWristSizeViewModel);
            }

            var wristSizeDto = _mapper.Map<WristSizeDTO>(createWristSizeViewModel);
            await _wristSizeService.AddAsync(wristSizeDto);
            await _wristSizeService.SaveChangesAsync();

            return RedirectToAction(nameof(GetWristSizeList), CURRENT_CONTROLLER_NAME);
        }
    }
}