namespace Mapper;
public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap < CarDTO, Car > ()
        .ForMember(
            dest => dest.Rentals  ,opt => opt.MapFrom(src => 
                new List<Rental> { 
                    new Rental { CustomerId = (int)src.CustomerId , 
                    DriverId = (int)src.DriverId , CarNumber = src.CarNumber} }
            ));

         CreateMap<Car, CarView>()
            .ForMember(dest => dest.DriverName, opt => opt.MapFrom(src => getDrivers(src)))
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => getCustomers(src)));
    }
    private IEnumerable<string> getDrivers(Car list)
    {
        if(list.Rentals.Any())
            return list.Rentals.Select(a => a.Driver.DriverName);
        IEnumerable<string> res = new[] { "No Driver" };
        return res;
    }
    private IEnumerable<string> getCustomers(Car list)
    {
        if(list.Rentals.Any())
            return list.Rentals.Select(a => a.Customer.CustomerName);
        IEnumerable<string> res = new[] { "No Customer" };
        return res;
    }
}