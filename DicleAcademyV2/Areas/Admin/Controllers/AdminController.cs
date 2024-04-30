using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public AdminController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

 
        public IActionResult ShowIndex()
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                return View("Index");
            }
            else { return RedirectToAction("Login", "User"); }
        }
        public async Task<IActionResult> UserCheck(UserForAuthenticationDto user)
        {

            bool isAvailableUser = await _authenticationService.ValidateUser(user);
            if (isAvailableUser)
            {
                TokenDto token = await _authenticationService.CreateToken(isAvailableUser);
                if (token is not null)
                {
                    GenerateClient.Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.AccessToken);
                    ClientTokenDto.AccessToken = token.AccessToken;
                    ClientTokenDto.RefreshToken = token.RefreshToken;
                    return RedirectToAction("ShowIndex", "Admin");
                }
                else
                    return RedirectToAction("Login", "User");
            }
            else return RedirectToAction("Login", "User");

        }
        public IActionResult SignIn()
        {
            return RedirectToAction("Login", "User");
        }

        public IActionResult LogOut()
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                GenerateClient.Client.DefaultRequestHeaders.Remove("Authorization");
            }
            return RedirectToAction("Login", "User");
        }
      




    }
}
