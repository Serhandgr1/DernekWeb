using Entities.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Society.Areas.Client.Controllers
{
    public class TokenCheckController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public TokenCheckController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<TokenDto> RefteshToken([FromBody]TokenDto tokenDto)
        {
            var data = await _authenticationService.RefreshToken(tokenDto);
            return data;
        }
    }
}
