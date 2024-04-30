using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Society.Areas.Client.Controllers
{
    public class ContactSocietyClientController : Controller
    {
        private readonly ISocietyContactService _societyContactService;
        public ContactSocietyClientController(ISocietyContactService societyContactService)
        {
             _societyContactService = societyContactService;
        }
        public async Task<IActionResult> GetAllContact()
        {
            var data = _societyContactService.GetAllSocietyContact();
            return Ok(data);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id) 
        {
           _societyContactService.DeleteSocietyContact(id);
            return Ok();
        }
    }
}
