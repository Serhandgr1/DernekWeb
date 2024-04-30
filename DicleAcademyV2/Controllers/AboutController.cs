using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Contracts;

namespace DicleAcademyV2.Controllers
{
    public class AboutController : Controller
    {
        private readonly INewAbouteService _aboute;
        private readonly IOurMissionService _missionService;
        private readonly IOurTeamService _ourTeamService;
        public AboutController(INewAbouteService aboute, IOurMissionService missionService, IOurTeamService ourTeamService)
        {
            _aboute = aboute;
            _missionService = missionService;
            _ourTeamService = ourTeamService;

        }
        public async Task<IActionResult> Index()
        {
            var aboutedto =  _aboute.GetAllAboutUs().ToList();
            var ourmissiondto=   _missionService.GetAllOurMission().ToList();
            var ourteamdto=   _ourTeamService.GetAllOurTeam().ToList();
            return View(Tuple.Create(aboutedto, ourmissiondto, ourteamdto));
        }
    }
}
