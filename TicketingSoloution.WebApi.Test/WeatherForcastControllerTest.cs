using Xunit;
using Moq;
using TicketingSolution.WebApi.Controllers;
using Microsoft.Extensions.Logging;
using System.Linq;
using Shouldly;

namespace TicketingSoloution.WebApi.Test
{
    public class WeatherForcastControllerTest
    {
        [Fact]
        public void Should_Return_WeatherForcastItems()
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