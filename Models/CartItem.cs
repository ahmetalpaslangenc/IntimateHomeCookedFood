using IntimateHomeCookedFood.Models; // Eğer Meal ve Mother bu namespace içindeyse

namespace IntimateHomeCookedFood.Models
{
    public class CartItem
    {
        public Meal Meal { get; set; }
        public Mother Mother { get; set; }
        public int Quantity { get; set; }
    }
}
