using Entities.ModelsDto;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;
using System.Reflection.Metadata;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DicleAcademyV2.Controllers
{
    public class HomeIndexController : Controller
    {
        private readonly ILatestCausesService _latestCausesService;
        private readonly ISocietyHeaderService _societyHeaderService;
        private readonly IOurMissionService _missionService;
        private readonly ISubscribeService _subscribeService;
        private readonly ILogoService _logoService;
        public HomeIndexController(ILogoService logoService, IOurMissionService missionService, ISocietyHeaderService societyHeaderService, ILatestCausesService latestCausesService, ISubscribeService subscribeService)
        {
            _logoService = logoService;
            _missionService = missionService;
            _societyHeaderService = societyHeaderService;
            _latestCausesService = latestCausesService;
            _subscribeService = subscribeService;

        }
        public IActionResult Index(string? update)
        {//header Our Mission Latest Causes Subscribe?
            ViewBag.Message = update;
            var headerdto = _societyHeaderService.GetAllSocietyHeader().ToList().First();
           
            var ourmissiondto = _missionService.GetAllOurMission().ToList();
           var latestdto= _latestCausesService.GetAllLatestCauses().ToList();
           
            return View(Tuple.Create(headerdto, ourmissiondto, latestdto));
        }
        public async Task<IActionResult> HeaderIndex()
        {
            var logo=  await _logoService.GetAllLogo();
           var dto= logo.First();
            return PartialView("HeaderIndex", dto);
        }
        public IActionResult AddSub(SubscribeDto subscribeDto)
        {
            _subscribeService.CreateSubscribe(subscribeDto);
            return RedirectToAction("Index", "HomeIndex",new { update="Başarılı" });

        }
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
              CookieRequestCultureProvider.DefaultCookieName,
              CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
              new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
              );
            //return RedirectToAction("Index");
            return LocalRedirect(returnUrl);
        }
    }
}
