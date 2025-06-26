using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Requests
{
    public class GetReceituarioByIDRequest : IRequest<GetReceituarioByIDResult>
    {
        public int ID { get; set; }
    }
}
