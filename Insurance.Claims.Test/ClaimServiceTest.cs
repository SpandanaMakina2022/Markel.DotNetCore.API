using Insurance.Claims.Abstractions.Data;
using Insurance.Claims.Abstractions.Models;
using Insurance.Claims.Abstractions.Services;
using Insurance.Claims.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Test
{
    public class ClaimServiceTest
    {
        private Mock<IClaimsData> _mockClaimData;
        private Mock<ILogger<ClaimService>> _mockLogger;
        private IClaimsService _ClaimService;

        [SetUp]
        public void Setup()
        {
            _mockClaimData = new Mock<IClaimsData>();
            _mockLogger = new Mock<ILogger<ClaimService>>();
            _ClaimService = new ClaimService(_mockLogger.Object, _mockClaimData.Object);
        }

        [Test]
        public async Task GetClaimedDaysTest()
        {
            _mockClaimData
                .Setup(m => m.Get(It.IsAny<int>()))
                .ReturnsAsync(new InsuranceClaim { Id = 5, AssuredName= "Markel", ClaimDate = DateTime.Now.AddDays(-30) });

            var claim = await _ClaimService.Get(5);

            Assert.IsNotNull(claim);
            Assert.AreEqual(5, claim.Id);
            Assert.AreEqual("Markel", claim.AssuredName);
            Assert.AreEqual(30, claim.ClaimedDays);
        }

        
    }
}
