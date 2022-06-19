using AnticariApp.Application.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnticariApp.API.Controllers;

public class AuthController : ACController
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginRequest model)
    {
        var response = await _authService.Login(model);
        if (response == null)
        {
            return BadRequest(new { message = "Credențiale greșite!" });
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, response.UserId.ToString()),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties());

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        return Ok(new { message = "Ați fost delogat cu succes." });
    }
}
