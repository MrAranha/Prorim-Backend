using Prorim_MediatrHandling.EntityRequests.Users.Results;
using Prorim_MediatrHandling.Generics;
using Prorim_MediatrHandling.Interfaces;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Users.Requests
{
    public class GetUserPagedRequest : PagedRequest, IRequest<IEnumerable<GetUserPagedResult>>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Empresa { get; set; }
        public string? id { get; set; }
    }
}
