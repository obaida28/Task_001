using Microsoft.Extensions.Caching.Memory;
using Models;
using Repositories;

namespace BussinessLayer;
public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    private readonly IMemoryCache _cache;
    public CarService(ICarRepository repository , IMemoryCache cache)
    {
        _repository = repository;
        _cache = cache;
    }
    public IEnumerable<Car> GetCars() => _repository.GetCars();
    public Car GetCarById(string numCar) => _repository.GetCarById(numCar);
    public void AddCar(Car car) => _repository.AddCar(car);
    public bool IsExist(string numCar) => _repository.IsExist(numCar);
    public void UpdateCar(Car car) => _repository.UpdateCar(car);
    public void DeleteCar(string CarNumber) => _repository.DeleteCar(CarNumber);
    public IEnumerable<Car> GetCarsBy(string colName , bool desc = false)
    {
        var cars = GetCars();
        switch(colName)
        {
            case "Type" : 
                return desc ? cars.OrderByDescending(c => c.Type) : cars.OrderBy(c => c.Type);
            case "Color" : 
                return desc ? cars.OrderByDescending(c => c.Color) : cars.OrderBy(c => c.Color);
            case "EngineCapacity" : 
                return desc ? cars.OrderByDescending(c => c.EngineCapacity) : cars.OrderBy(c => c.EngineCapacity);
            case "DailyRate" : 
                return desc ? cars.OrderByDescending(c => c.DailyRate) : cars.OrderBy(c => c.DailyRate);
            default :
                return desc ? cars.OrderByDescending(c => c.CarNumber) : cars.OrderBy(c => c.CarNumber);
        }
    }
    public IEnumerable<Car> SearchBy(string colName , string value)
    {
        var cars = GetCars();
        switch(colName)
        {
            case "Type" : 
                return cars.Where(c => c.Type == value.ToString());
            case "Color" : 
                return cars.Where(c => c.Color == value.ToString());
            case "EngineCapacity" : 
                return cars.Where(c => c.EngineCapacity == Convert.ToDecimal(value));
            case "DailyRate" : 
                return cars.Where(c => c.DailyRate == Convert.ToInt32(value));
            default :
                return cars.Where(c => c.CarNumber == value.ToString());
        }
    }
    public IEnumerable<Car> GetCarsByCache()
    {
        var cacheKey = "cars";
        if (!_cache.TryGetValue(cacheKey, out IEnumerable<Car> cars))
        {
            cars = GetCars();
            _cache.Set(cacheKey, cars, TimeSpan.FromHours(1));
        }
        return cars;
    }
}