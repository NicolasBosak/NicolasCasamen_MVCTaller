using System.ComponentModel.DataAnnotations;

namespace NicolasCasamen_MVCTaller.Models
{
    public class Burger
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool WithCheese { get; set; }
        [VerfivarRango]
        public decimal Precio { get; set; }
        public List<Promo>? Promo { get; set; }
    }
    public class VerfivarRango : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            decimal valor = (decimal)value;
            if(valor < 20)
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
