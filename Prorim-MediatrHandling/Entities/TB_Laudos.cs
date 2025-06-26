using System.ComponentModel.DataAnnotations;

namespace Prorim_MediatrHandling.Entities
{
    public class TB_Laudos
    {
        [Key]
        public int id { get; set; }
        public string nomeMedico { get; set; }
        public byte[] pdf { get; set; }
        public string nomeArquivo { get; set; }
        public string idPaciente { get; set; }
    }
}