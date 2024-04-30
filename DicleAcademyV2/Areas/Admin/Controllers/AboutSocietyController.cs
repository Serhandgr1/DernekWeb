using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutSocietyController : Controller
    {
       
        GenericRequests<AbouteDto> genericRequests = new GenericRequests<AbouteDto>();
        FileManagerAsycn FileManager = new FileManagerAsycn();
        public IActionResult ShowIndex(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
                return View("AddAboutSociety");
            }else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowAboute(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
                var data = await genericRequests.GetHttpRequest("AboutSocietyClient/GetAll");
                return View("ShowAboutSociety", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        [HttpPost]
        public async Task<IActionResult> AddAboute(AbouteDto abouteDto)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                if (abouteDto.formFile is not null)
                {
                    string name = await FileManager.PostFileAsycn(abouteDto.formFile);
                    abouteDto.Image = name;
                    abouteDto.formFile = null;
                }
                var data = await genericRequests.PostRequestGeneric("AboutSocietyClient/Add", abouteDto);
                return RedirectToAction("ShowIndex", "AboutSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateShowAboute(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetByIdGeneric("AboutSocietyClient/GetById", id);
            return View("UpdateAboutSociety", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateAboute(AbouteDto abouteDto)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetByIdGeneric("AboutSocietyClient/GetById", abouteDto.Id);
            if (!string.IsNullOrEmpty(data.Image)&&abouteDto.formFile is not null)
            {
                string name= await FileManager.UpdateFileAsycn(data.Image, abouteDto.formFile);
                abouteDto.Image= name;
                abouteDto.formFile = null;
            }
            var message = await genericRequests.UpdateRequestGeneric("AboutSocietyClient/Update", abouteDto);
            return RedirectToAction("ShowAboute", "AboutSociety",new { update = "Başarılı"});
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteAboute(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var dto = await genericRequests.GetByIdGeneric("AboutSocietyClient/GetById", id);
                if (dto.Image is not null)
                {
                    await FileManager.DeleteFileAsycn(dto.Image);
                }
                string urlDelete = GenerateClient.Client.BaseAddress + "AboutSocietyClient/Delete";
                var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");

                return RedirectToAction("ShowAboute", "AboutSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
