using Insurance.Claims.Abstractions.Models;
using Insurance.Claims.Abstractions.Services;
using Insurance.Claims.API.Utilities;
using Microsoft.AspNetCore.Mvc;


namespace Insurance.Claims.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {

        private readonly IClaimsService _claimsService;

        private readonly ILogger<ClaimsController> _logger;

        public ClaimsController(
            ILogger<ClaimsController> logger,
            IClaimsService claimsService)
        {
            this._logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this._claimsService = claimsService ?? throw new ArgumentNullException(nameof(claimsService));
        }
        // GET api/<ClaimsController>/5
        [HttpGet("company/{companyId}")]
        public async Task<ActionResult<IEnumerable<InsuranceClaim>>> GetCompanyClaims(int companyId)
        {
            return await this.ExecuteAsync(this._logger, this._claimsService, async (client) => await client.GetAll(companyId));
        }

        // GET api/<ClaimsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InsuranceClaim>> Get(int id)
        {
            return await this.ExecuteAsync(this._logger, this._claimsService, async (client) => await client.Get(id));
        }

        // PUT api/<ClaimsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<InsuranceClaim>> Put(int id, [FromBody] InsuranceClaim claim)
        {
            claim.Id = id;
            return await this.ExecuteAsync(this._logger, this._claimsService, async (client) => await client.Update(claim));
        }
    }
}
