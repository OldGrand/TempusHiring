using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;

namespace TempusHiring.Presentation.Controllers
{
    [Route("Admin/[controller]/[action]")]
    [Authorize(Policy = ClaimRoles.Admin)]
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
        
    }
}
