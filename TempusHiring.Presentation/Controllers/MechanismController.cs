using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempusHiring.BusinessLogic.DataTransferObjects.Admin;
using TempusHiring.BusinessLogic.Pagination;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Presentation.Models.ViewModels;
using TempusHiring.Presentation.Models.ViewModels.Mechanism;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{Mechanism}/{action}/{mechanismId?}")]
    public class MechanismController : Controller
    {
        private readonly IMechanismService _mechanismService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "Mechanism";

        public MechanismController(IMechanismService mechanismService, IMapper mapper)
        {
            _mechanismService = mechanismService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMechanismList(PaginationViewModel<MechanismViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _mechanismService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<MechanismViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;

            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteMechanism(int mechanismId)
        {
            var mechanismDto = await _mechanismService.ReadAsync(mechanismId);
            _mechanismService.Delete(mechanismDto);
            await _mechanismService.SaveChangesAsync();

            return RedirectToAction(nameof(GetMechanismList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditMechanism(int mechanismId)
        {
            var mechanismDto = await _mechanismService.ReadAsync(mechanismId);
            var editMechanismViewModel = _mapper.Map<EditMechanismViewModel>(mechanismDto);

            return View(editMechanismViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditMechanism(EditMechanismViewModel editMechanismViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editMechanismViewModel);
            }

            var mechanismDto = _mapper.Map<MechanismDTO>(editMechanismViewModel);
            _mechanismService.Update(mechanismDto);
            await _mechanismService.SaveChangesAsync();

            return RedirectToAction(nameof(GetMechanismList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateMechanism()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMechanism(CreateMechanismViewModel createMechanismViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createMechanismViewModel);
            }

            var mechanismDto = _mapper.Map<MechanismDTO>(createMechanismViewModel);
            await _mechanismService.AddAsync(mechanismDto);
            await _mechanismService.SaveChangesAsync();

            return RedirectToAction(nameof(GetMechanismList), CURRENT_CONTROLLER_NAME);
        }
    }
}
