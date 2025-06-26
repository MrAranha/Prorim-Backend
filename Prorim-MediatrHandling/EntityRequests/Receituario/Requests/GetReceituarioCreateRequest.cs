using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Requests
{
    public class GetReceituarioCreateRequest : IRequest<int>
    {
        public string nomeMedico { get; set; }
        public IFormFile pdf { get; set; }
        public string nomeArquivo { get; set; }
        public string nomeReceita { get; set; }
        public string idPaciente { get; set; }
    }
}
