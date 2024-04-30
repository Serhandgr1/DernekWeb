using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactAdminSocietyController : Controller
    {
        GenericRequests<SocietyContactAdminDto> genericRequests = new GenericRequests<SocietyContactAdminDto>();
        public IActionResult ShowContact(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
                return View("AddContactAdmin");
            }else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> ShowContactAdmin(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message=update;
            var data = await genericRequests.GetHttpRequest("ContactAdminSocietyClient/GetAll");
            List<SocietyContactAdminDto> contactAdminDto = new List<SocietyContactAdminDto>() {
                new SocietyContactAdminDto() { Id = 1, Address ="asdasdad" , Email="dasdqweqasd" , Phone="549684979156454"}

            };
            return View("ShowContactAdmin", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        [HttpPost]
        public async Task<IActionResult> AddContactAdmin(SocietyContactAdminDto contact)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                await genericRequests.PostRequestGeneric("ContactAdminSocietyClient/Add", contact);
                return RedirectToAction("ShowContact", "ContactAdminSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
            }
        public async Task<IActionResult> UpdateShowContactAdmin(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data =   await genericRequests.GetByIdGeneric("ContactAdminSocietyClient/GetById", id);
            SocietyContactAdminDto societyContactAdminDto=      new SocietyContactAdminDto() { Id = 1, Address = "asdasdad", Email = "dasdqweqasd", Phone = "549684979156454" };
            return View("UpdateContactAdmin", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> UpdateContactAdmin(SocietyContactAdminDto contact)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                await  genericRequests.UpdateRequestGeneric("ContactAdminSocietyClient/Update", contact);
            return RedirectToAction("ShowContactAdmin" , "ContactAdminSociety", new { update = "Başarılı"});
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteContactAdmin(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                string urlDelete = GenerateClient.Client.BaseAddress + "ContactAdminSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowContactAdmin", "ContactAdminSociety", new { update = "Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
