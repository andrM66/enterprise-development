using AutoMapper;
using BikeRent.Domain;
using Server.Dto;

namespace Server;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Bike, BikeDto>().ReverseMap();
        CreateMap<Rent, RentDto>().ReverseMap();
        CreateMap<BikeType, BikeTypeDto>().ReverseMap();
    }
}
