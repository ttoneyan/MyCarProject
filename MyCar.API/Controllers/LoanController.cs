using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCar.API.DTO;
using MyCar.API.Services.Interfaces;
using System.Security.Claims;

namespace MyCar.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class LoanController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoanController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpPost("check")]
    [Authorize]
    public async Task<IActionResult> CheckLoan(CreateLoanApplicationDTO dto)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

        var result = await _loanService.CreateLoanAsync(dto, userId);


        return Ok(result);
    }
}
