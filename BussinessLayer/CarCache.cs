using Extentions;
namespace BussinessLayer;
public class CarCache : ICarCache
{
    private readonly IMemoryCache _cache;
    private readonly ICarRepository _repository;
    private readonly string CarCacheName = "cars";
    public CarCache(IMemoryCache cache , ICarRepository repository) 
    {
        _cache = cache;
        _repository = repository;
    }
    public void AddToCache(Car car)
    {
        var cars = getCars();
        if (!cars.IsEmpty())
        {
            var list = cars.ToList();
            list.Add(car);
            SetCache(list);
        }
    }
    public void UpdateCache(Car car)
    {
        var cars = getCars().ToList();
        if (!cars.IsEmpty())
        {
            var oldCar = cars.Find(c => c.CarNumber == car.CarNumber);
            cars.Remove(oldCar);
            cars.Add(car);
            SetCache(cars);
        }
    }
    public void DeleteFromCache(string CarNumber)
    {
        var cars = getCars().ToList();
        if (!cars.IsEmpty())
        {
            var oldCar = cars.Find(c => c.CarNumber == CarNumber);
            cars.Remove(oldCar);
            SetCache(cars);
        }
    }
    public IEnumerable<Car> getCars()
    {
        if (_cache.TryGetValue(CarCacheName, out IEnumerable<Car> cars)) return cars;
        var _cars = _repository.GetCars();
        SetCache(_cars);
        return _cars;
    }
    public void SetCache(IEnumerable<Car> cars) => _cache.Set(CarCacheName, cars, TimeSpan.FromHours(1));
}