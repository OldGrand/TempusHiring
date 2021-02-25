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
using TempusHiring.Presentation.Models.ViewModels.BodyMaterial;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{BodyMaterial}/{action}/{bodyMaterialId?}")]
    public class BodyMaterialController : Controller
    {
        private readonly IBodyMaterialService _bodyMaterialService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "BodyMaterial";

        public BodyMaterialController(IBodyMaterialService bodyMaterialService,
                               IMapper mapper)
        {
            _bodyMaterialService = bodyMaterialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBodyMaterialList(PaginationViewModel<BodyMaterialViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _bodyMaterialService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<BodyMaterialViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;

            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBodyMaterial(int bodyMaterialId)
        {
            var bodyMaterialDto = await _bodyMaterialService.ReadAsync(bodyMaterialId);
            _bodyMaterialService.Delete(bodyMaterialDto);
            await _bodyMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetBodyMaterialList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditBodyMaterial(int bodyMaterialId)
        {
            var bodyMaterialDto = await _bodyMaterialService.ReadAsync(bodyMaterialId);
            var editBodyMaterialViewModel = _mapper.Map<EditBodyMaterialViewModel>(bodyMaterialDto);

            return View(editBodyMaterialViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditBodyMaterial(EditBodyMaterialViewModel editBodyMaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editBodyMaterialViewModel);
            }

            var bodyMaterialDto = _mapper.Map<BodyMaterialDTO>(editBodyMaterialViewModel);
            _bodyMaterialService.Update(bodyMaterialDto);
            await _bodyMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetBodyMaterialList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateBodyMaterial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBodyMaterial(CreateBodyMaterialViewModel createBodyMaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBodyMaterialViewModel);
            }

            var bodyMaterialDto = _mapper.Map<BodyMaterialDTO>(createBodyMaterialViewModel);
            await _bodyMaterialService.AddAsync(bodyMaterialDto);
            await _bodyMaterialService.SaveChangesAsync();

            return RedirectToAction(nameof(GetBodyMaterialList), CURRENT_CONTROLLER_NAME);
        }
    }
}
