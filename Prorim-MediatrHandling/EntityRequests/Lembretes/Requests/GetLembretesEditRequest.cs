using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Requests
{
    public class GetLembretesEditRequest : IRequest<bool>
    {
        public int id { get; set; }
        public string nomeLembrete { get; set; }
        public DateTime DataLembrete { get; set; }
        public string clienteID { get; set; }
        public string tipoTransplante { get; set; }
        public string remedio { get; set; }
    }
}
