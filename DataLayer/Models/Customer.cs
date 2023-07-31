namespace Models;
public class Customer
{
    public int Id { get; set; }
    public string CustomerName { get; set; }
    public virtual ICollection<CustomerCar> CustomerCars { get; set; }
}