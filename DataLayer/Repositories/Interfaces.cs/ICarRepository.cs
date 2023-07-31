namespace Repositories;
public interface ICarRepository
{
    void AddCar(Car car);
    bool IsExist(string numCar) ;
    DbSet<Car> GetCars();
    Car GetCarById(string numCar);
    void UpdateCar(Car car);
    void DeleteCar(string numCar);
}