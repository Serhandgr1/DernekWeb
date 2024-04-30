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
        public HeaderSocietyClientController(ISocietyHeaderService societyHeaderService)
        {
            _societyHeaderService = societyHeaderService;
        }
        public IActionResult Add([FromBody]SocietyHeaderDto societyHeader)
        {
            _societyHeaderService.CreateSocietyHeader(societyHeader);
            return Ok();
        }
        public async Task<List<SocietyHeaderDto>> GetAll()
        {
        var data= _societyHeaderService.GetAllSocietyHeader().ToList();
        //    List<SocietyHeaderDto> societyHeaderDto = new List<SocietyHeaderDto>()
        //    {
        //    new SocietyHeaderDto(){Title ="Help The Children",Id=1,Description="We do whatever it takes to make sure children don’t just survive but thrive. Helper believes that every child should be able to make their mark on their world and help build a better future.",Image="~/society/images/bg-bunner-2.jpg"}
        //};
            return data;
        }
        public async Task<SocietyHeaderDto> GetById(int id)
        {
          var data =  _societyHeaderService.GetByIdSocietyHeader(id);
            //SocietyHeaderDto societyHeaderDto = new SocietyHeaderDto() { Title = "Help The Children", Id = 1, Description = "We do whatever it takes to make sure children don’t just survive but thrive. Helper believes that every child should be able to make their mark on their world and help build a better future.", Image = "~/society/images/bg-bunner-2.jpg" };

            return data;
        }
        public async Task<IActionResult> Update([FromBody] SocietyHeaderDto societyHeader)
        {
            _societyHeaderService.UpdateSocietyHeader(societyHeader);
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            _societyHeaderService.DeleteSocietyHeader(id);
            return Ok();
        }
    }
}
