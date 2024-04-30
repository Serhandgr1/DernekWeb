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
        public OurTeamSocietyClientController(IOurTeamService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Add([FromBody]OurTeamDto ourTeam)
        {
            _service.CreateOurTeam(ourTeam);
            return Ok();
        }
        public async Task<List<OurTeamDto>> GetAll()
        {
           var data = _service.GetAllOurTeam().ToList();
            //List<OurTeamDto> team = new List<OurTeamDto>() {
            //    new OurTeamDto() {Id=6, Title="Jane Smith",Description="Executive director", Image="team-classic-1-390x252.jpg"},
            //     new OurTeamDto() {Id=6, Title="Albert Martinez",Description="Adoption program Director", Image="team-classic-2-390x252.jpg"},
            //      new OurTeamDto() {Id=6, Title="Ann Allen",Description="Educational program Director", Image="team-classic-3-390x252.jpg"}
            //};
            return data;
        }
        public async Task<OurTeamDto> GetById(int id)
        {
           var data = _service.GetByIdOurTeam(id);
            //OurTeamDto ourTeamDto = new OurTeamDto() { Id = 6, Title = "Jane Smith", Description = "Executive director", Image = "team-classic-1-390x252.jpg" };

            return data;
        }
        public async Task<IActionResult> Update([FromBody] OurTeamDto ourTeam)
        {
            _service.UpdateOurTeam(ourTeam);
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _service.DeleteOurTeam(id);
            return Ok();
        }
    }
}
