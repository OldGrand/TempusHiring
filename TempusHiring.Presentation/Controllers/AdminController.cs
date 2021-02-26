using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Services.Interfaces;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IMechanismService _mechanismService;
        private readonly IPhotoService _photoService;
        private readonly IStrapMaterialService _strapMaterialService;
        private readonly IStrapService _strapService;
        private readonly IMapper _mapper;

        private const string CURRENT_CONTROLLER_NAME = "Admin";
        
        public AdminController(IWristSizeService wristSizeService, 
            IMechanismService mechanismService, 
           IPhotoService photoService, 
           IStrapMaterialService strapMaterialService, 
           IStrapService strapService,
           IMapper mapper)
        {
            _mechanismService = mechanismService;
            _photoService = photoService;
            _strapMaterialService = strapMaterialService;
            _strapService = strapService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
