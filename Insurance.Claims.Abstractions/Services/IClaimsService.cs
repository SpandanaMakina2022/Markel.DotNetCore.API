using Insurance.Claims.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Abstractions.Services
{
    public interface IClaimsService
    {
        Task<IEnumerable<InsuranceClaim>> GetAll(int companyId);

        Task<InsuranceClaim> Get(int id);

        Task<InsuranceClaim> Update(InsuranceClaim claim);
    }
}
