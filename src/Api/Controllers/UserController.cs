using AnticariApp.Application.User;
using Microsoft.AspNetCore.Mvc;

namespace AnticariApp.API.Controllers;

public class UserController : ACController
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
    public async Task<ActionResult> Register(RegistrationRequest model)
    {
        var userId = await _userService.Register(model);
        if (userId == 0)
        {
            return BadRequest(new { message = "Your email address is already in use!" });
        }

        return Ok(new { message = "Account registered successfully." });
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(AuthenticationRequest model)
    {
        var correctCredentials = await _userService.Authenticate(model);
        if (!correctCredentials)
        {
            return BadRequest(new { message = "Wrong credentials!" });
        }

        return Ok(new { message = "Logged in." });
    }
}
