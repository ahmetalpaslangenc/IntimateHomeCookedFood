namespace IntimateHomeCookedFood.Models
{
    public class Mother
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Meal> Meals { get; set; } = new List<Meal>();
        public double Rating { get; set; }

        // Meals listesinin boş olmasını engellemek için constructor ekleyin
        public Mother()
        {
            Meals = new List<Meal>();
        }
    }
}