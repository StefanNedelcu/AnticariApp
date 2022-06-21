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

    [HttpGet("{userId}/settings")]
    public async Task<ActionResult<UserSettings>> GetUserSettings(long userId)
    {
        var userSettings = await _userService.GetUserSettings(userId);

        return Ok(userSettings);
    }

    [HttpPut("{userId}/settings")]
    public async Task<ActionResult> UpdateUserDetails([FromBody]UpdateUserSettingsRequest req)
    {
        await _userService.UpdateUserSettings(req);

        return Ok();
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
