
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Handler
{
    public  class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler()
        {
        }

        public TicketBookingResult BookService(TicketBookingRequest request)
        {
            if(request is null) 
                throw new ArgumentNullException(nameof(request));
            return new TicketBookingResult
            {
                Name = request.Name,
                Family = request.Family,
                Email = request.Email
            };
        }
    }
}