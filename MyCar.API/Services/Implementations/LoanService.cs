using Microsoft.EntityFrameworkCore;
using MyCar.API.Data;
using MyCar.API.DTO;
using MyCar.API.Services.Interfaces;
using MyCar.API.Models;
using MyCar.API.Models.Enums;

namespace MyCar.API.Services.Implementations;

public class LoanService : ILoanService
{
    private readonly AppDbContext _context;

    public LoanService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LoanResultDTO> CreateLoanAsync(CreateLoanApplicationDTO dto, int userId)
    {
        var car = await _context.Cars.FirstOrDefaultAsync(c => c.Id == dto.CarId);

        if (car == null)
        {
            throw new Exception("Car not found.");
        }

        const decimal interestRate = 14.4m;
        const int termMonths = 84;

        decimal requestedAmount = car.Price - dto.DownPayment;

        if (requestedAmount <= 0)
        {
            throw new Exception("Invalid down payment.");
        }

        decimal monthlyRate = interestRate / 12 / 100;

        decimal monthlyPayment = requestedAmount * (monthlyRate * (decimal)Math.Pow((double)(1 + monthlyRate), termMonths))
            / ((decimal)Math.Pow((double)(1 + monthlyRate), termMonths) - 1);

        decimal availableIncome = dto.MonthlySalary - dto.MonthlyExpenses;

        bool approved = monthlyPayment <= availableIncome * 0.5m;

        var loanApplication = new LoanApplications
        {
            UserId = userId,

            CarId = car.Id,

            DealerId = car.DealerId,

            RequestedAmount = requestedAmount,

            DownPayment = dto.DownPayment,

            TermMonths = termMonths,

            InterestRate = (double)interestRate,

            Status = approved ? Status.Approved : Status.Rejected,

            CreatedAt = DateTime.UtcNow
        };

        _context.LoanApplications.Add(loanApplication);

        await _context.SaveChangesAsync();

        return new LoanResultDTO
        {
            IsApproved = approved,

            Message = approved ? "Վարկը նախնական հաստատվել է։ Վերջնական որոշման համար անհրաժեշտ է դիմել բանկ։"
                                : "Ցավոք, տվյալ պայմաններով վարկը չի կարող նախնական հաստատվել։",

            RequestedAmount = requestedAmount,

            MonthlyPayment = Math.Round(monthlyPayment, 2),

            InterestRate = interestRate,

            TermMonths = termMonths,
            ApplicationId = loanApplication.Id,
        };
    }

}