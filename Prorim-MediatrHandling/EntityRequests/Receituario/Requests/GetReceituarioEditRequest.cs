using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Requests
{
    public class GetReceituarioEditRequest : IRequest<bool>
    {
        public string? nomeMedico { get; set; }
        public byte[]? pdf { get; set; }
        public string? nomeArquivo { get; set; }
        public string nomeReceita { get; set; }
        public string? idPaciente { get; set; }
    }
}
