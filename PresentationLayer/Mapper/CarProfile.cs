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
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => 
                src.DriverCars.Select(dc => dc.Driver.DriverName).ToList()))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => 
                src.CustomerCars.Select(dc => dc.Customer.CustomerName).ToList()));
    }
}