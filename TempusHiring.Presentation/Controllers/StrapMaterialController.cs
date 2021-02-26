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
using TempusHiring.Presentation.Models.ViewModels.StrapMaterial;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{BodyMaterial}/{action}/{bodyMaterialId?}")]
    public class StrapMaterialController : Controller
    {
        private readonly IStrapMaterialService _strapMaterialService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "StrapMaterial";

        public StrapMaterialController(IStrapMaterialService strapMaterialService, IMapper mapper)
        {
            _strapMaterialService = strapMaterialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStrapMaterialList(PaginationViewModel<StrapMaterialViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _strapMaterialService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<StrapMaterialViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;

            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteStrapMaterial(int strapMaterialId)
        {
            var strapMaterialDto = await _strapMaterialService.ReadAsync(strapMaterialId);
            _strapMaterialService.Delete(strapMaterialDto);
            await _strapMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetStrapMaterialList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditStrapMaterial(int strapMaterialId)
        {
            var strapMaterialDto = await _strapMaterialService.ReadAsync(strapMaterialId);
            var editStrapMaterialViewModel = _mapper.Map<EditStrapMaterialViewModel>(strapMaterialDto);

            return View(editStrapMaterialViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditStrapMaterial(EditStrapMaterialViewModel editStrapMaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editStrapMaterialViewModel);
            }

            var strapMaterialDto = _mapper.Map<StrapMaterialDTO>(editStrapMaterialViewModel);
            _strapMaterialService.Update(strapMaterialDto);
            await _strapMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetStrapMaterialList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateStrapMaterial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStrapMaterial(CreateStrapMaterialViewModel createStrapMaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createStrapMaterialViewModel);
            }

            var strapMaterialDto = _mapper.Map<StrapMaterialDTO>(createStrapMaterialViewModel);
            await _strapMaterialService.AddAsync(strapMaterialDto);
            await _strapMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetStrapMaterialList), CURRENT_CONTROLLER_NAME);
        }
    }
}
