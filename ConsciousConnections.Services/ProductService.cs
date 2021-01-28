using ConsciousConnections.Data;
using ConsciousConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    ProductName = model.ProductName,
                    ProductDescription = model.ProductDescription,
                    TypeOfCategory = (CategoryType)model.TypeOfCategory,
                    Price = model.Price,
                    IsFairTradeUSACertified = model.IsFairTradeUSACertified,
                    IsGreenSealCertified = model.IsGreenSealCertified,
                    IsLeapingBunnyCertified = model.IsLeapingBunnyCertified,
                    IsRainForestAllianceCertified = model.IsRainForestAllianceCertified,
                    CompanyId= model.CompanyId,   
                    CreatedUtc = DateTime.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductListItem> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Where(e => e.Company.Id == _userId.ToString()) //product entity associated with customer id equal to the userid associated with the company
                        .Select(
                            e =>
                                new ProductListItem
                                {
                                    ProductId = e.ProductId,
                                    ProductName = e.ProductName,
                                    ProductDescription = e.ProductDescription,
                                    Price = e.Price,
                                    TypeOfCategory = (ProductListItem.CategoryType)(CategoryType)e.TypeOfCategory,
                                    CompanyId = e.CompanyId,
                                    //IsFairTradeUSACertified = e.IsFairTradeUSACertified,
                                    //IsGreenSealCertified = e.IsGreenSealCertified,
                                    //IsLeapingBunnyCertified = e.IsLeapingBunnyCertified,
                                    //IsRainForestAllianceCertified = e.IsRainForestAllianceCertified,
                                    CompanyName = e.Company.CompanyName,
                                  //  CreatedUtc = DateTime.Now
                                }
                        );
                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == id && e.Company.Id == _userId.ToString());
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        ProductName = entity.ProductName,
                        ProductDescription = entity.ProductDescription,
                        TypeOfCategory = (ProductDetail.CategoryType)(CategoryType)entity.TypeOfCategory,                     
                        Price = entity.Price,
                        IsGreenSealCertified = entity.IsGreenSealCertified,
                        IsRainForestAllianceCertified = entity.IsRainForestAllianceCertified,
                        IsFairTradeUSACertified = entity.IsFairTradeUSACertified,
                        IsLeapingBunnyCertified = entity.IsLeapingBunnyCertified,
                        CreatedUtc = DateTime.Now,
                       // ModifiedUtc = DateTimeOffset.Now,
                        ModifiedUtc = entity.ModifiedUtc,
                        // add customer information on customer model to include
                        //Id = entity.Id, convert string to int
                        CompanyId = entity.CompanyId,
                        CompanyName = entity.Company.CompanyName,
                        Reviews = entity.Reviews
                        
                    };
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == model.ProductId && e.Company.Id == _userId.ToString());

                entity.ProductId = model.ProductId;
                entity.ProductName = model.ProductName;
                entity.ProductDescription = model.ProductDescription;
                entity.TypeOfCategory = (CategoryType)model.TypeOfCategory;
                entity.Price = model.Price;
                entity.IsGreenSealCertified = model.IsGreenSealCertified;
                entity.IsRainForestAllianceCertified = model.IsRainForestAllianceCertified;
                entity.IsFairTradeUSACertified = model.IsFairTradeUSACertified;
                entity.IsLeapingBunnyCertified = model.IsLeapingBunnyCertified;
                //entity.CompanyId = model.CompanyId;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(e => e.ProductId == productId && e.Company.Id == _userId.ToString());

                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

