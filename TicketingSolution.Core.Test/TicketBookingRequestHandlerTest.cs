using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using TicketingSolution.Core.Model;
using TicketingSolution.Core.Handler;
using Moq;
using TicketingSolution.Core.DataServisec;
using TicketingSolution.Core.Domain;

namespace TicketingSolution.Core
{
    public class TicketBookingRequestHandlerTest
    {
        private readonly TicketBookingRequest _request;
        private readonly TicketBookingRequestHandler _handler;
        private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;

        public TicketBookingRequestHandlerTest()
        {
            _request = new TicketBookingRequest
            {
                Name = "Ashkan",
                Family = "Semsar",
                Email = "AshkanSemsar@Gmail.com"
            };
          
            _ticketBookingServiceMock = new Mock<ITicketBookingService>();
            _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);
        }
        [Fact]
        public void ShouldReturnBookingResponseWithRequestValues()
        {
            //Arrange
            
            //Act
            TicketBookingResult result = _handler.BookService(_request);
            //Assert
            //Assert.NotNull(result);
            //Assert.Equal(bookingRequest.Name, result.Name);
            //Assert.Equal(bookingRequest.Family, result.Family);
            //Assert.Equal(bookingRequest.Email, result.Email);
            //Assert with Shouldly
            result.ShouldNotBeNull();
            _request.Name.ShouldBeSameAs(result.Name);
            _request.Family.ShouldBeSameAs(result.Family);
            _request.Email.ShouldBeSameAs(result.Email);
        }

        [Fact]
        public void ShouldThrowNullExceptionForNullRequest()
        {
           
            Should.Throw<ArgumentNullException>(() => _handler.BookService(null));
        }
        [Fact]
        public void ShouldSaveTicketBookingRequest()
        {
            TicketBooking savedBooking = null;
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>())).Callback<TicketBooking>(c => { savedBooking = c; });
            _handler.BookService(_request);
            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()),Times.Once);

        }
    }
}

