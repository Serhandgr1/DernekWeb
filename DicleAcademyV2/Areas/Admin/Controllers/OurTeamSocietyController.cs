using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OurTeamSocietyController : Controller
    {
        GenericRequests<OurTeamDto> genericRequests = new GenericRequests<OurTeamDto>();
        FileManagerAsycn FileManager = new FileManagerAsycn();
        public IActionResult ShowOurTeamIndex(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            return View("AddOurTeam");
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowOurTeam(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            var data =  await genericRequests.GetHttpRequest("OurTeamSocietyClient/GetAll");
            return View("ShowOurTeam", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> AddOurTeam(OurTeamDto ourTeam)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                if (ourTeam.formFile is not null) {
                string name =  await FileManager.PostFileAsycn(ourTeam.formFile);
                ourTeam.Image = name;
                ourTeam.formFile = null;
            }
            var data=  await genericRequests.PostRequestGeneric("OurTeamSocietyClient/Add", ourTeam);
            return RedirectToAction("ShowOurTeamIndex", "OurTeamSociety", new { update ="Başarılı"});
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateShowOurTeam(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await  genericRequests.GetByIdGeneric("OurTeamSocietyClient/GetById", id);  
            return View("UpdateOurTeam", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateOurTeam(OurTeamDto ourTeam)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetByIdGeneric("OurTeamSocietyClient/GetById", ourTeam.Id);
            if (!string.IsNullOrEmpty(data.Image) && ourTeam.formFile is not null) {
               string name = await FileManager.UpdateFileAsycn(data.Image,ourTeam.formFile);
                ourTeam.Image=name;
                ourTeam.formFile = null;
            }else if (ourTeam.formFile is not null) {
               string name= await FileManager.PostFileAsycn(ourTeam.formFile);
                ourTeam.Image = name;
                ourTeam.formFile = null;
            }
            await genericRequests.UpdateRequestGeneric("OurTeamSocietyClient/Update", ourTeam);
            return RedirectToAction("ShowOurTeam", "OurTeamSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteOurTeam(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var dto = await genericRequests.GetByIdGeneric("OurTeamSocietyClient/GetById", id);
            if (!string.IsNullOrEmpty(dto.Image)){
                await FileManager.DeleteFileAsycn(dto.Image);
            }
            string urlDelete = GenerateClient.Client.BaseAddress + "OurTeamSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowOurTeam", "OurTeamSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
