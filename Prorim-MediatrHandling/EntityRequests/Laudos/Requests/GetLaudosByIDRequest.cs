using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Requests
{
    public class GetLaudosByIDRequest : IRequest<GetLaudosByIDResult>
    {
        public int ID { get; set; }
    }
}
