using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TempusHiring.Common;

namespace TempusHiring.Presentation.Controllers
{
    [Authorize(Policy = ClaimRoles.Admin)]
    public class AdminController : Controller
    {
    }
}
