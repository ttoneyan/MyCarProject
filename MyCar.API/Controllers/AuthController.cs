using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCar.API.DTO;
using MyCar.API.Models;
using MyCar.API.Services.Implementations;
using MyCar.API.Services.Interfaces;

namespace MyCar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDTO dto)
    {
        var response = await _authService.Register(dto);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var response = await _authService.Login(dto);

        if (!response.Success)
            return Unauthorized(response);

        return Ok(response);
    }
}