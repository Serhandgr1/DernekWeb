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
        public AboutSocietyClientController(INewAbouteService aboute)
        {
            _aboute = aboute;
        }
        public IActionResult Add([FromBody] AbouteDto abouteDto)
        {
            _aboute.CreateAboutUs(abouteDto);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        public List<AbouteDto> GetAll()
        {
            var data = _aboute.GetAllAboutUs().ToList();
            return data;
        }
        [Authorize(Roles = "Admin")]
        public AbouteDto GetById(int id)
        {
            var data=   _aboute.GetByIdAboutUs(id);
            return data;
        }
        public IActionResult Update([FromBody] AbouteDto abouteDto)
        {
           _aboute.UpdateAboutUs(abouteDto);
            return Ok();
        }
        public IActionResult Delete(int id)
        {  
            _aboute.DeleteAboutUs(id);
            return Ok();
        }
    }
}
