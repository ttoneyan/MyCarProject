using WebApplication.Models.Enums;
namespace WebApplication.Models;

public class Bookings
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
    public int CarId { get; set; }
    public int DealerId { get; set; }
    public Dealers Dealer { get; set; }
    public Cars Car { get; set; }
    public Status Status { get; set; }
}