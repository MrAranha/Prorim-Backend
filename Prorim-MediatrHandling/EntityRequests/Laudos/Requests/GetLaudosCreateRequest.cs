using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Requests
{
    public class GetLaudosCreateRequest : IRequest<int>
    {
        public string nomeMedico { get; set; }
        public IFormFile pdf { get; set; }
        public string nomeArquivo { get; set; }
        public string idPaciente { get; set; }
    }
}
