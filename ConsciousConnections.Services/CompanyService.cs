using ConsciousConnections.Data;
using ConsciousConnections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Services
{
    public class CompanyService 
    { 

        private readonly Guid _userId;

    public CompanyService(Guid userId)
    {
        _userId = userId;
    }

    public bool CreateCompany(CompanyCreate model)
    {
        var entity =
            new Company()
            {
                Id = _userId.ToString(),
                CompanyName = model.CompanyName,
                CompanyDescription = model.CompanyDescription,
                StreetAddress = model.StreetAddress,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode,
                WebSite = model.Website,
                PhoneNumber = model.PhoneNumber,
                CreatedUtc = DateTime.Now,
                
            };

        using (var ctx = new ApplicationDbContext())
        {
            ctx.Companies.Add(entity);
            return ctx.SaveChanges() == 1;
        }
    }
        public IEnumerable<CompanyListItem> GetCompanies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Companies
                        .Where(e => e.Id == _userId.ToString())
                        .Select(
                            e =>
                                new CompanyListItem
                                {
                                    CompanyId = e.CompanyId,
                                    CompanyName = e.CompanyName,
                                    CompanyDescription = e.CompanyDescription,
                                    Website = e.WebSite,
                                    
                                    Products = e.Products,
                                    
                         
                                    //CreatedUtc = DateTime.Now
                                }
                        );

                return query.ToArray();
            }
        }


        public CompanyDetail GetCompanyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyId == id && e.Id == _userId.ToString());
                return
                    new CompanyDetail
                    {
                        CompanyId = entity.CompanyId,
                        CompanyName = entity.CompanyName,
                        CompanyDescription = entity.CompanyDescription,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        ZipCode = entity.ZipCode,
                        Website = entity.WebSite,
                        PhoneNumber = entity.PhoneNumber,
                        CreatedUtc = DateTime.Now,
                        ProductId = entity.ProductId,                      
                        ModifiedUtc = entity.ModifiedUtc,
                       
                    };
            }
        }

        public bool UpdateCompany(CompanyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyId == model.CompanyId && e.Id == _userId.ToString());

                entity.CompanyId = model.CompanyId;
                entity.CompanyName = model.CompanyName;
                entity.CompanyDescription = model.CompanyDescription;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.ZipCode = model.ZipCode;
                entity.WebSite = model.Website;
                entity.PhoneNumber = model.PhoneNumber;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteCompany(int companyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Companies
                        .Single(e => e.CompanyId == companyId && e.Id == _userId.ToString());

                ctx.Companies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}



