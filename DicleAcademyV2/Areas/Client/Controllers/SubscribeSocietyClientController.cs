using Entities.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.EFCore;

namespace DicleAcademyV2.Areas.Client.Controllers
{
    [Authorize (Roles ="Admin")]
    public class SubscribeSocietyClientController : Controller
    {
        private readonly ISubscribeService _subscribeService;
        public SubscribeSocietyClientController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }
        public async Task<List<SubscribeDto>> GetAll()
        {
          var data =  _subscribeService.GetAllSubscribe().ToList();


            //List<SubscribeDto> subscriptions = new List<SubscribeDto>() {
            //new SubscribeDto () { Id = 1, ClientMail="dogruserhanayberk@gmail.com"}
            //};
            return data;
        }
        public  async Task<IActionResult> Delete(int id)
        {
            _subscribeService.DeleteSubscribe(id);
            return Ok();
        }
    }
}
