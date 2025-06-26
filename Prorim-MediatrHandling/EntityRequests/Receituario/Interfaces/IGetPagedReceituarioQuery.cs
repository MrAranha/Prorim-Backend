using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Interfaces
{
    public interface IGetPagedReceituarioQuery
    {
        Task<IEnumerable<GetReceituarioPagedResult>> Get(GetReceituarioPagedRequest request);
    }
}
