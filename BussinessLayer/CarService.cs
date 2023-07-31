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
    public List<Car> getfilter(CarFilter dto)
    {
        IQueryable<Car> all = _repository.GetCars();
        if(dto.WithPaging)
            all = Paging(all , dto.pageNumber , dto.pageSize);
        if(dto.WithSearching && dto.colNameSearch is not null && dto.valueSearch is not null)
            all = Searching(all , dto.colNameSearch , dto.valueSearch);
        if(dto.WithSorting && dto.colNameSort is not null)
            all = Sorting(all , dto.colNameSort , dto.Desc ?? false);
        return all.ToList();
    }
    private IQueryable<Car> Paging(IQueryable<Car> cars , int? pageNumber , int? pageSize)
    {
        int pgSize = (int)(pageNumber ?? 10);
        int pgNum = (int)(pageSize ?? 1);
        int skip = pgSize * (pgNum - 1);
        return cars.Skip(skip).Take(pgNum);   
    }
    private IQueryable<Car> Sorting(IQueryable<Car> cars , string colName , bool desc = false)
    {
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
    private IQueryable<Car> Searching(IQueryable<Car> cars , string colName , string value)
    {
        switch(colName)
        {
            case "Type" : 
                return cars.Where(c => c.Type.Contains(value.ToString()));
            case "Color" : 
                return cars.Where(c => c.Color.Contains(value.ToString()));
            case "EngineCapacity" : 
                return cars.Where(c => c.EngineCapacity == Convert.ToDecimal(value));
            case "DailyRate" : 
                return cars.Where(c => c.DailyRate == Convert.ToInt32(value));
            default :
                return cars.Where(c => c.CarNumber.Contains(value.ToString()));
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