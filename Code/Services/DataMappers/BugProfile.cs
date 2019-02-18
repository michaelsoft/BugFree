using AutoMapper;
using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.ViewModels;

namespace MichaelSoft.BugFree.WebApi.DataMappers
{
    public class BugProfile : Profile
    {
        public BugProfile()
        {
            CreateMap<BugViewModel, Bug>()
                .ForMember(d => d.Id, opt => opt.Condition( s => s.Id > 0)) //For new, don't set the Id, or it will cause EF error.
                .ForMember(d => d.State, opt => opt.MapFrom(s => (BugState)s.StateId));
            CreateMap<BugAttachmentViewModel, BugAttachment>()
                .ForMember(d => d.Id, opt => opt.Condition(s => s.Id > 0));
        }
    }

}
