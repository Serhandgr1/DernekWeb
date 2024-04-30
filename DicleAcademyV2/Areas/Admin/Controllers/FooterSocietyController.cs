using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FooterSocietyController : Controller
    {
        GenericRequests<SocialMediaDto> genericRequests = new GenericRequests<SocialMediaDto>();
        public IActionResult ShowSocial(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message=update;
            return View("AddSocialMedia");
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowSocialMedia(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            var data=  await  genericRequests.GetHttpRequest("FooterSocietyClient/GetAll");

            return View("ShowFooterSociety", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> AddFooter(SocialMediaDto socialMedia)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                await genericRequests.PostRequestGeneric("FooterSocietyClient/Add", socialMedia);
            return RedirectToAction("ShowSocial", "FooterSociety", new { update="Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateShowFooter(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data=  await genericRequests.GetByIdGeneric("FooterSocietyClient/GetById", id);
            return View("UpdateSocialMedia", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateFooter(SocialMediaDto socialMedia)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                await genericRequests.UpdateRequestGeneric("FooterSocietyClient/Update", socialMedia);
            return RedirectToAction("ShowSocialMedia", "FooterSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteFooter(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                string urlDelete = GenerateClient.Client.BaseAddress + "FooterSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowSocialMedia", "FooterSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
