﻿using System.ComponentModel.DataAnnotations;

namespace NicolasCasamen_MVCTaller.Models
{
    public class Burger
    {
        public int BurgerId { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool WithCheese { get; set; }
        [Range(0.01, 9999.99)]
        public decimal Precio { get; set; }
    }

}
