using ConsciousConnections.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Review
{
    public class ReviewListItem
    {
        [Display(Name = "Review ID")]
        public int ReviewId { get; set; }
        public decimal Rating { get; set; }
        [Display(Name = "Created")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset CreatedUtc { get; set; }

        public string ProductName { get; set; }
        public int ProductId { get; set; }

        public string ReviewDescription { get; set; }


        [Display(Name = "User")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
