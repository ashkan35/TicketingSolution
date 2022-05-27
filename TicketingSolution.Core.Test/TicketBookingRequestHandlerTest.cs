using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSolution.Core
{
    public class TicketBookingRequestHandlerTest
    {
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
            TicketBookingResult result = Handler.BookService();
            //Assert
        }
    }
}
