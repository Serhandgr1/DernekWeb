using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize(Roles ="Admin")]
    public class OurMissionSocietyClientController : Controller
    {
        private readonly IOurMissionService _ourMissionService;
        public OurMissionSocietyClientController(IOurMissionService ourMissionService)
        {
            _ourMissionService = ourMissionService;
        }
        public async Task<IActionResult> Add([FromBody]OurMissionDto ourMission)
        {
            _ourMissionService.CreateOurMission(ourMission);
            return Ok();
        }
        public async Task<List<OurMissionDto>> GetAll()
        {
         var data=    _ourMissionService.GetAllOurMission().ToList();
            //List<OurMissionDto> ourMissionDto = new List<OurMissionDto>()
            //{
            //    new OurMissionDto() {Id=2,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." },
            // new OurMissionDto() {Id=3,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." },
            //  new OurMissionDto() {Id=4,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." },
            // new OurMissionDto() {Id=5,SkillImage="",SkillDescription= "Our main mission is to save and rescue permanently displaced children." , Image = "animate-img-1.jpg", Description = "Our organization pursues several goals that can be identified as our mission. Learn more about them below." }

            //};
            return data;
        }
        public async Task<OurMissionDto> GetById(int id)
        {
          var data =  _ourMissionService.GetByIdOurMission(id);
            //OurMissionDto ourMissionDto = new OurMissionDto();
            //ourMissionDto.Id = id;
            //ourMissionDto.SkillTitle = "asd";
            //ourMissionDto.SkillImage = "asd";
            //ourMissionDto.SkillDescription = "qweqwe";
            //ourMissionDto.Description = "qweqwe";
            //ourMissionDto.Image = "qweqwe";
            return data;
        }
        public async Task<IActionResult> Update([FromBody] OurMissionDto ourMission)
        {
            _ourMissionService.UpdateOurMission(ourMission);
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _ourMissionService.DeleteOurMission(id);
            return Ok();
        }
    }
}
