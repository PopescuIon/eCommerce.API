
using AutoMapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;

namespace eCommerce.Core.Mappers
{
    public class ApplicationUserMapperProfile: Profile
    {
        public ApplicationUserMapperProfile()
        {
            CreateMap<ApplicationUser,AuthenticationResponse>()
             .ForMember(dest => dest.Success,opt =>opt.Ignore())
             .ForMember(dest => dest.Token,opt =>opt.Ignore());

             
        }
        
    }
}