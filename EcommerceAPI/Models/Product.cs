using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, StringLength(255)]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Ensures correct precision in SQL Server
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;

        [Required, StringLength(100)]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public int Stock { get; set; }

        public float Rating { get; set; } = 0.0f;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
  
        public virtual TrendingProduct? TrendingProduct { get; set; }
        public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>(); // ✅ Fix added
    }
}
