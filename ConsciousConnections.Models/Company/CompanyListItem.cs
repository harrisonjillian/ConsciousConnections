using ConsciousConnections.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Company
{
    public class CompanyListItem
    {
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }

        public string Website { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        //[Display(Name = "Created")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        //public DateTimeOffset CreatedUtc { get; set; }

    }
}
