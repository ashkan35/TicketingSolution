using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;

namespace TicketingSolution.Core
{
    public class TicketBookingRequestHandlerTest
    {
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
            var Handler = new TicketBookingRequestHandler();
            //Act
            TicketBookingResult result = Handler.BookService(bookingRequest);
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
    }
}

