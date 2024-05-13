namespace NicolasCasamen_MVCTaller.Models
{
    public class Promo
    {
        public int PromoId { get; set; }

        public string? PromoDescripcion { get; set; }

        public DateTime FechaPromocion { get; set; }

        public int BurgerId { get; set; }

        public virtual Burger Burger { get; set; } = null!;
    }
}
