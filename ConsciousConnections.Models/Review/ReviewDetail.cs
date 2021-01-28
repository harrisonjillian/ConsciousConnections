using ConsciousConnections.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Review
{
    public class ReviewDetail
    {
        [Display(Name = "Review ID")]
        public int ReviewId { get; set; }
        public decimal Rating { get; set; }
        [Display(Name = "Review")]
        public string ReviewDescription { get; set; }
        [Display(Name = "Created")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset? ModifiedUtc { get; set; }  

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Display(Name = "Product Name")]
        [MaxLength(50, ErrorMessage = "Product Name cannot be greater than 50 characters")]
        public string ProductName { get; set; }

        [Display(Name = "User")]
        public int Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

}

