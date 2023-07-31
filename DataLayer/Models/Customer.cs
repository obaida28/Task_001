namespace Models;
public class Customer
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public virtual ICollection<Rental> Rentals { get; set; }
    public Customer() => Id = Guid.NewGuid();
}