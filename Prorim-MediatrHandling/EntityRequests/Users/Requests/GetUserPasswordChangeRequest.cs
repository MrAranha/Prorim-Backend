using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Users.Requests
{
    public class GetUserPasswordChangeRequest : IRequest<bool>
    {
        public string UserID { get; set; }
        public string Password { get; set; }
    }
}
