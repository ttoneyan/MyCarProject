using WebApplication.Models.Enums;
namespace WebApplication.Models;

public class LoanApplications
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
    public int DealerId { get; set; }
    public Dealers Dealer { get; set; }
    public int CarId { get; set; }
    public Cars Car { get; set; }
    public decimal RequestedAmount { get; set; }
    public decimal DownPayment { get; set; }
    public int TermMonths { get; set; }
    public double InterestRate { get; set; }
    public Status Status { get; set; }
    public DateTime CreatedAt { get; set; }
}
