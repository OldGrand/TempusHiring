using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Services.Interfaces;

namespace TempusHiring.Presentation.Controllers
{
    //[Authorize(Policy = ClaimRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IPhotoService _photoService;
        private readonly IStrapService _strapService;
        
        public AdminController(IPhotoService photoService, IStrapService strapService)
        {
            _photoService = photoService;
            _strapService = strapService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
