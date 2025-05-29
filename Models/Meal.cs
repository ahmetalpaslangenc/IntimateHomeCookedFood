using System;
using System.ComponentModel.DataAnnotations;

namespace IntimateHomeCookedFood.Models
{
    public class Meal
    {
        [Key]
        public string Id { get; set; } = string.Empty; // Artık string ID kullanılıyor

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty;

        public DateTime DatePosted { get; set; } = DateTime.Now;

        public string UserId { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}
