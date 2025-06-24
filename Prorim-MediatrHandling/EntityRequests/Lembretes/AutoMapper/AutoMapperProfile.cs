using AutoMapper;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using Prorim_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<GetLembretesRequest, GetLembretesResult>();
            CreateMap<GetLembretesResult, GetLembretesRequest>();
            CreateMap<GetLembretesResult, TB_Lembretes>();
            CreateMap<TB_Lembretes, GetLembretesResult>().ReverseMap();
        }
    }
}
