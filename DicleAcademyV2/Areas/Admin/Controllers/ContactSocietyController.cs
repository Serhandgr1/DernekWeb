using DicleAcademyV2;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;

namespace Society.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactSocietyController : Controller
    {
        GenericRequests<SocietyContactDto> genericRequests = new GenericRequests<SocietyContactDto>();
        public async  Task<IActionResult> ShowMessage(string? delete)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var data = await genericRequests.GetHttpRequest("ContactSocietyClient/GetAllContact");
                ViewBag.Message = delete;
                return View("ShowMessage", data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteMessage(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                string urlDelete = GenerateClient.Client.BaseAddress + "ContactSocietyClient/DeleteContact";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowMessage", "ContactSociety", new { delete="Başarılı"});
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
