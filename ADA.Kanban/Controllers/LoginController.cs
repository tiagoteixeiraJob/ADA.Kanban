using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Service.Shared;

namespace ADA.Kanban.Controllers
{
    public class LoginController : Controller
    {
        private readonly ITokenService _tokenService;

        public LoginController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost(template:"login", Name = "login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var token = _tokenService.GenerateToken(loginDto);

            if (token == "")
                return Unauthorized();

            return Ok(token);
        }
    }
}
