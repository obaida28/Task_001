namespace Models;
public class Car
{
    [Key]
    public string CarNumber { get; set; }
    public string Type { get; set; }
    public decimal EngineCapacity { get; set; }
    public string Color { get; set; }
    public int DailyRate { get; set; }
    public virtual ICollection<CustomerCar> CustomerCars { get; set; }
    public virtual ICollection<DriverCar> DriverCars { get; set; }
}