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
        var allCars = _service.GetAllCars();
        var cars = _map.Map<List<CarView>>(allCars);
        return cars;
    }
    
    [HttpGet(template : "AllByCache")]
    public IEnumerable<CarView> GetByCache() 
    {
        var allCars = _service.GetCarsByCache();
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
    public CarView Get(string id) 
    {
        var getCar = _service.GetCarById(id);
        var car = _map.Map<CarView>(getCar);
        return car;
    }
    
    [HttpPost]
    public IActionResult AddCar(CarDTO carDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        Car car = _map.Map<Car>(carDTO);
        if(_service.IsExist(carDTO.CarNumber))
            return BadRequest("The car number is unique !");
        _service.AddCar(car);
        return Ok(car);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCar(string id , CarDTO carDTO)
    {
        if (id != carDTO.CarNumber)
            return BadRequest();
        Car car = _map.Map<Car>(carDTO);
        _service.UpdateCar(car);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCar(string id)
    {
        if (!_service.IsExist(id))
            return NotFound();
        _service.DeleteCar(id);
        return NoContent();
    }
}