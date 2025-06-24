using Prorim_MediatrHandling.EntityRequests.Users.Results;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Users.Requests
{
    public class GetCarroRequest : IRequest<IEnumerable<GetCarroResult>>
    {
    }
}
