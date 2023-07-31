namespace Models;
public class Driver
{
    public int Id { get; set; }
    public string DriverName { get; set; }
    public int? substitDriverId { get; set; }
    public virtual Driver substitute { get; set; }
    public virtual ICollection<DriverCar> DriverCars { get; set; }
}