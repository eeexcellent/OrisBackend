using System.ComponentModel.DataAnnotations;

namespace OrisBackend.Models
{
    public class User
    {
        [Key]
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
