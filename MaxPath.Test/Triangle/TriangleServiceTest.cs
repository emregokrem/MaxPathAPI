using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MatxPath.Operation.Service;
using MaxPath.Domain.Request;
using MaxPath.Infrastructure.Extensions;
using Xunit;

namespace MaxPath.Test.Triangle
{
    public class TriangleServiceTest
    {
        private readonly ITriangleService _service;
        public TriangleServiceTest()
        {
            var loggerManager = new LoggerManager();
            _service = new TriangleService(loggerManager);
        }
        [Fact]
        public void GetTriangle_WithValidTree_()
        {
            //Arrange
            var request = new TriangleRequest()
            {
                Triangle = "1\n8 9\n1 5 9\n4 5 2 3"
            };

            // Act
            var okResult = _service.CalculateTriangle(request);
            // Assert
            Assert.True(okResult.IsValidPath);
        }

        [Fact]
        public void GetTriangle_WithInvalidShortTree_()
        {
            //Arrange
            var request = new TriangleRequest()
            {
                Triangle = "1\n8 9\n1 5\n4 5 2 3"
            };

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _service.CalculateTriangle(request));

        }

        [Fact]
        public void GetTriangle_WithInvalidLongTree_()
        {
            //Arrange
            var request = new TriangleRequest()
            {
                Triangle = "1\n8 9\n1 5 9 12\n4 5 2 3"
            };

            // Act & Assert
            var ex = Assert.Throws<Exception>(() => _service.CalculateTriangle(request));

        }
    }
}
