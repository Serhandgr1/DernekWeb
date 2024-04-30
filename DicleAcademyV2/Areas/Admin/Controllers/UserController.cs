using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Security.Policy;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {

        private readonly IAuthenticationService _authenticationService;
        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login()
        {
            if (!GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                return View();
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
