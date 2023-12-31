namespace Models;
public class Rental
{
    public Guid Id { get; set; }
    public Guid CarId { get; set; }
    public virtual Car Car { get; set; }
    public Guid CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public Guid? DriverId { get; set; }
    public virtual Driver Driver { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Rental() => Id = Guid.NewGuid();
}