using Prorim_MediatrHandling.EntityRequests.Laudos.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Laudos.Requests;
using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Handlers
{
    public class GetLaudosPagedRequestHandler : IRequestHandler<GetLaudosPagedRequest, IEnumerable<GetLaudosPagedResult>>
    {
        private readonly IGetPagedLaudosQuery _getPagedLaudosQuery;
        public GetLaudosPagedRequestHandler(IGetPagedLaudosQuery getPagedLaudosQuery) { _getPagedLaudosQuery = getPagedLaudosQuery; }

        public async Task<IEnumerable<GetLaudosPagedResult>> Handle(GetLaudosPagedRequest request, CancellationToken cancellationToken)
        {
            return await _getPagedLaudosQuery.Get(request);
        }
    }
}