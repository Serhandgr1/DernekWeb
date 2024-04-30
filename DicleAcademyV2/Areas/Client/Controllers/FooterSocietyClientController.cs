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
        private readonly ILogger<FooterSocietyClientController> _logger;
        public FooterSocietyClientController(ISocialMediaService socialMediaService, ILogger<FooterSocietyClientController> logger)
        {
            _socialMediaService = socialMediaService;
            _logger = logger;

        }
        public IActionResult Add([FromBody] SocialMediaDto socialMediaDto)
        {
            _socialMediaService.CreateSocialMedia(socialMediaDto);
            return Ok();
        }
        public List<SocialMediaDto> GetAll()
        {
          var data =  _socialMediaService.GetAllSocialMedia().ToList();
            return data;
        }
        public SocialMediaDto GetById(int id)
        {
         var data=   _socialMediaService.GetByIdSocialMedia(id);
            return data;
        }
        public IActionResult Update([FromBody] SocialMediaDto socialMediaDto)
        { try {
                _socialMediaService.UpdateSocialMedia(socialMediaDto);
                return Ok();
            } catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _socialMediaService.DeleteSocialMedia(id);
            return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
