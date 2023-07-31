using Extentions;
namespace BussinessLayer;
public class CarCache : ICarCache
{
    private readonly IMemoryCache _cache;
    private readonly ICarRepository _repository;
    private readonly string carCacheName = "cars";
    public CarCache(IMemoryCache cache , ICarRepository repository) 
    {
        _cache = cache;
        _repository = repository;
    }
    public void addToCache(Car car)
    {
        var cars = getCars();
        if (!cars.IsEmpty())
        {
            var list = cars.ToList();
            list.Add(car);
            setCache(list);
        }
    }
    public void updateCache(Car car)
    {
        var cars = getCars().ToList();
        if (!cars.IsEmpty())
        {
            var oldCar = cars.Find(c => c.Id == car.Id);
            cars.Remove(oldCar);
            cars.Add(car);
            setCache(cars);
        }
    }
    public void deleteFromCache(Guid id)
    {
        var cars = getCars().ToList();
        if (!cars.IsEmpty())
        {
            var oldCar = cars.Find(c => c.Id == id);
            cars.Remove(oldCar);
            setCache(cars);
        }
    }
    public IEnumerable<Car> getCars()
    {
        if (_cache.TryGetValue(carCacheName, out IEnumerable<Car> cars)) return cars;
        var _cars = _repository.getCars();
        setCache(_cars);
        return _cars;
    }
    public void setCache(IEnumerable<Car> cars) => _cache.Set(carCacheName, cars, TimeSpan.FromHours(1));
}