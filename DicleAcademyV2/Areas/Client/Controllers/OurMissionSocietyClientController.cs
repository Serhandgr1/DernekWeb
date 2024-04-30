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
        private readonly ILogger<OurMissionSocietyClientController> _logger;
        public OurMissionSocietyClientController(IOurMissionService ourMissionService, ILogger<OurMissionSocietyClientController> logger)
        {
            _ourMissionService = ourMissionService;
            _logger = logger;
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
            return data;
        }
        public async Task<IActionResult> Update([FromBody] OurMissionDto ourMission)
        {
            try {
                _ourMissionService.UpdateOurMission(ourMission);
                return Ok();
            }  catch (Exception ex) {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _ourMissionService.DeleteOurMission(id);
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
