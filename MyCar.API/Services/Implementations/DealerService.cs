using Microsoft.AspNetCore.Identity;
using MyCar.API.Data;
using MyCar.API.DTO;
using MyCar.API.Models;
using MyCar.API.Responses;
using MyCar.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MyCar.API.Services.Implementations;

public class DealerService : IDealerService
{
    private readonly AppDbContext _context;
    private readonly IPasswordHasher<Dealers> _passwordHasher;

    public DealerService(AppDbContext context, IPasswordHasher<Dealers> passwordHasher)
    {
        _context = context;
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponse> CreateDealer(CreateDealerDTO dto)
    {
        var existingDealer = await _context.Dealers.FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (existingDealer != null)
        {
            return new AuthResponse
            {
                Success = false,
                Message = "Email exists"
            };
        }

        var dealer = new Dealers
        {
            Name = dto.Name,
            TaxCode = dto.TaxCode,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            Address = dto.Address,
            Website = dto.Website,
            Description = dto.Description,
            IsActivatedByAdmin = true,
            CreatedAt = DateTime.Now
        };

        dealer.DealerPasswordHash = _passwordHasher.HashPassword(dealer,dto.Password);

        _context.Dealers.Add(dealer);
        await _context.SaveChangesAsync();

        return new AuthResponse
        {
            Success = true,
            Message = "Dealer created"
        };
    }
}