using System.ComponentModel.DataAnnotations;

namespace MyCar.API.DTO;

public class CreateDealerDTO
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public string TaxCode { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression(
    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
    ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; }

    [Required]
    public string PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Website { get; set; }

    public string? Description { get; set; }
}
