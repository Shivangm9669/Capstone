using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EcommerceAPI.Models
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]
        public string Tier { get; set; } = string.Empty;// ENUM(free, premium)

        public DateTime ValidUntil { get; set; }

        [Required]
        public string Status { get; set; }  = string.Empty;  // ENUM(active, expired, cancelled)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}