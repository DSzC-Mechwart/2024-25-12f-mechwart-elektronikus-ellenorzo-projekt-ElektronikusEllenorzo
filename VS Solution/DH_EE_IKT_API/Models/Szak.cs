using System.ComponentModel.DataAnnotations;

namespace DH_EE_IKT_API.Models
{
    public class Szak
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string Szak_Nev { get; set; }
    }
}
