﻿using AnticariApp.Application.Authentication;
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

    [HttpGet]
    public IEnumerable<User> Index()
    {
        return _userService.Index();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult> Register(RegistrationRequest model)
    {
        var userId = await _userService.Register(model);
        if (userId == 0)
        {
            return BadRequest($"Adresa de email a fost deja folosită");
        }

        return Ok(new { message = "Cont înregistrat cu succes." });
    }
}
