using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AboutSocietyClientController : Controller
    {
        private readonly INewAbouteService _aboute;
        private readonly ILogger<AboutSocietyClientController> _logger;
        public AboutSocietyClientController(INewAbouteService aboute, ILogger<AboutSocietyClientController> logger)
        {
            _aboute = aboute;
            _logger = logger;

        }
        public IActionResult Add([FromBody] AbouteDto abouteDto)
        {
            _aboute.CreateAboutUs(abouteDto);
            return Ok();
        }
        public List<AbouteDto> GetAll()
        {
            var data = _aboute.GetAllAboutUs().ToList();
            return data;
        }
        public AbouteDto GetById(int id)
        {
            var data=   _aboute.GetByIdAboutUs(id);
            return data;
        }
        public IActionResult Update([FromBody] AbouteDto abouteDto)
        { try {
                _aboute.UpdateAboutUs(abouteDto);
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
                _aboute.DeleteAboutUs(id);
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
