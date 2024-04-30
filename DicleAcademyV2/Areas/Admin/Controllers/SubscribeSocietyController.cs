using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DicleAcademyV2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribeSocietyController : Controller
    {
        GenericRequests<SubscribeDto> genericRequests = new GenericRequests<SubscribeDto>();
        public async Task<IActionResult> ShowSubscribe(string? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message=update;
            var data = await  genericRequests.GetHttpRequest("SubscribeSocietyClient/GetAll");
            return View(data);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                string urlDelete = GenerateClient.Client.BaseAddress + "SubscribeSocietyClient/Delete";
            var data = await GenerateClient.Client.DeleteAsync($"{urlDelete}?id={id}");
            return RedirectToAction("ShowSubscribe", "SubscribeSociety", new { update="Başarılı" });
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
