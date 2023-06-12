using Insurance.Claims.Abstractions.Data;
using Insurance.Claims.Abstractions.Models;
using Insurance.Claims.Abstractions.Services;
using Insurance.Claims.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Claims.Test
{
    public class CompanyServiceTest
    {
        private Mock<ICompanyData> _mockCompanyData;
        private Mock<ILogger<CompanyService>> _mockLogger;
        private ICompanyService _CompanyService;

        [SetUp]
        public void Setup()
        {
            _mockCompanyData = new Mock<ICompanyData>();
            _mockLogger = new Mock<ILogger<CompanyService>>();
            _CompanyService = new CompanyService(_mockLogger.Object, _mockCompanyData.Object);
        }

        [Test]
        public async Task GetCompanyActivePolicyTest()
        {
            _mockCompanyData
                .Setup(m => m.Get(It.IsAny<int>()))
                .ReturnsAsync(new Company { Id = 101, InsuranceEndDate = DateTime.Now.AddDays(10) });

            var company = await _CompanyService.Get(101);

            Assert.IsNotNull(company);
            Assert.AreEqual(101, company.Id);
            Assert.IsTrue(company.IsPolicyActive);
        }

        [Test]
        public async Task GetCompanyNotActivePolicyTest()
        {
            _mockCompanyData
                .Setup(m => m.Get(It.IsAny<int>()))
                .ReturnsAsync(new Company { Id = 100, Name = "Markel Insurance, Law, & Tax", InsuranceEndDate = DateTime.Now.AddDays(-10) });

            var company = await _CompanyService.Get(101);

            Assert.IsNotNull(company);
            Assert.AreEqual(100, company.Id);
            Assert.AreEqual(_mockCompanyData.Name, company.Name);
            Assert.IsFalse(company.IsPolicyActive);
        }
    }
}
