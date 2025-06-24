using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Prorim_MediatrHandling.EntityRequests.Users.Requests
{
    public class GetCarroCreateRequest : IRequest<string>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
