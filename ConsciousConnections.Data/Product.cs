using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Data
{
    public enum CategoryType
    {
        Beauty,
        Clothing,
        Health,
        Household,
        Outdoors
    }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        //[Required]
        public CategoryType TypeOfCategory { get; set; }  // put the values in for the categories

        [Required]
        public decimal Price { get; set; }
        [DefaultValue(false)]
        public bool IsGreenSealCertified { get; set; }
        [DefaultValue(false)]
        public bool IsRainForestAllianceCertified { get; set; }

        [DefaultValue(false)]
        public bool IsFairTradeUSACertified { get; set; }

        [DefaultValue(false)]
        public bool IsLeapingBunnyCertified { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey(nameof(ApplicationUser))]  //  don't need this as the product is created by the company
        [Display(Name = "User")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        //[Required]
        [ForeignKey(nameof(Company))]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}

