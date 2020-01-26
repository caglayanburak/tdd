using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using src.Models;
using src.Repository;
using TDDSample.Controllers;

namespace Tests
{
    public class PlanControllerTests
    {
        private PlanController _sut;
        private Mock<IPlanDetailRepository> _planDetailRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _planDetailRepositoryMock = new Mock<IPlanDetailRepository>();
            _sut = new PlanController(_planDetailRepositoryMock.Object);
        }

        [Test]
        public void CreatePlanDetails_TrueStory()
        {
            //Arrange
            int inventoryItemId = 10;
            _planDetailRepositoryMock.Setup(x => x.BulkSaveAsync(It.IsAny<List<PlanDetail>>())).Returns(true);

            //Act
            var result = _sut.CreatePlanDetails(inventoryItemId);

            //Assert
            var okResult = (OkResult)result;
            Assert.AreEqual(okResult.StatusCode, 200);
        }

        [Test]
        public void CreatePlanDetails_WhenInventoryItemHasInserted_ShouldReturnBadRequest()
        {
            //Arrange
            int inventoryItemId = 10;
            _planDetailRepositoryMock.Setup(x => x.IsExists(It.IsAny<int>())).Returns(true);

            //Act
            var result = _sut.CreatePlanDetails(inventoryItemId);

            //Assert

            var badRequestResult = (BadRequestObjectResult)result;
            Assert.AreEqual(badRequestResult.StatusCode, (int)HttpStatusCode.BadRequest);
            Assert.AreEqual("Bu detay daha önce eklenmiştir", badRequestResult.Value);
        }
    }
}