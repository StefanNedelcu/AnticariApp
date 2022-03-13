using ACDataServices.Services;
using ACServiceModels.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ACWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;

        public AuthenticationController(IAuthenticationService authentication)
        {
            _authentication = authentication;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegistrationData data)
        {
            var userId = _authentication.RegisterUser(data);
            if (userId == 0)
                return BadRequest(new { message = "Your email address is already in use!" });

            return Ok();
        }
    }
}
