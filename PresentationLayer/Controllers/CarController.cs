namespace Controllers;
[ApiController]
[Route("api/[controller]")]
public class CarController : ControllerBase
{
    private readonly ICarService _service;
    protected readonly IMapper _map;
    public CarController(ICarService service , IMapper map) 
    {
        _service = service;
        _map = map;
    } 
    
    [HttpGet(template : "All")]
    public IEnumerable<CarView> Get() 
    {
        var allCars = _service.getAllCars();
        var cars = _map.Map<List<CarView>>(allCars);
        return cars;
    }
    
    [HttpGet(template : "AllByCache")]
    public IEnumerable<CarView> GetByCache() 
    {
        var allCars = _service.getCarsByCache();
        var cars = _map.Map<List<CarView>>(allCars);
        return cars;
    } 
    
    [HttpGet(template : "CarFilter")]
    public IEnumerable<CarView> getList(CarFilter dto) 
    {
        var all = _service.getfilter(dto);
        var cars = _map.Map<List<CarView>>(all);
        return cars;
    } 

    [HttpGet("{id}")]
    public CarView Get(Guid id) 
    {
        var getCar = _service.getCarById(id);
        var car = _map.Map<CarView>(getCar);
        return car;
    }
    
    [HttpPost]
    public IActionResult AddCar(CarDTO carDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        Car car = _map.Map<Car>(carDTO);
        if(_service.isExist(carDTO.CarId))
            return BadRequest("The car number is unique !");
        _service.addCar(car);
        return Ok(car);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCar(Guid id , CarDTO carDTO)
    {
        if (id != carDTO.CarId)
            return BadRequest();
        Car car = _map.Map<Car>(carDTO);
        _service.updateCar(car);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCar(Guid id)
    {
        if (!_service.isExist(id))
            return NotFound();
        _service.deleteCar(id);
        return NoContent();
    }
}