using Prorim_MediatrHandling.EntityRequests.Receituario.Results;
using Prorim_MediatrHandling.Generics;
using Prorim_MediatrHandling.Interfaces;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Requests
{
    public class GetReceituarioPagedRequest : PagedRequest, IRequest<IEnumerable<GetReceituarioPagedResult>>
    {
        public int? id { get; set; }
        public string? nomeMedico { get; set; }
        public string? idPaciente { get; set; }
        public string? nomeReceita { get; set; }
    }
}
