namespace Repositories;
public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context) => _context = context;
    public void addCar(Car car)
    {
        _context.Add(car);
        _context.SaveChanges();
    }
    public bool isExist(Guid id) => getCarById(id) != null;
    public DbSet<Car> getCars() => _context.Cars;
    public Car getCarById(Guid id) => _context.Cars.Find(id);
    public void updateCar(Car car)
    {
        _context.Update(car);
        _context.SaveChanges();
    }
    public void deleteCar(Guid id)
    {
        var car = getCarById(id);
        _context.Cars.Remove(car);
        _context.SaveChanges();
    }
}