using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Models.ViewModels;

public class CarCreate
{
    public string Name { get; set; }

    [Required] // makes image mandatory
    public IFormFile Photo { get; set; }
}