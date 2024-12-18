using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DH_EE_IKT_API.Models
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

        [ForeignKey("Elso_Tanora_ID")]
        public Tanora? Elso_Ora { get; set; }

        [ForeignKey("Masodik_Tanora_ID")]
        public Tanora? Masodik_Ora { get; set; }

        [ForeignKey("Harmadik_Tanora_ID")]
        public Tanora? Harmadik_Ora { get; set; }

        [ForeignKey("Negyedik_Tanora_ID")]
        public Tanora? Negyedik_Ora { get; set; }

        [ForeignKey("Otodik_Tanora_ID")]
        public Tanora? Otodik_Ora { get; set; }

        [ForeignKey("Hatodik_Tanora_ID")]
        public Tanora? Hatodik_Ora { get; set; }

        [ForeignKey("Hetedik_Tanora_ID")]
        public Tanora? Hetedik_Ora { get; set; }

        [ForeignKey("Nyolcadik_Tanora_ID")]
        public Tanora? Nyolcadik_Ora { get; set; }
    }
}
