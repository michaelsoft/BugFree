using AutoMapper;
using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.ViewModels;

namespace MichaelSoft.BugFree.WebApi.DataMappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUserViewModel, AppUser>();
            CreateMap<AppUser, AppUserViewModel>();
        }
    }

}
