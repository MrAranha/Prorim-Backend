using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Interfaces
{
    public interface IGetPagedLembretesQuery
    {
        Task<IEnumerable<GetLembretesPagedResult>> Get(GetLembretesPagedRequest request);
    }
}
