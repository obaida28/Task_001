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
    IEnumerable<Car> GetCarsBy(string colName , bool desc = false);
    IEnumerable<Car> SearchBy(string colName , string value);
    IEnumerable<Car> GetCarsByCache();
}