using MyCar.API.DTO;

namespace MyCar.API.Services.Interfaces;

public interface ILoanService
{
    Task<LoanResultDTO> CreateLoanAsync(CreateLoanApplicationDTO dto, int userId);
}
