using Prorim_MediatrHandling.EntityRequests.Lembretes.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Requests;
using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Handlers
{
    public class GetLembretesPagedRequestHandler : IRequestHandler<GetLembretesPagedRequest, IEnumerable<GetLembretesPagedResult>>
    {
        private readonly IGetPagedLembretesQuery _getPagedLembretesQuery;
        public GetLembretesPagedRequestHandler(IGetPagedLembretesQuery getPagedLembretesQuery) { _getPagedLembretesQuery = getPagedLembretesQuery; }

        public async Task<IEnumerable<GetLembretesPagedResult>> Handle(GetLembretesPagedRequest request, CancellationToken cancellationToken)
        {
            return await _getPagedLembretesQuery.Get(request);
        }
    }
}