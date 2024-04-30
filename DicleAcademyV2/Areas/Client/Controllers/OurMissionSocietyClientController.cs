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
