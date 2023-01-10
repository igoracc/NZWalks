using AutoMapper;

namespace NzWalksAPI.Profiles
{
    public class RegionsProfile: Profile
    {
        public RegionsProfile()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>();
               /// .ForMember(dest => dest.Id, options => options.MapFrom(src => src.));
               ///.ReverseMap()



        }





    }
}
