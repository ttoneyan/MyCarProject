namespace WebApplication.Models;

public class Dealers
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string DealerPasswordHash { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string Website { get; set; }
    public string Description { get; set; }
    public bool IsActivatedByAdmin { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Cars> Cars { get; set; } = new List<Cars>();
}
