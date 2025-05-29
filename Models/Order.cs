using System.Collections.Generic;

namespace IntimateHomeCookedFood.Models
{
    public class Order
    {
        public string? UserEmail { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
