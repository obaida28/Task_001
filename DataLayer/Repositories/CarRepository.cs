namespace Repositories;
public class CarRepository : ICarRepository
{
    private readonly ApplicationDbContext _context;

    public CarRepository(ApplicationDbContext context) => _context = context;
    public void AddCar(Car car)
    {
        _context.Add(car);
        _context.SaveChanges();
    }
    public bool IsExist(string numCar) => GetCarById(numCar) != null;
    public IEnumerable<Car> GetCars() => _context.Cars.ToList();
    public Car GetCarById(string numCar) => _context.Cars.Find(numCar);
    public void UpdateCar(Car car)
    {
        _context.Update(car);
        _context.SaveChanges();
    }
    public void DeleteCar(string numCar)
    {
        var car = GetCarById(numCar);
        _context.Cars.Remove(car);
        _context.SaveChanges();
    }
}