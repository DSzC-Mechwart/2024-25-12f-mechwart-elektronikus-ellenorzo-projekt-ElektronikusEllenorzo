using System.ComponentModel.DataAnnotations;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class Szak
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string Szak_Nev { get; set; }
    }
}
