using System.ComponentModel.DataAnnotations.Schema;

namespace Models;
public class CustomerCar
{
    public string CarNumber { get; set; }
    public int CustomerId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Car Car { get; set; }
}