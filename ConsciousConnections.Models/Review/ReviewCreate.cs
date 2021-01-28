using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Review
{
    public class ReviewCreate
    {
        [Required]
        //[MinLength(1, ErrorMessage = "Rating must be between 1 - 5")]
        //[MaxLength(5, ErrorMessage = "Rating must be between 1 - 5")]
        public decimal Rating { get; set; }
        [Required]
        [Display(Name = "Review")]
        [MinLength(15, ErrorMessage = "Review cannot be less than 15 characters")]
        [MaxLength(500, ErrorMessage = "Review cannot be greater than 500 characters")]
        public string ReviewDescription { get; set; }

        //[Display(Name = "User")]
        //public string Id { get; set; }

        [Display(Name = "Product Name")]
        public int ProductId { get; set; }

    }
}
