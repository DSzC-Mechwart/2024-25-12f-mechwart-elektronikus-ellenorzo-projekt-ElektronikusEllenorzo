using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKT_II_Derecske_Holding_EE.Models
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
        public required Osztaly Osztaly { get; set; }

        [ForeignKey("Tanar_ID")]
        public required Tanar Tanar { get; set; }
    }
}
