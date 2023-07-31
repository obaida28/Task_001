namespace Repositories;
public interface ICarRepository
{
    void addCar(Car car);
    bool isExist(Guid id) ;
    DbSet<Car> getCars();
    Car getCarById(Guid id);
    void updateCar(Car car);
    void deleteCar(Guid id);
}