using Models;
using Repositories;

namespace BussinessLayer;
public class CarService : ICarService
{
    private readonly ICarRepository _repository;
    public CarService(ICarRepository repository) => _repository = repository;
    
    public IEnumerable<Car> GetCars() => _repository.GetCars();
    public Car GetCarById(string numCar) => _repository.GetCarById(numCar);
    public void AddCar(Car car) => _repository.AddCar(car);
    public bool IsExist(string numCar) => _repository.IsExist(numCar);
    public void UpdateCar(Car car) => _repository.UpdateCar(car);
    public void DeleteCar(string CarNumber) => _repository.DeleteCar(CarNumber);
}