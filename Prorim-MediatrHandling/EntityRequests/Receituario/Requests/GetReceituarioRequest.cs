using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Requests
{
    public class GetReceituarioRequest : IRequest<IEnumerable<GetReceituarioResult>>
    {
    }
}
