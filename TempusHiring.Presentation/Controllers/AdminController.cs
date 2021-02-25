using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Services.Interfaces;

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

        private const string CURRENT_CONTROLLER_NAME = "Admin";

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
        public IActionResult Index()
        {
            return View();
        }
    }
}
