using Prorim_MediatrHandling.EntityRequests.Lembretes.Results;
using Prorim_MediatrHandling.Generics;
using Prorim_MediatrHandling.Interfaces;
using MediatR;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Requests
{
    public class GetLembretesPagedRequest : PagedRequest, IRequest<IEnumerable<GetLembretesPagedResult>>
    {
        public int? id { get; set; }
        public string? nomeLembrete { get; set; }
        public DateTime? DataLembrete { get; set; }
        public string? clienteID { get; set; }
        public string? tipoTransplante { get; set; }
        public string? remedio { get; set; }
    }
}
