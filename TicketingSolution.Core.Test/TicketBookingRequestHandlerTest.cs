using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

using Moq;
using TicketingSolution.Core.DataServices;
using TicketingSolution.Core.Domain;
using TicketingSolution.Core.Handler;
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core
{
    public class TicketBookingRequestHandlerTest
    {
        private readonly TicketBookingRequestHandler _handler;
        private readonly TicketBookingRequest _request;
        private readonly Mock<ITicketBookingService> _ticketBookingServiceMock;
        private readonly List<Ticket> _availableTickets;

        public TicketBookingRequestHandlerTest()
        {
            //Arrange
            _request = new TicketBookingRequest
            {
                Name = "Test Name",
                Family = "Test Family",
                Email = "TestEmail",
                Date = DateTime.Now
            };

            _availableTickets = new List<Ticket>() { new Ticket() { Id = 1 } };
            _ticketBookingServiceMock = new Mock<ITicketBookingService>();
            _ticketBookingServiceMock.Setup(q => q.GetAvailableTickets(_request.Date))
                .Returns(_availableTickets);

            _handler = new TicketBookingRequestHandler(_ticketBookingServiceMock.Object);

        }

        [Fact]
        public void Should_Return_Ticket_Booking_Response_With_Request_Values()
        {

            //Act
            var result = _handler.BookService(_request);

            //Assert
            //Assert.NotNull(Result);
            //Assert.Equal(Result.Name, BookingRequest.Name);
            //Assert.Equal(Result.Family, BookingRequest.Family);
            //Assert.Equal(Result.Email, BookingRequest.Email);

            //Assert by Shouldly
            result.ShouldNotBeNull();
            result.Name.ShouldBe(_request.Name);
            result.Family.ShouldBe(_request.Family);
            result.Email.ShouldBe(_request.Email);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            var exception = Should.Throw<ArgumentNullException>(() => _handler.BookService(null));
            exception.ParamName.ShouldBe("request");
        }

        [Fact]
        public void Should_Save_Ticket_Booking_Request()
        {
            TicketBooking savedBooking = null;
            _ticketBookingServiceMock.Setup(x => x.Save(It.IsAny<TicketBooking>()))
                 .Callback<TicketBooking>(booking =>
                 {
                     savedBooking = booking;
                 });

            _handler.BookService(_request);

            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Once);

            savedBooking.ShouldNotBeNull();
            savedBooking.Name.ShouldBe(_request.Name);
            savedBooking.Family.ShouldBe(_request.Family);
            savedBooking.Email.ShouldBe(_request.Email);
            savedBooking.TicketId.ShouldBe(_availableTickets.First().Id);
        }

        [Fact]
        public void Should_Not_Save_Ticket_Booking_Request_If_None_Available()
        {
            _availableTickets.Clear();
            _handler.BookService(_request);
            _ticketBookingServiceMock.Verify(x => x.Save(It.IsAny<TicketBooking>()), Times.Never);
        }

 


    }
}
