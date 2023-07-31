using System.ComponentModel.DataAnnotations.Schema;

namespace Models;
public class DriverCar
{
    public string CarNumber { get; set; }
    public virtual Car Car { get; set; }

    public int DriverId { get; set; }
    public virtual Driver Driver { get; set; }
}