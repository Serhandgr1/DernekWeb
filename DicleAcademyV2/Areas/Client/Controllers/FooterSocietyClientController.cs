using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize(Roles ="Admin")]
    public class FooterSocietyClientController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        public FooterSocietyClientController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        public IActionResult Add([FromBody] SocialMediaDto socialMediaDto)
        {
            _socialMediaService.CreateSocialMedia(socialMediaDto);
            return Ok();
        }
        public List<SocialMediaDto> GetAll()
        {
          var data =  _socialMediaService.GetAllSocialMedia().ToList();
            //List<SocialMediaDto> socialMedia = new List<SocialMediaDto>() {
            //    new SocialMediaDto() { Id = 1, Facebook ="asdasd", Twitter="asdasd", Youtube="asdasd", İnstagram="asdasd"}
            //     };
            return data;
        }
        public SocialMediaDto GetById(int id)
        {
         var data=   _socialMediaService.GetByIdSocialMedia(id);
            //SocialMediaDto socialMediaDto = new SocialMediaDto() { Id = 1, Facebook = "asdasd", Twitter = "asdasd", Youtube = "asdasd", İnstagram = "asdasd" };

            return data;
        }
        public IActionResult Update([FromBody] SocialMediaDto socialMediaDto)
        {
            _socialMediaService.UpdateSocialMedia(socialMediaDto);
            return Ok();
        }
        public IActionResult Delete(int id)
        { 
            _socialMediaService.DeleteSocialMedia(id);
            return Ok();
        }
    }
}
