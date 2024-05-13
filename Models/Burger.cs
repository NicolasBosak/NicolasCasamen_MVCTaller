using System.ComponentModel.DataAnnotations;
using static NicolasCasamen_MVCTaller.Models.Burger;

namespace NicolasCasamen_MVCTaller.Models
{
    public class Burger
    {
        public int BurgerId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        public bool WithCheese { get; set; }
        [VerificarRango]
        public decimal Precio { get; set; }

        public virtual ICollection<Promo> Promos { get; set; } = new List<Promo>();

        public class VerificarRango : ValidationAttribute
        {
            public override bool IsValid(object? value)
            {
                decimal valor = (decimal)value;
                if (valor < 20)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
