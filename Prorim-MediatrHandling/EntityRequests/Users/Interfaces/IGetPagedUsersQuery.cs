using Prorim_MediatrHandling.EntityRequests.Users.Requests;
using Prorim_MediatrHandling.EntityRequests.Users.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Users.Interfaces
{
    public interface IGetPagedUsersQuery
    {
        Task<IEnumerable<GetUserPagedResult>> Get(GetUserPagedRequest request);
    }
}
