namespace IntimateHomeCookedFood.Models
{
    public class CartItem
    {
        public Meal Meal { get; set; }
        public Mother Mother { get; set; }
        public int Quantity { get; set; }
    }
}
