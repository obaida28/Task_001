namespace Models;
public class Rental
{
    public string CarNumber { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? DriverId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Car Car { get; set; }
    public virtual Driver? Driver { get; set; }
}