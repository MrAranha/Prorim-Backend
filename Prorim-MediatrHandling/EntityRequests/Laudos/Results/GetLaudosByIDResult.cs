using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Laudos.Results
{
    public class GetLaudosByIDResult
    {
        public int id { get; set; }
        public string nomeMedico { get; set; }
        public string idPaciente { get; set; }
    }
}
