using Prorim_MediatrHandling.EntityRequests.Laudos.Results;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Requests
{
    public class GetLaudosRequest : IRequest<IEnumerable<GetLaudosResult>>
    {
    }
}
