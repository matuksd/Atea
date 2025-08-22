using Atea.Controllers;
using Atea.Models;
using Atea.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Atea.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public void ProcessOrder_InvalidUser_ReturnsBadRequest()
        {
            var mockOrderService = new Mock<OrderService>();
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(s => s.IsValidUser(It.IsAny<int>())).Returns(false);

            var controller = new OrderController(mockOrderService.Object, mockUserService.Object);
            var request = new OrderRequest { UserId = 99 };

            var result = controller.ProcessOrder(request);

            var badRequest = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Invalid user", badRequest.Value);
        }
    }
}
