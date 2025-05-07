using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FbSoft_Services.Entities
{
    [Table("TB_Users")]
    public class TB_Users
    {
        [Key]
        public string id { get; set; }
        public string displayName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string photoURL { get; set; }
        public string phoneNumber { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string zipCode { get; set; }
        public string about { get; set; }
        public string role { get; set; }
        public bool isPublic  = false;
    }
}