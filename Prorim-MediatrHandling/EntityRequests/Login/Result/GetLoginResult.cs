using Prorim_Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Login.Result
{
    public class GetLoginResult
    {
        public string accessToken { get; set; }
        public TB_Users user { get; set; }
    }
}
