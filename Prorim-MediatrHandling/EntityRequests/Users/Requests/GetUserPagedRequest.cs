using FbSoft_MediatrHandling.EntityRequests.Users.Results;
using FbSoft_MediatrHandling.Generics;
using FbSoft_MediatrHandling.Interfaces;
using MediatR;

namespace FbSoft_MediatrHandling.EntityRequests.Users.Requests
{
    public class GetUserPagedRequest : PagedRequest, IRequest<IEnumerable<GetUserPagedResult>>
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Empresa { get; set; }
        public string? id { get; set; }
    }
}
