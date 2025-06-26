using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Results
{
    public class GetLaudosResult
    {
        public string id { get; set; }
        public string nomeMedico { get; set; }
        public byte[] pdf { get; set; }
        public string idPaciente { get; set; }
    }
}
