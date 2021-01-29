using System;
using System.Collections.Generic;
using ConsciousConnections.Models;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsciousConnections.Contracts
{
    public interface ICompanyService
    {
        Guid UserId { get; set; }  //should this be a string??
        bool CreateCompany(CompanyCreate model);
        IEnumerable<CompanyListItem> GetCompanies();
        CompanyDetail GetCompanyById(int id);
        bool UpdateCompany(CompanyEdit model);
        bool DeleteCompany(int companyId);

    }
}
