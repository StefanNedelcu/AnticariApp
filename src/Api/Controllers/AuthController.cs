using AnticariApp.Application.Authentication;
using AnticariApp.Application.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult> Login(LoginRequest model)
    {
        var response = await _authService.Login(model);
        if (response == null)
        {
            return BadRequest(new { message = "Credențiale greșite!" });
        }

        return Ok(response);
    }
}
