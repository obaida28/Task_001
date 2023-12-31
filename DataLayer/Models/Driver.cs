namespace Models;
public class Driver
{
    public Guid Id { get; set; }
    public string DriverName { get; set; }
    public Guid? SubstitDriverId { get; set; }
    public virtual Driver Substitute { get; set; }
    public bool IsAvailable { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
    public Driver() => Id = Guid.NewGuid();
}