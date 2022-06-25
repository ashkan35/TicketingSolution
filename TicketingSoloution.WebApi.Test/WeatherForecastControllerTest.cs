using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using TicketingSolution.WebApi.Controllers;
using Xunit;

namespace TicketingSolution.WebApi.Test
{
    public class WeatherForecastControllerTest
    {
        [Fact]
        public void Should_Return_WeatherForecastItems()
        {
            //Arrange
            var loggerMoq = new Mock<ILogger<WeatherForecastController>>();
            var weatherController = new WeatherForecastController(loggerMoq.Object);
            //Act
            var result=weatherController.Get();
            //Assert
            result.ShouldNotBeNull();
            result.Count().ShouldBeGreaterThan(1);
        }
    }
}