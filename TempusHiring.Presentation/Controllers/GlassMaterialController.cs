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
using TempusHiring.Presentation.Models.ViewModels.GlassMaterial;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{GlassMaterial}/{action}/{glassMaterialId?}")]
    public class GlassMaterialController : Controller
    {
        private readonly IGlassMaterialService _glassMaterialService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "GlassMaterial";

        public GlassMaterialController(IGlassMaterialService glassMaterialService, IMapper mapper)
        {
            _glassMaterialService = glassMaterialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGlassMaterialList(PaginationViewModel<GlassMaterialViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _glassMaterialService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<GlassMaterialViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;

            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteGlassMaterial(int glassMaterialId)
        {
            var glassMaterialDto = await _glassMaterialService.ReadAsync(glassMaterialId);
            _glassMaterialService.Delete(glassMaterialDto);
            await _glassMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetGlassMaterialList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditGlassMaterial(int glassMaterialId)
        {
            var glassMaterialDto = await _glassMaterialService.ReadAsync(glassMaterialId);
            var editGlassMaterialViewModel = _mapper.Map<EditGlassMaterialViewModel>(glassMaterialDto);

            return View(editGlassMaterialViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditGlassMaterial(EditGlassMaterialViewModel editGlassMaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editGlassMaterialViewModel);
            }

            var glassMaterialDto = _mapper.Map<GlassMaterialDTO>(editGlassMaterialViewModel);
            _glassMaterialService.Update(glassMaterialDto);
            await _glassMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetGlassMaterialList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateGlassMaterial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGlassMaterial(CreateGlassMaterialViewModel createGlassMaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createGlassMaterialViewModel);
            }

            var glassMaterialDto = _mapper.Map<GlassMaterialDTO>(createGlassMaterialViewModel);
            await _glassMaterialService.AddAsync(glassMaterialDto);
            await _glassMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetGlassMaterialList), CURRENT_CONTROLLER_NAME);
        }
    }
}