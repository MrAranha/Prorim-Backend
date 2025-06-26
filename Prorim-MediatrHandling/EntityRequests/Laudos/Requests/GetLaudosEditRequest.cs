using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Requests
{
    public class GetLaudosEditRequest : IRequest<bool>
    {
        public int ID { get; set; }
        public string? nomeMedico { get; set; }
        public byte[]? pdf { get; set; }
        public string? nomeArquivo { get; set; }
        public string? idPaciente { get; set; }
    }
}
