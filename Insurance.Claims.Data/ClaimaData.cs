using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insurance.Claims.Abstractions.Data;
using Insurance.Claims.Abstractions.Models;

namespace Insurance.Claims.Data
{
    public class ClaimsData : IClaimsData
    {
        private List<InsuranceClaim> _claims = new List<InsuranceClaim>()
        {             
            new InsuranceClaim()
            {
                CompanyId = 102,
                ClaimDate = DateTime.Now.AddDays(-60),
                AssuredName = "XYZ",
                Closed = true,
                IncurredLoss = 100,
                LossDate = DateTime.Now.AddDays(-70),
                UCR = "100",
                Id = 1
            },
            new InsuranceClaim()
            {
                CompanyId = 102,
                ClaimDate = DateTime.Now.AddDays(-10),
                AssuredName = "XYZ",
                Closed = true,
                IncurredLoss = 100,
                LossDate = DateTime.Now.AddDays(-50),
                UCR = "80",
                Id = 2
            },
            new InsuranceClaim()
            {
                CompanyId = 101,
                ClaimDate = DateTime.Now.AddDays(-20),
                AssuredName = "ABC",
                Closed = false,
                IncurredLoss = 100,
                LossDate = DateTime.Now.AddDays(-40),
                UCR = "",
                Id = 3
            },
            new InsuranceClaim()
            {
                CompanyId = 103,
                ClaimDate = DateTime.Now.AddDays(-10),
                AssuredName = "DEF",
                Closed = true,
                IncurredLoss = 50,
                LossDate = DateTime.Now.AddDays(-50),
                UCR = "70",
                Id = 4
            },
            new InsuranceClaim()
            {
                CompanyId = 100,
                ClaimDate = DateTime.Now.AddDays(-30),
                AssuredName = "Markel",
                Closed = false,
                IncurredLoss = 100,
                LossDate = DateTime.Now.AddDays(-50),
                UCR = "",
                Id = 5
            },
            new InsuranceClaim()
            {
                CompanyId = 100,
                ClaimDate = DateTime.Now.AddDays(-50),
                AssuredName = "Markel",
                Closed = true,
                IncurredLoss = 100,
                LossDate = DateTime.Now.AddDays(-60),
                UCR = "100",
                Id = 6
            }
        };

        public async Task<IEnumerable<InsuranceClaim>> GetAll(int companyId)
        {
            return this._claims.Where(c => c.CompanyId == companyId);
        }

        public async Task<InsuranceClaim> Get(int id)
        {
            return this._claims.FirstOrDefault(c => c.Id == id);
        }

        public async Task<InsuranceClaim> Update(InsuranceClaim claim)
        {
            var existingClaim = this.Get(claim.Id);
            if (existingClaim == null) throw new Exception($"No claim found for claim id {claim.Id}");
            var index = _claims.FindIndex(s => s.Id == claim.Id);
            _claims[index] = claim;

            return _claims[index];

        }
    }
}
