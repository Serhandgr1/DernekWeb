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
        private readonly ILogger<SubscribeSocietyClientController> _logger;
        public SubscribeSocietyClientController(ISubscribeService subscribeService, ILogger<SubscribeSocietyClientController> logger)
        {
            _subscribeService = subscribeService;
            _logger = logger;
        }
        public async Task<List<SubscribeDto>> GetAll()
        {
          var data =  _subscribeService.GetAllSubscribe().ToList();
            return data;
        }
        public  async Task<IActionResult> Delete(int id)
        {
            try {
                _subscribeService.DeleteSubscribe(id);
                return Ok();
            } catch(Exception ex) {
                _logger.LogError(ex.Message);
            return BadRequest(ex.Message);
            }

           
        }
    }
}
