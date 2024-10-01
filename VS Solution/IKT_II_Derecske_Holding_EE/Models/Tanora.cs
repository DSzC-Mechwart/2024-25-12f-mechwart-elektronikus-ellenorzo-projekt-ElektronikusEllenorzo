using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class Tanora
    {
        [Key]
        public required int ID { get; set; }
        [Required]
        public required string Terem { get; set; }
        [Required]
        public required int Tantargy_ID { get; set; }

        [ForeignKey("Tantargy_ID")]
        public required Tantargy Targy { get; set; }
    }
}
