using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Controllers
{
    public class FooterController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        public FooterController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public IActionResult Index()
        {
          var data =  _socialMediaService.GetAllSocialMedia().ToList().First();
            return PartialView(data);
        }
      
    }
}
