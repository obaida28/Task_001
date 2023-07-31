namespace BussinessLayer;
public interface ICarCache
{
    public void SetCache(IEnumerable<Car> cars);
    public void AddToCache(Car car);
    public void UpdateCache(Car car);
    public void DeleteFromCache(string CarNumber);
    public IEnumerable<Car> getCars();
}