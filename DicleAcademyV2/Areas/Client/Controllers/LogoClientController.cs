using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Society.Areas.Client.Controllers
{
    public class LogoClientController : Controller
    {
        private readonly ILogoService _logoService;
        private readonly ILogger<LogoClientController> _logger;
        public LogoClientController(ILogoService logoService, ILogger<LogoClientController> logger)
        {
            _logoService = logoService;
            _logger = logger;
        }
        public async Task<IActionResult> GetAllLogo()
        {
            var data = await  _logoService.GetAllLogo();
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLogo([FromBody] LogoDto logoDto) 
        {
            try {
                await _logoService.UpdateLogo(logoDto);
                return Ok();
            } catch (Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

            
        }

    }
}
