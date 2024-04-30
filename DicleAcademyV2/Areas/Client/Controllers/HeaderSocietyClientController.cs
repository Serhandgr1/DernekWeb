using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize (Roles="Admin")]
    public class HeaderSocietyClientController : Controller
    {

        private readonly ISocietyHeaderService _societyHeaderService;
        private readonly ILogger<HeaderSocietyClientController> _logger;
        public HeaderSocietyClientController(ISocietyHeaderService societyHeaderService, ILogger<HeaderSocietyClientController> logger)
        {
            _societyHeaderService = societyHeaderService;
            _logger = logger;

        }
        public IActionResult Add([FromBody]SocietyHeaderDto societyHeader)
        {
            _societyHeaderService.CreateSocietyHeader(societyHeader);
            return Ok();
        }
        public async Task<List<SocietyHeaderDto>> GetAll()
        {
        var data= _societyHeaderService.GetAllSocietyHeader().ToList();
            return data;
        }
        public async Task<SocietyHeaderDto> GetById(int id)
        {
          var data =  _societyHeaderService.GetByIdSocietyHeader(id);
            return data;
        }
        public async Task<IActionResult> Update([FromBody] SocietyHeaderDto societyHeader)
        {
            try {
                _societyHeaderService.UpdateSocietyHeader(societyHeader);
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
                _societyHeaderService.DeleteSocietyHeader(id);
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
