using System.ComponentModel.DataAnnotations;

namespace Prorim_MediatrHandling.Entities
{
    public class TB_Receituario
    {
        [Key]
        public int id { get; set; }
        public string nomeMedico { get; set; }
        public string nomeReceita { get; set; }
        public byte[] pdf { get; set; }
        public string nomeArquivo { get; set; }
        public string idPaciente { get; set; }
    }
}