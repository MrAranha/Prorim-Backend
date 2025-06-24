using Prorim_MediatrHandling.EntityRequests.Users.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Users.Requests
{
    public class GetUserByIDRequest : IRequest<GetUserByIDResult>
    {
        public string UserID { get; set; }
    }
}
