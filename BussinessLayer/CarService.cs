namespace BussinessLayer;
public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    private readonly ICarCache _cache;
    public CarService(ICarRepository repository , ICarCache cache)
    {
        _repository = repository;
        _cache = cache;
    }
    public DbSet<Car> getAllCars() => _repository.getCars();
    public Car getCarById(Guid id) => _repository.getCarById(id);
    public void addCar(Car car)
    {
        _repository.addCar(car);
        _cache.addToCache(car);
    }
    public bool isExist(Guid id) => _repository.isExist(id);
    public void updateCar(Car car)
    {
        _repository.updateCar(car);
        _cache.updateCache(car);
    }
    public void deleteCar(Guid id) 
    {
        _repository.deleteCar(id);
        _cache.deleteFromCache(id);
    }     
    public List<Car> getfilter(CarFilter dto)
    {
        IQueryable<Car> all = _repository.getCars();
        if(dto.WithPaging)
            all = paging(all , dto.pageNumber , dto.pageSize);
        if(dto.WithSearching && dto.colNameSearch is not null && dto.valueSearch is not null)
            all = searching(all , dto.colNameSearch , dto.valueSearch);
        if(dto.WithSorting && dto.colNameSort is not null)
            all = sorting(all , dto.colNameSort , dto.Desc ?? false);
        return all.ToList();
    }
    private IQueryable<Car> paging(IQueryable<Car> cars , int? pageNumber , int? pageSize)
    {
        int pgSize = (int)(pageNumber ?? 10);
        int pgNum = (int)(pageSize ?? 1);
        int skip = pgSize * (pgNum - 1);
        return cars.Skip(skip).Take(pgNum);   
    }
    private IQueryable<Car> sorting(IQueryable<Car> cars , string colName , bool desc = false)
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
    private IQueryable<Car> searching(IQueryable<Car> cars , string colName , string value)
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
    public IEnumerable<Car> getCarsByCache() => _cache.getCars();
}