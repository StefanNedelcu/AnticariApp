using AnticariApp.Application.User;
using Microsoft.AspNetCore.Mvc;

namespace AnticariApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IEnumerable<User> Index()
    {
        return _userService.Index();
    }

    [HttpPost]
    public IActionResult Register(RegistrationRequest model)
    {
        var userId = _userService.Register(model);
        if (userId == 0)
        {
            return BadRequest(new { message = "Your email address is already in use!" });
        }

        return Ok(new { message = "Account registered successfully." });
    }

    [HttpPost("login")]
    public IActionResult Login(AuthenticationRequest model)
    {
        var correctCredentials = _userService.Authenticate(model);
        if (!correctCredentials)
        {
            return BadRequest(new { message = "Wrong credentials!" });
        }

        return Ok(new { message = "Logged in." });
    }
}
