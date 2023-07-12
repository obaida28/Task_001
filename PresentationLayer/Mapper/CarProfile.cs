namespace Mapper;
public class CarProfile : Profile
{
    public CarProfile()
    {
        CreateMap < CarDTO, Car > ()
            .ForMember(dest => dest.Driver , opt => opt.Ignore())
            .ForMember(
                dest => dest.DriverId  ,opt => opt.MapFrom(src => src.DriverId ))
            .ForMember(dest => dest.Customer , opt => opt.Ignore())
            .ForMember(
                dest => dest.CustomerId  ,opt => opt.MapFrom(src => src.CustomerId ));
        CreateMap < Car, CarView > ()
            .ForMember(
                dest => dest.DriverName  ,opt => opt.MapFrom(src => 
                (src.Driver != null ? src.Driver.DriverName : "No Driver") ))
            .ForMember(
                dest => dest.CustomerName  ,opt => opt.MapFrom(src => 
                (src.Customer != null ? src.Customer.CustomerName : "No Customer") ));
    }
}