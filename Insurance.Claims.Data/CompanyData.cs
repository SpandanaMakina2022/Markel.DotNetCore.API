using Insurance.Claims.Abstractions.Data;
using Insurance.Claims.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Data
{
    public class CompanyData : ICompanyData
    {
        private List<Company> _companyList = new List<Company>()
        {
            new Company()
            {
                Active = true,
                Id = 100,
                Name = "Markel Insurance, Law, & Tax",
                Address1 = "20",
                Address2 = "Fenchurch Street",
                Address3 = "London",
                Country = "UK",
                Postcode = "EC3M3AZ",
                InsuranceEndDate = DateTime.Now.AddDays(50)
            },
            new Company()
            {
                Active = true,
                Id = 101,
                Name = "ABC Insurance Company",
                Address1 = "155 Road",
                Address2 = "Watford",
                Address3 = "HR",
                Country = "UK",
                Postcode = "WD244HB",
                InsuranceEndDate = DateTime.Now.AddDays(100)
            },
            new Company()
            {
                Active = true,
                Id = 102,
                Name = "XYZ Insurance Company",
                Address1 = "155 Road",
                Address2 = "Watford",
                Address3 = "HR",
                Country = "UK",
                Postcode = "XY244HC",
                InsuranceEndDate = DateTime.Now.AddDays(10)
            },
            new Company()
            {
                Active = false,
                Id = 103,
                Name = "SP Insurance Company",
                Address1 = "155 Road",
                Address2 = "SP",
                Address3 = "HR",
                Country = "UK",
                Postcode = "SP264HD",
                InsuranceEndDate = DateTime.Now.AddDays(-1)
            },
            new Company()
            {
                Active = true,
                Id = 104,
                Name = "AD Insurance Company",
                Address1 = "155 Road",
                Address2 = "AD",
                Address3 = "HR",
                Country = "UK",
                Postcode = "AD244HB",
                InsuranceEndDate = DateTime.Now.AddDays(50)
            }
        };

        public async Task<Company> Get(int id)
        {
            return this._companyList.FirstOrDefault(c => c.Id == id);
        }
    }
}
