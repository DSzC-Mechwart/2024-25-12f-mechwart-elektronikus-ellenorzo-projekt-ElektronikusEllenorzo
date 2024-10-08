using System.ComponentModel.DataAnnotations;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class Tanar
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string Nev { get; set; }

    }
}
