using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize (Roles ="Admin")]
    public class ContactAdminSocietyClientController : Controller
    {
         private readonly ISocietyContactAdminService _societyContactAdminService;
        private readonly ILogger<ContactAdminSocietyClientController> _logger;
        public ContactAdminSocietyClientController(ISocietyContactAdminService societyContactAdminService, ILogger<ContactAdminSocietyClientController> logger)
        {
            _societyContactAdminService = societyContactAdminService;
            _logger = logger;
        }
        
        public async Task<IActionResult> Add([FromBody] SocietyContactAdminDto societyContactAdmin)
        {
            _societyContactAdminService.CreateSocietyContactAdmin(societyContactAdmin);
            return Ok();
        }
        public async Task<List<SocietyContactAdminDto>> GetAll()
        {
            var data = _societyContactAdminService.GetAllSocietyContactAdmin().ToList();

            return data;
        }
        public async Task<SocietyContactAdminDto> GetById(int id)
        {
        var data=    _societyContactAdminService.GetByIdSocietyContactAdmin(id);
       
            return data;
        }
        public async Task<IActionResult> Update([FromBody] SocietyContactAdminDto societyContactAdmin)
        {
            try
            {
                _societyContactAdminService.UpdateSocietyContactAdmin(societyContactAdmin);
            return Ok();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            try {
                _societyContactAdminService.DeleteSocietyContactAdmin(id);
                return Ok();
            } catch (Exception ex) {

                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
           
        }
    }
}
