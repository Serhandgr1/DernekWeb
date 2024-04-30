using Entities.Models;
using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LatestCausesSocietyClientController : Controller
    {
        private readonly ILatestCausesService _latestCausesService;
        private readonly ILogger<LatestCausesSocietyClientController> _logger;

        public LatestCausesSocietyClientController(ILatestCausesService latestCausesService, ILogger<LatestCausesSocietyClientController> logger)
        {
            _latestCausesService = latestCausesService;
            _logger = logger;
        }

        public async Task<IActionResult> Add([FromBody]LatestCausesDto latestCauses)
        {
            _latestCausesService.CreateLatestCauses(latestCauses);
            return Ok();
        }
        public async Task<List<LatestCausesDto>> GetAll()
        {
         var data=   _latestCausesService.GetAllLatestCauses().ToList();
            return data;
        }
        public async Task<LatestCausesDto> GetById(int id)
        {   var data = _latestCausesService.GetByIdLatestCauses(id);
            return data;
        }
        public async Task<IActionResult> Update([FromBody] LatestCausesDto latestCauses)
        {
            try
            {
                _latestCausesService.UpdateLatestCauses(latestCauses);
                return Ok();
            } catch (Exception ex) { 
                _logger.LogError(ex.Message); 
                return BadRequest(ex.Message); 
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _latestCausesService.DeleteLatestCauses(id);
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
