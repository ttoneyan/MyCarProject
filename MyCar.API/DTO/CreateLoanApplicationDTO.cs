namespace MyCar.API.DTO;

public class CreateLoanApplicationDTO
{
    public int CarId { get; set; }
    public decimal MonthlySalary { get; set; }
    public decimal MonthlyExpenses { get; set; }
    public decimal DownPayment { get; set; }
}