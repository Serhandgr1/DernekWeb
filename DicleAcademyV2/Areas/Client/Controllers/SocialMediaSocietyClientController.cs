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
        private readonly ILogger<SocialMediaSocietyClientController> _logger;
        public SocialMediaSocietyClientController(ISocialMediaService socialMediaService, ILogger<SocialMediaSocietyClientController> logger)
        {
            _socialMediaService = socialMediaService;
            _logger = logger;
        }
        public  async Task<IActionResult> Add([FromBody] SocialMediaDto socialMedia)
        {
            _socialMediaService.CreateSocialMedia(socialMedia);
            return Ok();
        }
        public async Task<List<SocialMediaDto>> GetAll()
        {
         var data=   _socialMediaService.GetAllSocialMedia().ToList();
            return data;
        }
        public async Task<SocialMediaDto> GetById(int id)
        {
         var data=   _socialMediaService.GetByIdSocialMedia(id);
           return data;
        }
        public async Task<IActionResult> Update([FromBody] SocialMediaDto socialMedia)
        {
            try {
                _socialMediaService.UpdateSocialMedia(socialMedia);
                return Ok();
            } catch (Exception ex){
                _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
            }
            
        }
        public async Task<IActionResult> Delete(int id)
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
