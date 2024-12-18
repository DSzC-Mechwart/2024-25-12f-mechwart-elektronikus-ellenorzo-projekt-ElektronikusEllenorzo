using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class Orarend
    {
        [Key]
        public required int ID { get; set; }
        [Required]
        public required string Osztaly_ID { get; set; }
        public int? Elso_Tanora_ID { get; set; }
        public int? Masodik_Tanora_ID { get; set; }
        public int? Harmadik_Tanora_ID { get; set; }
        public int? Negyedik_Tanora_ID { get; set; }
        public int? Otodik_Tanora_ID { get; set; }
        public int? Hatodik_Tanora_ID { get; set; }
        public int? Hetedik_Tanora_ID { get; set; }
        public int? Nyolcadik_Tanora_ID { get; set; }

    }
}
