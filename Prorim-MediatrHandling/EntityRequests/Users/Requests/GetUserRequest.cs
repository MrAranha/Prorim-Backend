using FbSoft_MediatrHandling.EntityRequests.Users.Results;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Users.Requests
{
    public class GetCarroRequest : IRequest<IEnumerable<GetCarroResult>>
    {
    }
}
