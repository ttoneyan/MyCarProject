using Microsoft.AspNetCore.Identity;
using MyCar.API.DTO;
using MyCar.API.Models;
using MyCar.API.Responses;
using MyCar.API.Services.Interfaces;

namespace MyCar.API.Services.Implementations;

public class AuthService: IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly TokenService _tokenService;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        TokenService tokenService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<AuthResponse> Register(RegisterDTO dto)
    {
        var existingUser = await _userManager.FindByEmailAsync(dto.Email);

        if (existingUser != null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Email already exists"
            };
        }

        var user = new ApplicationUser
        {
            Email = dto.Email,
            UserName = dto.Email,
            FirstName = dto.FirstName,
            LastName = dto.LastName
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            return new AuthResponse
            {
                Success = false,
                Message = result.Errors.First().Description
            };
        }

        var roleResult = await _userManager.AddToRoleAsync(user, "User");

        if (!roleResult.Succeeded)
        {
            return new AuthResponse
            {
                Success = false,
                Message = roleResult.Errors.First().Description
            };
        }

        return new AuthResponse
        {
            Success = true,
            Message = "User registered"
        };
    }

    public async Task<AuthResponse> Login(LoginDTO dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);

        if (user == null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }
        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        var token = await _tokenService.CreateToken(user);

        return new AuthResponse
        {
            Success = true,
            Message = "Login successful.",
            Token = token,
            Username = $"{user.FirstName} {user.LastName}"
        };

    }
}
