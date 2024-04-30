using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Controllers
{
    public class ContactSocietyController : Controller
    {
        private readonly ISocietyContactAdminService _contactAdminService;
        private readonly ISocietyContactService _contactService;
        public ContactSocietyController(ISocietyContactAdminService contactAdminService, ISocietyContactService contactService)
        {
            _contactAdminService = contactAdminService;
            _contactService = contactService;
        }
        public IActionResult Index(string? post)
        {
            ViewBag.Message = post;
            var data=_contactAdminService.GetAllSocietyContactAdmin().ToList();
            return View(Tuple.Create(data));
        }
        public IActionResult PostMessage(SocietyContactDto societyContactDto) 
        {
            _contactService.CreateSocietyContact(societyContactDto);
            return RedirectToAction("Index", "ContactSociety",new { post= "Başarılı" });
        }
    }
}
