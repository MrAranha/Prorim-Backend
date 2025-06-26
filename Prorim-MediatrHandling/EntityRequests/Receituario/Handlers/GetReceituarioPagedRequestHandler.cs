using Prorim_MediatrHandling.EntityRequests.Receituario.Interfaces;
using Prorim_MediatrHandling.EntityRequests.Receituario.Requests;
using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using Prorim_MediatrHandling.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Handlers
{
    public class GetReceituarioPagedRequestHandler : IRequestHandler<GetReceituarioPagedRequest, IEnumerable<GetReceituarioPagedResult>>
    {
        private readonly IGetPagedReceituarioQuery _getPagedReceituarioQuery;
        public GetReceituarioPagedRequestHandler(IGetPagedReceituarioQuery getPagedReceituarioQuery) { _getPagedReceituarioQuery = getPagedReceituarioQuery; }

        public async Task<IEnumerable<GetReceituarioPagedResult>> Handle(GetReceituarioPagedRequest request, CancellationToken cancellationToken)
        {
            return await _getPagedReceituarioQuery.Get(request);
        }
    }
}