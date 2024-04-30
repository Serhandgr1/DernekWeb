using DicleAcademyV2;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Society.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LogoController : Controller
    {
        GenericRequests<LogoDto> genericRequests = new GenericRequests<LogoDto>();
        FileManagerAsycn FileManager = new FileManagerAsycn();
        public async Task<IActionResult> ShowLogo(string ? update)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                ViewBag.Message = update;
            var logo = await genericRequests.GetHttpRequest("LogoClient/GetAllLogo");
            var dto= logo.First();
            return View("LogoIndex", dto);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        public IActionResult UpdateShowLogo(LogoDto logoDto)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                return View("UpdateShowLogo",logoDto);
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateLogo(LogoDto logoDto)
        {
            if (GenerateClient.Client.DefaultRequestHeaders.Contains("Authorization"))
            {
                var logo = await genericRequests.GetHttpRequest("LogoClient/GetAllLogo");
          var dto=  logo.First();
                if (!string.IsNullOrEmpty(dto.Image)) {
                  string name = await  FileManager.UpdateFileAsycn(dto.Image, logoDto.formFile);
                  logoDto.Image = name;
                  logoDto.formFile = null;
                  await  genericRequests.UpdateRequestGeneric("LogoClient/UpdateLogo", logoDto);
                }
              return RedirectToAction("ShowLogo", "Logo", new { update="Başarılı"});
            }
            else { return RedirectToAction("ShowIndex", "Admin"); }
        }
    }
}
