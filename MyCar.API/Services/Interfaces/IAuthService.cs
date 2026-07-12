using MyCar.API.DTO;
using MyCar.API.Responses;

namespace MyCar.API.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> Register(RegisterDTO dto);
    Task<AuthResponse> Login(LoginDTO dto);

}
