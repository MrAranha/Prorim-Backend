using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Requests
{
    public class DeleteLaudosRequest : IRequest<bool>
    {
        public int ID { get; set; }
    }
}
