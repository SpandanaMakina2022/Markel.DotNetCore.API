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
    public class ClaimService : IClaimsService
    {
        private readonly ILogger<ClaimService> _logger;
        private readonly IClaimsData _claimsData;

        public ClaimService(
            ILogger<ClaimService> logger,
            IClaimsData claimsData)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._claimsData = claimsData ?? throw new ArgumentNullException(nameof(claimsData));
        }
        public async Task<IEnumerable<InsuranceClaim>> GetAll(int companyId)
        {
            return await this.SafeExecuteAsync(async () => await _claimsData.GetAll(companyId));
        }

        public async Task<InsuranceClaim> Get(int id)
        {
            return await this.SafeExecuteAsync(async () =>
            {
                var claim = await this._claimsData.Get(id);

                if (claim != null)
                {
                    claim.ClaimedDays = (DateTime.Now - claim.ClaimDate).Days;
                }

                return claim;
            });
        }

        public async Task<InsuranceClaim> Update(InsuranceClaim claim)
        {
            return await this.SafeExecuteAsync(async () => await _claimsData.Update(claim));
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

                throw new Exception(ex.Message);
            }
        }
    }
}
