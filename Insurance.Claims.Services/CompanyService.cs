using Insurance.Claims.Abstractions.Data;
using Insurance.Claims.Abstractions.Models;
using Insurance.Claims.Abstractions.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> _logger;
        private readonly ICompanyData _companyData;

        public CompanyService(
            ILogger<CompanyService> logger,
            ICompanyData companyData)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._companyData = companyData ?? throw new ArgumentNullException(nameof(companyData));
        }

        public async Task<Company> Get(int id)
        {
            return await this.SafeExecuteAsync(async () =>
            {
                var company = await this._companyData.Get(id);

                if (company != null)
                {
                    company.IsPolicyActive = company.InsuranceEndDate > DateTime.Now;
                }

                return company;

            });
        }

        private async Task<ReturnType> SafeExecuteAsync<ReturnType>(Func<Task<ReturnType>> runnable)
        {
            try
            {
                return await runnable();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, ex.Message);

                throw new Exception("Unknown error occured");
            }
        }
    }
}
