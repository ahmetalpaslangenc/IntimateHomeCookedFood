using System.Collections.Generic;

namespace IntimateHomeCookedFood.Models
{
    public class MotherDetailViewModel
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public List<MenuItem> Menu { get; set; }
    }
}

