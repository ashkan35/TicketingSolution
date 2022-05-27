
using TicketingSolution.Core.DataServisec;
using TicketingSolution.Core.Domain;
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Handler
{
    public  class TicketBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingService;

        public TicketBookingRequestHandler(ITicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }

        public TicketBookingResult BookService(TicketBookingRequest request)
        {
            if(request is null) 
                throw new ArgumentNullException(nameof(request));
            _ticketBookingService.Save(new TicketBooking { Name = request.Name, Family = request.Family, Email = request.Email });
            return new TicketBookingResult
            {
                Name = request.Name,
                Family = request.Family,
                Email = request.Email
            };
        }
    }
}