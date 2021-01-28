using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Company
{
    public class CompanyEdit
    {
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        [MaxLength(200, ErrorMessage = "Company Name cannot be greater than 200 characters")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Description")]
        public string CompanyDescription { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        public string Website { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Modified")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
