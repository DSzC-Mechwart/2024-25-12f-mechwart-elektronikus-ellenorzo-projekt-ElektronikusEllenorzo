using System.ComponentModel.DataAnnotations;

namespace DH_EE_IKT_API.Models
{
    public class Tanar
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public required string Nev { get; set; }
        [Required]
        public required string P_Salt { get; set; }
        [Required]
        public required string P_Hash { get; set; }
    }
}
