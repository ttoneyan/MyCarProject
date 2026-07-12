namespace WebApplication.Models;

public class Cars
{
    public int Id { get; set; }
    public int DealerId { get; set; }
    public Dealers Dealer { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Vin { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool IsPublishedByAdmin { get; set; }
    public bool IsActivatedByDealer { get; set; }
    public string PhotoPath { get; set; }
}