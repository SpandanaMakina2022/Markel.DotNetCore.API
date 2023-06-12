using Insurance.Claims.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Insurance.Claims.API.Utilities
{
    public static class SafeExecutionHandler
    {
        public static async Task<ActionResult<ReturnType>> ExecuteAsync<ReturnType>(
            this ControllerBase controller,
            ILogger logger,
            ICompanyService companyService,
            Func<ICompanyService, Task<ReturnType>> runnable)
        {
            try
            {
                return controller.Ok(await runnable(companyService));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return controller.StatusCode((int)HttpStatusCode.InternalServerError, new { correlationId = controller.HttpContext.TraceIdentifier, created = DateTime.UtcNow });
            }
        }

        public static async Task<ActionResult<ReturnType>> ExecuteAsync<ReturnType>(
            this ControllerBase controller,
            ILogger logger,
            IClaimsService claimsService,
            Func<IClaimsService, Task<ReturnType>> runnable)
        {
            try
            {
                return controller.Ok(await runnable(claimsService));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return controller.StatusCode((int)HttpStatusCode.InternalServerError, new { correlationId = controller.HttpContext.TraceIdentifier, created = DateTime.UtcNow });
            }
        }
    }
}
