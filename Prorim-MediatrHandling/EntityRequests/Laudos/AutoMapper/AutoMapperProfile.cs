using AutoMapper;
using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using Prorim_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prorim_MediatrHandling.Entities;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<GetLaudosRequest, GetLaudosResult>();
            CreateMap<GetLaudosResult, GetLaudosRequest>();
            CreateMap<GetLaudosResult, TB_Laudos>();
            CreateMap<TB_Laudos, GetLaudosResult>().ReverseMap();
        }
    }
}
