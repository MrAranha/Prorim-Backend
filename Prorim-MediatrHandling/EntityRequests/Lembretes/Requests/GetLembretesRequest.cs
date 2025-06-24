using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Requests
{
    public class GetLembretesRequest : IRequest<IEnumerable<GetLembretesResult>>
    {
    }
}
