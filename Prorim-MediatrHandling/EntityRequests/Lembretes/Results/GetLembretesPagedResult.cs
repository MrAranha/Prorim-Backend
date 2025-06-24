using Prorim_MediatrHandling.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Lembretes.Results
{
    public class GetLembretesPagedResult
    {
        public int id { get; set; }
        public string nomeLembrete { get; set; }
        public DateTime DataLembrete { get; set; }
        public string clienteID { get; set; }
        public string tipoTransplante { get; set; }
        public string remedio { get; set; }
    }
}
