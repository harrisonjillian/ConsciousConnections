using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Data
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [Required]
        public decimal Rating { get; set; }
        [Required]
        public string ReviewDescription { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; } //look up DateTime formats 

        public DateTimeOffset? ModifiedUtc { get; set; }  // look up DateTime formats

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        [Display(Name = "User")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
