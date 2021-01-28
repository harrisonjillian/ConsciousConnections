using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Product
{
    public class ProductCreate
    {
        public enum CategoryType
        {
            Beauty,
            Clothing,
            Health,
            Household,
            Outdoors
        }

        [Required]
        [Display(Name = "Product Name")]
        [MaxLength(50, ErrorMessage = "Product Name cannot be greater than 50 characters")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Product Description")]
        [MaxLength(500, ErrorMessage = "Product Description cannot be greater than 500 characters")]
        [MinLength(10, ErrorMessage = "Product Product cannot be less than 10 characters")]
        public string ProductDescription { get; set; }
        [Required]
        [Display(Name = "Category")]
        public CategoryType TypeOfCategory { get; set; }  // put the values in for the categories

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal Price { get; set; }
        [DefaultValue(false)]
        [Display(Name = "Green Seal Certified")]
        public bool IsGreenSealCertified { get; set; }
        [DefaultValue(false)]
        [Display(Name = "Rainforest Alliance Certified")]
        public bool IsRainForestAllianceCertified { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Fair Trade USA Certified")]
        public bool IsFairTradeUSACertified { get; set; }

        [DefaultValue(false)]
        [Display(Name = "Leaping Bunny Certified")]
        public bool IsLeapingBunnyCertified { get; set; }

        [Display(Name = "Company")]
        public int CompanyId { get; set; }

    }
}

