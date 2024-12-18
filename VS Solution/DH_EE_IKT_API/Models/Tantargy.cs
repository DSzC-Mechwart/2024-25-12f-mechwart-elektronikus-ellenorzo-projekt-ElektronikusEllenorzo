using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DH_EE_IKT_API.Models
{
    public class Tantargy
    {
        [Key]
        public required int ID { get; set; }
        [Required]
        public required string Nev { get; set; }
        [Required]
        public required string Osztaly_ID { get; set; }
        [Required]
        public required bool Szakmai_e { get; set; }
        [Required]
        public required int Tanar_ID { get; set; }

        [ForeignKey("Osztaly_ID")]
        public Osztaly? Osztaly { get; set; }

        [ForeignKey("Tanar_ID")]
        public Tanar? Tanar { get; set; }
    }
}
