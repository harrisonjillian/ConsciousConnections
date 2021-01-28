using ConsciousConnections.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Models//Product
{
    public class ProductListItem
    {
        public enum CategoryType
        {
            Beauty,
            Clothing,
            Health,
            Household,
            Outdoors
        }
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Product Description")]
        public string ProductDescription { get; set; }
        [Display(Name = "Category")]

        public CategoryType TypeOfCategory { get; set; }  // put the values in for the categories
        [DisplayFormat(DataFormatString = "{0:C}")]

        public decimal Price { get; set; }
        //[DefaultValue(false)]
        //[Display(Name = "Green Seal Certified")]
        //public bool IsGreenSealCertified { get; set; }

        //[DefaultValue(false)]
        //[Display(Name = "Rainforest Alliance Certified")]
        //public bool IsRainForestAllianceCertified { get; set; }

        //[DefaultValue(false)]
        //[Display(Name = "Fair Trade USA Certified")]
        //public bool IsFairTradeUSACertified { get; set; }

        //[DefaultValue(false)]
        //[Display(Name = "Leaping Bunny Certified")]
        //public bool IsLeapingBunnyCertified { get; set; }

        //[Display(Name = "Created")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        //public DateTimeOffset CreatedUtc { get; set; }

        public string CompanyName { get; set; }

        public int CompanyId { get; set; }



    }
}
