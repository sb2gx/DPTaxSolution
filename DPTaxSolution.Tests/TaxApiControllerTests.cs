using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using DPTaxSolution.API.Controllers;
using DPTaxSolution.Core;
using DPTaxSolution.Core.Entities;
using DPTaxSolution.Core.Interfaces;
using DPTaxSolution.Core.DTO;

namespace DPTaxSolution.Tests
{
    [TestFixture]
    public class TaxApiControllerTests
    {
        [Test]
        public async Task GetAllTaxRecords_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<ITaxRepository>();
            mockRepository.Setup(repo => repo.GetAllTaxRecords()).Returns(new List<TaxRecord>());
            var controller = new TaxApiController(null, mockRepository.Object);

            // Act
            var result = controller.GetAllTaxRecords().Result;

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task GetTaxRecordById_ExistingId_ReturnsOkResult()
        {
            // Arrange
            const int existingId = 1;
            var mockRepository = new Mock<ITaxRepository>();
            mockRepository.Setup(repo => repo.GetTaxRecordById(existingId)).Returns(new TaxRecord { Id = existingId });
            var controller = new TaxApiController(null, mockRepository.Object);

            // Act
            var result = controller.GetTaxRecordById(existingId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
        }

        [Test]
        public async Task GetTaxRecordById_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            const int nonExistingId = 999;
            var mockRepository = new Mock<ITaxRepository>();
            mockRepository.Setup(repo => repo.GetTaxRecordById(nonExistingId)).Returns((TaxRecord)null);
            var controller = new TaxApiController(null, mockRepository.Object);

            // Act
            var result = controller.GetTaxRecordById(nonExistingId).Result;

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

    }
}