using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prorim_Services.Entities
{
    [Table("TB_Lembretes")]
    public class TB_Lembretes
    {
        [Key]
        public int id { get; set; }
        public string nomeLembrete { get; set; }
        public DateTime DataLembrete { get; set; }
        public string clienteID { get; set; }
        public string tipoTransplante { get; set; }
        public string remedio { get; set; }
    }
}