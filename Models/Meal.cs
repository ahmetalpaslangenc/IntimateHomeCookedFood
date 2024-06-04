using System;
using System.ComponentModel.DataAnnotations;

namespace IntimateHomeCookedFood.Models
{
    public class Meal
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Title { get; set; } = string.Empty; // Title ekleniyor

        public DateTime DatePosted { get; set; } = DateTime.Now; // DatePosted ekleniyor

        public string UserId { get; set; } = string.Empty; // UserId ekleniyor

        public string ImageUrl { get; set; } = string.Empty; // ImageUrl ekleniyor
    }
}
