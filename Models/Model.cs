using System.ComponentModel.DataAnnotations;

namespace IntimateHomeCookedFood.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty; // Varsayılan değer olarak boş string

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty; // Varsayılan değer olarak boş string

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty; // Varsayılan değer olarak boş string

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty; // Varsayılan değer olarak boş string
    }
}
