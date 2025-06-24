using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Requests
{
    public class GetLembretesByIDRequest : IRequest<GetLembretesByIDResult>
    {
        public int ID { get; set; }
    }
}
