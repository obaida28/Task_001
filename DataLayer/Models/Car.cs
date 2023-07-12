using System.ComponentModel.DataAnnotations;

namespace Models;
public class Car
{
    [Key]
    public string CarNumber { get; set; }
    public string Type { get; set; }
    public decimal EngineCapacity { get; set; }
    public string Color { get; set; }
    public int DailyRate { get; set; }
    public int? DriverId { get; set; }
    public virtual Driver? Driver { get; set; }
    public int? CustomerId { get; set; }
    public virtual Customer? Customer { get; set; }
}