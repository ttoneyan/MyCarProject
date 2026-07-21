namespace MyCar.API.DTO;

public class LoanResultDTO
{
    public bool IsApproved { get; set; }
    public string Message { get; set; }
    public decimal RequestedAmount { get; set; }
    public decimal MonthlyPayment { get; set; }
    public decimal InterestRate { get; set; }
    public int TermMonths { get; set; }
    public int ApplicationId { get; set; }
}