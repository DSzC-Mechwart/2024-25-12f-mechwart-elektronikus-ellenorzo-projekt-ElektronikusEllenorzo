using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class Tanulo_Obj
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string Nev { get; set; }
        [Required]
        public DateTime Szul_Ido { get; set; }
        [Required]
        public required string Szul_Hely { get; set; }
        [Required]
        public required string Anya_Nev { get; set; }

        public string? Koli { get; set; }
        [Required]
        public required string Osztaly_ID { get; set; }
        [Required]
        public required string Torzslapszam { get; set; }
        [Required]
        public required string P_Salt { get; set; }
        [Required]
        public required string P_Hash { get; set; }

        [ForeignKey(nameof(Osztaly_ID))]
        public Osztaly? Osztaly { get; set; }
    }
}
