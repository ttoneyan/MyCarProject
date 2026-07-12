using MyCar.API.Models.Enums;
namespace MyCar.API.Models;

public class Bookings
{
    public int Id { get; set; }
    public int UserId { get; set; } 
    public ApplicationUser User { get; set; }
    public int CarId { get; set; }
    public int DealerId { get; set; }
    public Dealers Dealer { get; set; }
    public Cars Car { get; set; }
    public Status Status { get; set; }
}