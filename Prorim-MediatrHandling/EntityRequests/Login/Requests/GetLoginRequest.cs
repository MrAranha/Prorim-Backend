using FbSoft_MediatrHandling.EntityRequests.Login.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Login.Requests
{
    public class GetLoginRequest : IRequest<GetLoginResult>
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
