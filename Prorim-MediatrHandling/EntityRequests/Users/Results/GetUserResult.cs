using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prorim_MediatrHandling.EntityRequests.Users.Results
{
    public class GetCarroResult
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string about { get; set; }
        public string role { get; set; }
    }
}
