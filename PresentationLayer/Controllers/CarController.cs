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
    public IEnumerable<object> Get() 
    {
        var allCars = _service.GetCars();
        var cars = _map.Map<List<CarView>>(allCars);
        return cars;
    }
    
    [HttpGet(template : "AllByCache")]
    public IEnumerable<object> GetByCache() 
    {
        var allCars = _service.GetCarsByCache();
        var cars = _map.Map<List<CarView>>(allCars);
        return cars;
    } 
    
    [HttpGet(template : "Paging")]
    public IEnumerable<object> Paging(int pageNumber = 1 , int pageSize = 10) 
    {
        int skip = pageSize * (pageNumber - 1);
        var allCars = _service.GetCars().Skip(skip).Take(pageSize);
        var cars = _map.Map<List<CarView>>(allCars);
        return cars;
    } 
    
    [HttpGet(template : "Sorting")]
    public IEnumerable<object> Sorting(string colName ,  bool Desc = false) 
    {
        var resCars = _service.GetCarsBy(colName , Desc);
        var cars = _map.Map<List<CarView>>(resCars);
        return cars;
    }

    [HttpGet(template : "Searching")]
    public IEnumerable<object> Searching(string colName ,  string value)
    {
        var resCars = _service.SearchBy(colName , value);
        var cars = _map.Map<List<CarView>>(resCars);
        return cars;
    }   

    [HttpGet("{id}")]
    public object Get(string id) 
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