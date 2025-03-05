using Domain;
using ViewModels;

namespace Infrastructure.AutoMapperSettings;

public class AutoMapperProfile :
    InfrastructureSeedworks.AutoMapper.BaseProfileAutoMapper
{
    public AutoMapperProfile() : base()
    {
        // **************************************************
        CreateMap<MarketPlaceProfile, MarketPlaceProfileViewModel>()
         .ReverseMap();
        // **************************************************
    }
}