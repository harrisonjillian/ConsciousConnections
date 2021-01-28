using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Company
{
    public class CompanyCreate
    {
        [Required]
        [Display(Name = "Company Name")]
        [MaxLength(50, ErrorMessage = "Company Name cannot be greater than 50 characters")]
        public string CompanyName { get; set; }

        [Required]
        [Display(Name = "Company Description")]
        [MaxLength(200, ErrorMessage = "Company Description cannot be greater than 200 characters")]
        public string CompanyDescription { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(2, ErrorMessage ="State cannot be less than 2 characters")]
        [MaxLength(2, ErrorMessage = "State cannot be greater than 2 characters")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public int CompanyId { get; set; }
    }
}
