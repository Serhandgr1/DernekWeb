using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize(Roles ="Admin")]
    public class SocialMediaSocietyClientController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        public SocialMediaSocietyClientController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public  async Task<IActionResult> Add([FromBody] SocialMediaDto socialMedia)
        {
            _socialMediaService.CreateSocialMedia(socialMedia);
            return Ok();
        }
        public async Task<List<SocialMediaDto>> GetAll()
        {
         var data=   _socialMediaService.GetAllSocialMedia().ToList();
            //List<SocialMediaDto> socialMediaDto = new List<SocialMediaDto>()
            //{
            //    new SocialMediaDto { Id = 1, Facebook="facebook.com", Twitter="x.com", Youtube="youtube.com", İnstagram="instagram.com"}
            //};
            return data;
        }
        public async Task<SocialMediaDto> GetById(int id)
        {
         var data=   _socialMediaService.GetByIdSocialMedia(id);
            //SocialMediaDto data = new SocialMediaDto { Id = 1, Facebook = "facebook.com", Twitter = "x.com", Youtube = "youtube.com", İnstagram = "instagram.com" };
            return data;
        }
        public async Task<IActionResult> Update([FromBody] SocialMediaDto socialMedia)
        {
            _socialMediaService.UpdateSocialMedia(socialMedia);
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _socialMediaService.DeleteSocialMedia(id);
            return Ok();
        }
    }
}
