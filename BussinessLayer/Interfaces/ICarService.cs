using Models;

namespace BussinessLayer;
public interface ICarService
{
    void AddCar(Car car);
    bool IsExist(string numCar);
    void UpdateCar(Car car);
    void DeleteCar(string CarNumber);
    IEnumerable<Car> GetCars();
    Car GetCarById(string numCar);
    
}