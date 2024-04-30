using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize (Roles ="Admin")]
    public class OurTeamSocietyClientController : Controller
    {
        private readonly IOurTeamService _service;
        private readonly ILogger<OurTeamSocietyClientController> _logger;
        public OurTeamSocietyClientController(IOurTeamService service, ILogger<OurTeamSocietyClientController> logger)
        {
            _service = service;
            _logger = logger;
        }
        public async Task<IActionResult> Add([FromBody]OurTeamDto ourTeam)
        {
            _service.CreateOurTeam(ourTeam);
            return Ok();
        }
        public async Task<List<OurTeamDto>> GetAll()
        {
           var data = _service.GetAllOurTeam().ToList();
            return data;
        }
        public async Task<OurTeamDto> GetById(int id)
        {
           var data = _service.GetByIdOurTeam(id);
            return data;
        }
        public async Task<IActionResult> Update([FromBody] OurTeamDto ourTeam)
        {

            try {

                _service.UpdateOurTeam(ourTeam);
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
                _service.DeleteOurTeam(id);
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
