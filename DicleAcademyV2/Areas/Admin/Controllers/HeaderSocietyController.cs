using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeaderSocietyController : Controller
    {
        GenericRequests<SocietyHeaderDto> genericRequests = new GenericRequests<SocietyHeaderDto>();
        FileManagerAsycn FileManager = new FileManagerAsycn();
        public IActionResult ShowHeaderIndex(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message=update;
            return View("AddSocietyHeader");
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowHeader(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            var data = await   genericRequests.GetHttpRequest("HeaderSocietyClient/GetAll");
            return View(data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        [HttpPost]
        public async Task<IActionResult> AddHeader(SocietyHeaderDto societyHeader)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                if (societyHeader.formFile is not null) {
                string name=  await  FileManager.PostFileAsycn(societyHeader.formFile);
                societyHeader.formFile = null;
                societyHeader.Image = name;
            }
            await genericRequests.PostRequestGeneric("HeaderSocietyClient/Add",societyHeader);
            return RedirectToAction("ShowHeaderIndex", "HeaderSociety" , new { update ="Başarılı"});
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateShowHeader(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data =  await genericRequests.GetByIdGeneric("HeaderSocietyClient/GetById", id);
             return View("UpdateShowHeader", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateHeader(SocietyHeaderDto societyHeader)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetByIdGeneric("HeaderSocietyClient/GetById", societyHeader.Id);

            if (!string.IsNullOrEmpty(data.Image)&&societyHeader.formFile is not null) 
            {
                string name = await FileManager.UpdateFileAsycn(data.Image, societyHeader.formFile);
                societyHeader.Image=name;
                societyHeader.formFile = null;
            }
            await genericRequests.UpdateRequestGeneric("HeaderSocietyClient/Update", societyHeader);
            return RedirectToAction("ShowHeader", "HeaderSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteHeader(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var dto = await genericRequests.GetByIdGeneric("HeaderSocietyClient/GetById", id);
            if (!string.IsNullOrEmpty(dto.Image)) {
                 await FileManager.DeleteFileAsycn(dto.Image);
            }
            string urlDelete = GenerateClient.Client.BaseAddress + "HeaderSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowHeader", "HeaderSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
