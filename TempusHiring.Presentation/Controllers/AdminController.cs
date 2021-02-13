using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.BusinessLogic.Services.Interfaces;
using TempusHiring.Common;

namespace TempusHiring.Presentation.Controllers
{
    [Authorize(Policy = ClaimRoles.Admin)]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
    }
}
