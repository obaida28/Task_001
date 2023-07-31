namespace BussinessLayer;
public interface ICarService
{
    void addCar(Car car);
    bool isExist(Guid id);
    void updateCar(Car car);
    void deleteCar(Guid id);
    DbSet<Car> getAllCars();
    Car getCarById(Guid id);
    List<Car> getfilter(CarFilter dto);
    IEnumerable<Car> getCarsByCache();
}