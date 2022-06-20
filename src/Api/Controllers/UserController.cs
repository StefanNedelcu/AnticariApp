using AnticariApp.Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnticariApp.API.Controllers;

public class UserController : ACController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<User>> GetUser(long userId)
    {
        var user = await _userService.GetUser(userId);

        return Ok(user);
    }

    [HttpGet("{userId}/details")]
    public Task<ActionResult<User>> GetUserDetails(long userId)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{userId}/details")]
    public Task<ActionResult> UpdateUserDetails(long userId)
    {
        throw new NotImplementedException();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegistrationRequest model)
    {
        var userId = await _userService.Register(model);
        if (userId == 0)
        {
            return BadRequest(new { message = "Adresa de email a fost deja folosită" });
        }

        return Ok(new { message = "Cont înregistrat cu succes." });
    }
}
