using MyCar.API.DTO;
using MyCar.API.Responses;

namespace MyCar.API.Services.Interfaces;

public interface IDealerService
{
    Task<AuthResponse> CreateDealer(CreateDealerDTO dto);
}
