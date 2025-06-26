using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Interfaces
{
    public interface IGetPagedLaudosQuery
    {
        Task<IEnumerable<GetLaudosPagedResult>> Get(GetLaudosPagedRequest request);
    }
}
