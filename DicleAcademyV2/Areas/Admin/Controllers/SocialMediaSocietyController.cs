using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaSocietyController : Controller
    {
        GenericRequests<SocialMediaDto> genericRequests = new GenericRequests<SocialMediaDto>();
        public IActionResult Index(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            return View();
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowSocialMedia(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            var data= await genericRequests.GetHttpRequest("SocialMediaSocietyClient/GetAll");
            return View(data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> AddSocialMedia(SocialMediaDto socialMedia)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                await genericRequests.PostRequestGeneric("SocialMediaSocietyClient/Add", socialMedia);
            return RedirectToAction("Index", "SocialMediaSociety" , new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateShowSocialMedia(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data=  await genericRequests.GetByIdGeneric("SocialMediaSocietyClient/GetById", id);
           return View("UpdateSocialMedia", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaDto socialMedia)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data=  await genericRequests.UpdateRequestGeneric("SocialMediaSocietyClient/Update", socialMedia);
            return RedirectToAction("ShowSocialMedia", "SocialMediaSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                string urlDelete = GenerateClient.Client.BaseAddress + "SocialMediaSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowSocialMedia", "SocialMediaSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
