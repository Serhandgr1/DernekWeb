using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OurMissionSocietyController : Controller
    {
        GenericRequests<OurMissionDto> genericRequests = new GenericRequests<OurMissionDto>();
        FileManagerAsycn FileManager = new FileManagerAsycn();
        public IActionResult ShowOurMissionIndex(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            return View("AddOurMission");
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowOurMission(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            var data =  await  genericRequests.GetHttpRequest("OurMissionSocietyClient/GetAll");
            return View(data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> AddOurMission(OurMissionDto ourMission)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                if (ourMission.formFile is not null) {
              var name=  await FileManager.PostFileAsycn(ourMission.formFile);
                ourMission.Image = name;
                ourMission.formFile = null;
            }
            if (ourMission.skillFile is not null)
            {
                var name = await FileManager.PostFileAsycn(ourMission.skillFile);
                ourMission.SkillImage = name;
                ourMission.skillFile = null;
            }

            var data= await  genericRequests.PostRequestGeneric("OurMissionSocietyClient/Add", ourMission);
            return RedirectToAction("ShowOurMission", "OurMissionSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateShowOurMission(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetByIdGeneric("OurMissionSocietyClient/GetById", id);
            return View("UpdateOurMission", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateOurMission(OurMissionDto ourMission)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetByIdGeneric("OurMissionSocietyClient/GetById", ourMission.Id);

            if (!string.IsNullOrEmpty(data.Image)) {
                var name = await FileManager.UpdateFileAsycn(data.Image, ourMission.formFile);
                ourMission.Image=name;
                ourMission.formFile = null;
            }else if(ourMission.formFile is not null)
            {
               string name = await FileManager.PostFileAsycn(ourMission.formFile);
                ourMission.Image = name;
                ourMission.formFile = null;
            }
            if (!string.IsNullOrEmpty(data.SkillImage)) {
                var name = await FileManager.UpdateFileAsycn(data.SkillImage, ourMission.skillFile);
                ourMission.SkillImage = name;
                ourMission.skillFile = null;
            }
            else if(ourMission.skillFile is not null)
            {
                string name = await FileManager.PostFileAsycn(ourMission.skillFile);
                ourMission.SkillImage = name;
                ourMission.skillFile = null;
            }
           await genericRequests.UpdateRequestGeneric("OurMissionSocietyClient/Update", ourMission);
            return RedirectToAction("ShowOurMission", "OurMissionSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteOurMission(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var dto = await genericRequests.GetByIdGeneric("OurMissionSocietyClient/GetById", id);
            if (!string.IsNullOrEmpty(dto.Image))
            {
                await FileManager.DeleteFileAsycn(dto.Image);
            }
            if (!string.IsNullOrEmpty(dto.SkillImage)) {
                await FileManager.DeleteFileAsycn(dto.SkillImage);
            }
            string urlDelete = GenerateClient.Client.BaseAddress + "OurMissionSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowOurMission", "OurMissionSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
