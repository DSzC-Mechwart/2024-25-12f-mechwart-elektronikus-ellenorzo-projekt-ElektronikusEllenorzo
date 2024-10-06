﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IKT_II_Derecske_Holding_EE.Models
{
    public class Osztaly
    {
        [Key]
        public required string ID { get; set; }
        [Required]
        public required int Evfolyam { get; set; }
        [Required]
        public required int Ofo_ID { get; set; }
        [Required]
        public required int Szak_ID { get; set; }

        [ForeignKey(nameof(Ofo_ID))]
        public Tanar? Osztalyfonok { get; set; }

        [ForeignKey(nameof(Szak_ID))]
        public Szak? Szak { get; set; }
    }
}
