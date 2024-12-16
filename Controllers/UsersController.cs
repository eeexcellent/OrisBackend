using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrisBackend.DTOs;
using OrisBackend.Repositories;
using OrisBackend.Services;

namespace OrisBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] AuthRequestDto request)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(request.IdToken))
            {
                return BadRequest(new { message = "ID Token is required." });
            }

            var response = await _authService.SignInAsync(request.IdToken);
            if (response == null)
            {
                return Unauthorized(new { message = "ID Token is required." });
            }

            return Ok(response);
        }
    }
}
