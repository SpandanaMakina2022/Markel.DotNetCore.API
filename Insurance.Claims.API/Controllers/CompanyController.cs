using Insurance.Claims.Abstractions.Models;
using Insurance.Claims.Abstractions.Services;
using Insurance.Claims.API.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Insurance.Claims.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        private readonly ILogger<CompanyController> _logger;

        public CompanyController(
            ILogger<CompanyController> logger,
            ICompanyService companyService)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._companyService = companyService ?? throw new ArgumentNullException(nameof(companyService));
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            return await this.ExecuteAsync(this._logger, this._companyService, async (client) => await client.Get(id));
        }
    }
}
