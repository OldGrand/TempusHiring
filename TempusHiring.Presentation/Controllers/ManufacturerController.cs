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
using TempusHiring.Presentation.Models.ViewModels.Manufacturer;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    [Route("Admin/{Color}/{action}/{manufacturerId?}")]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _manufacturerService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "Manufacturer";

        public ManufacturerController(IManufacturerService manufacturerService, IMapper mapper)
        {
            _manufacturerService = manufacturerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetManufacturerList(PaginationViewModel<ManufacturerViewModel> paginationViewModel, int pageNum = 1)
        {
            var pagedResultWithDtos = _manufacturerService.GetPagedResult(pageNum, paginationViewModel.ItemsOnPage);
            var pagedResultWithViewModels = _mapper.Map<PagedResult<ManufacturerViewModel>>(pagedResultWithDtos);

            paginationViewModel.ItemsOnPageSelectList =
                new SelectList(new[] { 12, 24, 36 }, paginationViewModel.ItemsOnPage);
            paginationViewModel.PagedResult = pagedResultWithViewModels;

            return View(paginationViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteManufacturer(int manufacturerId)
        {
            var manufacturerDto = await _manufacturerService.ReadAsync(manufacturerId);
            _manufacturerService.Delete(manufacturerDto);
            await _manufacturerService.SaveChangesAsync();

            return RedirectToAction(nameof(GetManufacturerList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public async Task<IActionResult> EditManufacturer(int manufacturerId)
        {
            var manufacturerDto = await _manufacturerService.ReadAsync(manufacturerId);
            var editManufacturerViewModel = _mapper.Map<EditManufacturerViewModel>(manufacturerDto);

            return View(editManufacturerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditManufacturer(EditManufacturerViewModel editManufacturerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editManufacturerViewModel);
            }

            var manufacturerDto = _mapper.Map<ManufacturerDTO>(editManufacturerViewModel);
            _manufacturerService.Update(manufacturerDto);
            await _manufacturerService.SaveChangesAsync();

            return RedirectToAction(nameof(GetManufacturerList), CURRENT_CONTROLLER_NAME);
        }

        [HttpGet]
        public IActionResult CreateManufacturer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer(CreateManufacturerViewModel createManufacturerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createManufacturerViewModel);
            }

            var manufacturerDto = _mapper.Map<ManufacturerDTO>(createManufacturerViewModel);
            await _manufacturerService.AddAsync(manufacturerDto);
            await _manufacturerService.SaveChangesAsync();

            return RedirectToAction(nameof(GetManufacturerList), CURRENT_CONTROLLER_NAME);
        }
    }
}