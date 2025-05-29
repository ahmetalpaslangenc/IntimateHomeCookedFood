namespace IntimateHomeCookedFood.Models
{
    public class MenuItem
    {
        public string Id { get; set; }           // Eklendi: Her yemek için benzersiz bir kimlik
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
