using FbSoft_MediatrHandling.EntityRequests.Users.Interfaces;
using FbSoft_MediatrHandling.EntityRequests.Users.Requests;
using FbSoft_MediatrHandling.EntityRequests.Users.Results;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FbSoft_MediatrHandling.EntityRequests.Users.Handlers
{
    public class GetCarroPagedRequestHandler : IRequestHandler<GetUserPagedRequest, IEnumerable<GetUserPagedResult>>
    {
        private readonly IGetPagedUsersQuery _getPagedUsersQuery;
        public GetCarroPagedRequestHandler(IGetPagedUsersQuery getPagedUsersQuery) { _getPagedUsersQuery = getPagedUsersQuery; }

        public async Task<IEnumerable<GetUserPagedResult>> Handle(GetUserPagedRequest request, CancellationToken cancellationToken)
        {
            return await _getPagedUsersQuery.Get(request);
        }
    }
}