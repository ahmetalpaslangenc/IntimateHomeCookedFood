using System;

namespace IntimateHomeCookedFood.Models
{
    public class CartItem
    {
        public Meal? Meal { get; set; } // Nullable yapıldı
        public Mother? Mother { get; set; } // Nullable yapıldı
    }
}
