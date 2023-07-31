namespace Models;
public class Car
{
    public Guid Id { get; set; }
    public string CarNumber { get; set; }
    public string Type { get; set; }
    public decimal EngineCapacity { get; set; }
    public string Color { get; set; }
    public int DailyRate { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
    public Car() => Id = Guid.NewGuid();
}