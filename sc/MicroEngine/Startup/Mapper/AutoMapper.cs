using AutoMapper;
using MicroEngine.Data.Entities;
using MicroEngine.Framework.Entity;
using MicroEngine.Models.RequestModels;

namespace MicroEngine.Startup.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserAccount, UserAccountModel>();

            CreateMap<UserAccountModel, UserAccount>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<UserUpdateModel, UserAccount>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UserCode, opt => opt.Ignore());

            CreateMap<UserAccount, User>();
        }
    }
}
