using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LatestCausesSocietyController : Controller
    {
        GenericRequests<LatestCausesDto> genericRequests = new GenericRequests<LatestCausesDto>();
        FileManagerAsycn FileManager = new FileManagerAsycn();
        public IActionResult ShowLatest(string? update)
        {// ekele ekranı 
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            return View("AddLatestCauses");
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowLatestCauses(string? update)
        {// tüm verileri getirir gösterir
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            var data=  await genericRequests.GetHttpRequest("LatestCausesSocietyClient/GetAll");
            return View(data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        [HttpPost]
        public async Task<IActionResult> AddLatestCauses(LatestCausesDto latestCauses)
        {// price ondalıklı sorun var kt
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                if (latestCauses.formFile is not null) {
                string name =await  FileManager.PostFileAsycn(latestCauses.formFile);
                latestCauses.formFile = null;
                latestCauses.Image = name;
                }
                var data = await genericRequests.PostRequestGeneric("LatestCausesSocietyClient/Add", latestCauses);
                return RedirectToAction("ShowLatest", "LatestCausesSociety", new { update = "Başarılı" });
                
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }

        }
        public async Task<IActionResult> UpdateShowLatestCauses(int id)
        {// veriyi getirir update ekranına basar
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data=  await  genericRequests.GetByIdGeneric("LatestCausesSocietyClient/GetById", id);
            return View("UpdateLatestCauses", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateLatestCauses(LatestCausesDto latestCauses)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetByIdGeneric("LatestCausesSocietyClient/GetById", latestCauses.Id);

            if (!string.IsNullOrEmpty(data.Image)&&latestCauses.formFile is not null) 
            {
                string name = await FileManager.UpdateFileAsycn(data.Image, latestCauses.formFile);
                latestCauses.Image=name;
                latestCauses.formFile = null;
            }
            var res=await genericRequests.UpdateRequestGeneric("LatestCausesSocietyClient/Update", latestCauses);
            return RedirectToAction("ShowLatestCauses", "LatestCausesSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteLatestCauses(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var dto = await genericRequests.GetByIdGeneric("LatestCausesSocietyClient/GetById", id);
            if (!string.IsNullOrEmpty(dto.Image)) {
               await FileManager.DeleteFileAsycn(dto.Image);
            }
            string urlDelete = GenerateClient.Client.BaseAddress + "LatestCausesSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowLatestCauses", "LatestCausesSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
