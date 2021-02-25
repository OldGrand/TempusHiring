using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.Admin;
using TempusHiring.Presentation.Models.ViewModels.Color;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{Color}/{action}/{colorId?}")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "Color";

        public ColorController(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetColorList(PaginationViewModel<ColorViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _colorService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<ColorViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;
            
            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteColor(int colorId)
        {
            var colorDto = await _colorService.ReadAsync(colorId);
            _colorService.Delete(colorDto);
            await _colorService.SaveChangesAsync();

            return RedirectToAction(nameof(GetColorList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditColor(int colorId)
        {
            var colorDto = await _colorService.ReadAsync(colorId);
            var editColorViewModel = _mapper.Map<EditColorViewModel>(colorDto);

            return View(editColorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditColor(EditColorViewModel editColorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editColorViewModel);
            }

            var colorDto = _mapper.Map<ColorDTO>(editColorViewModel);
            _colorService.Update(colorDto);
            await _colorService.SaveChangesAsync();

            return RedirectToAction(nameof(GetColorList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateColor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateColor(CreateColorViewModel createColorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createColorViewModel);
            }

            var colorDto = _mapper.Map<ColorDTO>(createColorViewModel);
            await _colorService.AddAsync(colorDto);
            await _colorService.SaveChangesAsync();

            return RedirectToAction(nameof(GetColorList), CURRENT_CONTROLLER_NAME);
        }
    }
}