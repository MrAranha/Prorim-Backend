using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Requests
{
    public class GetLembretesCreateRequest : IRequest<int>
    {
        public int id { get; set; }
        public string nomeLembrete { get; set; }
        public DateTime DataLembrete { get; set; }
        public string clienteID { get; set; }
        public string tipoTransplante { get; set; }
        public string remedio { get; set; }
    }
}
