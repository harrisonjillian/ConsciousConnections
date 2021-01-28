using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Review
{
    public class ReviewEdit
    {
        [Display(Name = "Review ID")]
        public int ReviewId { get; set; }
        public decimal Rating { get; set; }
        [Display(Name = "Review")]
        public string ReviewDescription { get; set; }
       // public string Id { get; set; } not sure if i need this

    }
}
