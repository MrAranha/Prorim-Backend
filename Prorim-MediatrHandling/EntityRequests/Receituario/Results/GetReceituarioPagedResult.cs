using Prorim_MediatrHandling.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Receituario.Results
{
    public class GetReceituarioPagedResult
    {
        public string id { get; set; }
        public string nomeMedico { get; set; }
        public string nomeReceita { get; set; }
        public string idPaciente { get; set; }
    }
}
