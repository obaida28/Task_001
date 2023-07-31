namespace Mapper;
public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap < CarDTO, Car > ()
        .ForMember(
            dest => dest.CustomerCars  ,opt => opt.MapFrom(src => 
                new List<CustomerCar> { 
                        new CustomerCar { CustomerId = (int)src.CustomerId , CarNumber = src.CarNumber} }
            ))
        .ForMember(
            dest => dest.DriverCars  ,opt => opt.MapFrom(src => 
                new List<DriverCar> { 
                        new DriverCar { DriverId = (int)src.DriverId , CarNumber = src.CarNumber} }
            ));

         CreateMap<Car, CarView>()
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => getDrivers(src)))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => getCustomers(src)));
    }
    private IEnumerable<string> getDrivers(Car list)
    {
        if(list.DriverCars.Any())
            return list.DriverCars.Select(a => a.Driver.DriverName);
        IEnumerable<string> res = new[] { "No Driver" };
        return res;
    }
    private IEnumerable<string> getCustomers(Car list)
    {
        if(list.CustomerCars.Any())
            return list.CustomerCars.Select(a => a.Customer.CustomerName);
        IEnumerable<string> res = new[] { "No Customer" };
        return res;
    }
}