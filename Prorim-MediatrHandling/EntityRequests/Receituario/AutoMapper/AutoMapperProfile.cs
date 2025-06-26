using AutoMapper;
using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using Prorim_MediatrHandling.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<GetReceituarioRequest, GetReceituarioResult>();
            CreateMap<GetReceituarioResult, GetReceituarioRequest>();
            CreateMap<GetReceituarioResult, TB_Receituario>();
            CreateMap<TB_Receituario, GetReceituarioResult>().ReverseMap();
        }
    }
}
