using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyCar.API.DTO;
using MyCar.API.Services.Interfaces;
using System.Security.Claims;

namespace MyCar.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DealersController : ControllerBase
{
    private readonly IDealerService _dealerService;

    public DealersController(IDealerService dealerService)
    {
        _dealerService = dealerService;
    }

    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateDealer(CreateDealerDTO dto)
    {
        var response = await _dealerService.CreateDealer(dto);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}