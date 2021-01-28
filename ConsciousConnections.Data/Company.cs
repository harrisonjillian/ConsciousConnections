using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Data
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyDescription { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string WebSite { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        [Display(Name = "User")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

        public int ProductId { get; set; }
    }
}
