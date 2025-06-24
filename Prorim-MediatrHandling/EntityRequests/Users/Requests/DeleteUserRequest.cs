using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Users.Requests
{
    public class DeleteCarroRequest : IRequest<bool>
    {
        public string UserID { get; set; }
    }
}
