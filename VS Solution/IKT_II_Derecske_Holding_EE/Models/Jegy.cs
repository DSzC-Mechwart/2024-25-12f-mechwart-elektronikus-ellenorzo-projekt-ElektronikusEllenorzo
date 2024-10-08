using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class Jegy
    {
        [Key]
        public required int ID { get; set; }
        [Required]
        public required int Tantargy_ID { get; set; }
        [Required]
        public required DateTime Datum { get; set; }
        [Required]
        public required int Jegy_Ertek { get; set; }
        [Required]
        public required string Tema { get; set; }
        [Required]
        public required int Tanulo_ID { get; set; }
        [Required]
        public required int Tanar_ID { get; set; }

    }
}
