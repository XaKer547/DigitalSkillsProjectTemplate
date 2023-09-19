using Microsoft.AspNetCore.Mvc;
using Some.Domain.Models.DTOs;
using Some.Domain.Services;

namespace Some.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;
        public AccountController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authorizationService.AuthorizeAsync(dto);

            return Ok(result);
        }
    }
}
