using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using TicketingSolution.Core.Model;
using TicketingSolution.Core.Handler;

namespace TicketingSolution.Core
{
    public class TicketBookingRequestHandlerTest
    {
        private readonly TicketBookingRequestHandler _handler;
        public TicketBookingRequestHandlerTest()
        {
            _handler = new TicketBookingRequestHandler();

        }
        [Fact]
        public void ShouldReturnBookingResponseWithRequestValues()
        {
            //Arrange
            var bookingRequest = new TicketBookingRequest
            {
                Name = "Ashkan",
                Family = "Semsar",
                Email = "AshkanSemsar@Gmail.com"
            };
            //Act
            TicketBookingResult result = _handler.BookService(bookingRequest);
            //Assert
            //Assert.NotNull(result);
            //Assert.Equal(bookingRequest.Name, result.Name);
            //Assert.Equal(bookingRequest.Family, result.Family);
            //Assert.Equal(bookingRequest.Email, result.Email);
            //Assert with Shouldly
            result.ShouldNotBeNull();
            bookingRequest.Name.ShouldBeSameAs(result.Name);
            bookingRequest.Family.ShouldBeSameAs(result.Family);
            bookingRequest.Email.ShouldBeSameAs(result.Email);
        }

        [Fact]
        public void ShouldThrowNullExceptionForNullRequest()
        {
            Should.Throw<ArgumentNullException>(() => _handler.BookService(null));
        }
    }
}

