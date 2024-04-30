using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Society.Areas.Client.Controllers
{
    public class LogoClientController : Controller
    {
        private readonly ILogoService _logoService;
        public LogoClientController(ILogoService logoService)
        {
            _logoService = logoService; 
        }
        public async Task<IActionResult> GetAllLogo()
        {
            var data = await  _logoService.GetAllLogo();
            return Ok(data);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLogo([FromBody] LogoDto logoDto) 
        {
            await _logoService.UpdateLogo(logoDto);
            return Ok();
        }

    }
}
