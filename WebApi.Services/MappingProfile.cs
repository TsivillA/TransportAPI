using AutoMapper;
using WebApi.DAL.Models;
using WebApi.Models;

namespace WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Owner, OwnerQueryModel>();
            CreateMap<OwnerCommandModel, Owner>();

            CreateMap<Vehicle, VehicleQueryModel>()
                .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => src.FuelType.Name))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageName));
            CreateMap<VehicleCommandModel, Vehicle>();
            CreateMap<VehicleOwnerCommandModel, VehicleOwner>();
        }
    }
}
