using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;
using TempusHiring.DataAccess.Entities;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.Admin;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IBodyMaterialService _bodyMaterialService;
        private readonly ICatalogService _catalogService;
        private readonly IColorService _colorService;
        private readonly IGlassMaterialService _glassMaterialService;
        private readonly IManufacturerService _manufacturerService;
        private readonly IMechanismService _mechanismService;
        private readonly IPhotoService _photoService;
        private readonly IStrapMaterialService _strapMaterialService;
        private readonly IStrapService _strapService;
        private readonly IWristSizeService _wristSizeService;
        private readonly IMapper _mapper;

        public AdminController(IBodyMaterialService bodyMaterialService, 
                               ICatalogService catalogService, 
                               IColorService colorService, 
                               IGlassMaterialService glassMaterialService, 
                               IManufacturerService manufacturerService, 
                               IMechanismService mechanismService, 
                               IPhotoService photoService, 
                               IStrapMaterialService strapMaterialService, 
                               IStrapService strapService, 
                               IWristSizeService wristSizeService, 
                               IMapper mapper)
        {
            _bodyMaterialService = bodyMaterialService;
            _catalogService = catalogService;
            _colorService = colorService;
            _glassMaterialService = glassMaterialService;
            _manufacturerService = manufacturerService;
            _mechanismService = mechanismService;
            _photoService = photoService;
            _strapMaterialService = strapMaterialService;
            _strapService = strapService;
            _wristSizeService = wristSizeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBodyMaterialsList(PaginationViewModel<BodyMaterialViewModel> paginationViewModel)
        {
            var bodyMaterialDtos = _bodyMaterialService.ReadAll(paginationViewModel.PageNum, paginationViewModel.ItemsOnPage);
            var bodyViewModel = _mapper.Map<IEnumerable<BodyMaterialViewModel>>(bodyMaterialDtos);

            var paginationVM = new PaginationViewModel<BodyMaterialViewModel>
            {
                ItemsOnPageSelectList = new SelectList(new[] {12, 24, 36}, paginationViewModel.ItemsOnPage),
                PageNum = paginationViewModel.PageNum,
                ItemsOnPage = paginationViewModel.ItemsOnPage,
                Items = bodyViewModel
            };

            return View(paginationVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBodyMaterials(int bodyMaterialId)
        {
            var bodyMaterialDto = await _bodyMaterialService.ReadAsync(bodyMaterialId);
            _bodyMaterialService.Delete(bodyMaterialDto);

            return RedirectToAction(nameof(GetBodyMaterialsList), "Admin");
        }

        [HttpPost]
        public IActionResult EditBodyMaterials(BodyMaterialViewModel bodyMaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(bodyMaterialViewModel);
            }

            var bodyMaterialDto = _mapper.Map<BodyMaterialDTO>(bodyMaterialViewModel);
            _bodyMaterialService.Update(bodyMaterialDto);

            return RedirectToAction(nameof(GetBodyMaterialsList), "Admin");
        }
    }
}
