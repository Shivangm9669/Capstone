using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceAPI.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!; 

        [Column(TypeName = "decimal(18,2)")] 
        public decimal TotalAmount { get; set; } = 0;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
