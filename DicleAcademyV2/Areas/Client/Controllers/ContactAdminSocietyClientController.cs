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
        public ContactAdminSocietyClientController(ISocietyContactAdminService societyContactAdminService)
        {
            _societyContactAdminService = societyContactAdminService;
        }
        
        public async Task<IActionResult> Add([FromBody] SocietyContactAdminDto societyContactAdmin)
        {
            _societyContactAdminService.CreateSocietyContactAdmin(societyContactAdmin);
            return Ok();
        }
        public async Task<List<SocietyContactAdminDto>> GetAll()
        {
         var data=   _societyContactAdminService.GetAllSocietyContactAdmin().ToList();
            //List<SocietyContactAdminDto> contactAdminDto = new List<SocietyContactAdminDto>() {
            //    new SocietyContactAdminDto() { Id = 1, Address ="asdasdad" , Email="dasdqweqasd" , Phone="549684979156454"}

            //};

            return data;
        }
        public async Task<SocietyContactAdminDto> GetById(int id)
        {
        var data=    _societyContactAdminService.GetByIdSocietyContactAdmin(id);
            //SocietyContactAdminDto data = new SocietyContactAdminDto() { Id = 1, Address = "asdasdad", Email = "dasdqweqasd", Phone = "549684979156454" };

            return data;
        }
        public async Task<IActionResult> Update([FromBody] SocietyContactAdminDto societyContactAdmin)
        {
            _societyContactAdminService.UpdateSocietyContactAdmin(societyContactAdmin);
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _societyContactAdminService.DeleteSocietyContactAdmin(id);
            return Ok();
        }
    }
}
