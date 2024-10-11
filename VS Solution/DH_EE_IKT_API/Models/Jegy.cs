using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DH_EE_IKT_API.Models
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

        [ForeignKey(nameof(Tantargy_ID))]
        public Tantargy? Tantargy { get; set; }

        [ForeignKey(nameof(Tanulo_ID))]
        public Tanulo? Tanulo { get; set; }

        [ForeignKey(nameof(Tanar_ID))]
        public Tanar? Tanar { get; set; }
    }
}
