
using TicketingSolution.Core.DataServisec;
using TicketingSolution.Core.Domain;
using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Handler
{
    public class TicketBookingRequestHandler
    {
        private readonly ITicketBookingService _ticketBookingService;

        public TicketBookingRequestHandler(ITicketBookingService ticketBookingService)
        {
            _ticketBookingService = ticketBookingService;
        }

        public TicketBookingResult BookService(TicketBookingRequest request)
        {
            if (request is null)
                throw new ArgumentNullException(nameof(request));
            var availabaleTickets = _ticketBookingService.GetAvailableTickets(request.Date);
            if (availabaleTickets.Any())
                _ticketBookingService.Save(CreateTicketBookingObject<TicketBooking>(request));
            return CreateTicketBookingObject<TicketBookingResult>(request);
        }
        private static TTicketBooking CreateTicketBookingObject<TTicketBooking>(TicketBookingRequest ticketBooking) where TTicketBooking : TicketBookingBase, new()
        {
            return new TTicketBooking { Email = ticketBooking.Email, Family = ticketBooking.Family, Name = ticketBooking.Name };
        }
    }
}