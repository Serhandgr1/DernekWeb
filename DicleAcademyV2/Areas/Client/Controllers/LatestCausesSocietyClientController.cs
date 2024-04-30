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

        public LatestCausesSocietyClientController(ILatestCausesService latestCausesService)
        {
            _latestCausesService = latestCausesService;
        }

        public async Task<IActionResult> Add([FromBody]LatestCausesDto latestCauses)
        {
            _latestCausesService.CreateLatestCauses(latestCauses);
            return Ok();
        }
        public async Task<List<LatestCausesDto>> GetAll()
        {
         var data=   _latestCausesService.GetAllLatestCauses().ToList();
            //List<LatestCausesDto> latestCausesDto = new List<LatestCausesDto>() { new LatestCausesDto() { Id = 3, Price = 92, Title = "Recycling for Charity", Description = "At Helper, there are various charity causes and projects, in which you can always take part. Feel free to learn about them below or browse our website for more information.", Image = "causes-02-372x396.jpg" } };

            return data;
        }
        public async Task<LatestCausesDto> GetById(int id)
        {   var data = _latestCausesService.GetByIdLatestCauses(id);
            //LatestCausesDto latestCausesDto = new LatestCausesDto() { Id = 3, Price = 92, Title = "Recycling for Charity", Description = "At Helper, there are various charity causes and projects, in which you can always take part. Feel free to learn about them below or browse our website for more information.", Image = "causes-02-372x396.jpg" };

            return data;
        }
        public async Task<IActionResult> Update([FromBody] LatestCausesDto latestCauses)
        {
            _latestCausesService.UpdateLatestCauses(latestCauses);
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _latestCausesService.DeleteLatestCauses(id);
            return Ok();
        }
    }
}
