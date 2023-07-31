namespace BussinessLayer;
public interface ICarCache
{
    public void setCache(IEnumerable<Car> cars);
    public void addToCache(Car car);
    public void updateCache(Car car);
    public void deleteFromCache(Guid id);
    public IEnumerable<Car> getCars();
}