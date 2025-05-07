using AutoMapper;
using FbSoft_MediatrHandling.EntityRequests.Login.Result;
using FbSoft_MediatrHandling.EntityRequests.Users.Requests;
using FbSoft_MediatrHandling.EntityRequests.Users.Results;
using FbSoft_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Users.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<GetCarroRequest, GetCarroResult>();
            CreateMap<GetCarroResult, GetCarroRequest>();
            CreateMap<GetCarroResult, TB_Users>();
            CreateMap<TB_Users, GetCarroResult>().ReverseMap();
        }
    }
}
