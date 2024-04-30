using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Society.Areas.Client.Controllers
{
    public class ContactSocietyClientController : Controller
    {
        private readonly ISocietyContactService _societyContactService;
        private readonly ILogger<ContactSocietyClientController> _logger;
        public ContactSocietyClientController(ISocietyContactService societyContactService, ILogger<ContactSocietyClientController> logger)
        {
             _societyContactService = societyContactService;
            _logger = logger;
        }
        public async Task<IActionResult> GetAllContact()
        {
            var data = _societyContactService.GetAllSocietyContact();
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try {
                _societyContactService.DeleteSocietyContact(id);
                return Ok();
            } catch (Exception ex){
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
          
        }
    }
}
