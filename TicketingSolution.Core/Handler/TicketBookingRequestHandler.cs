using TicketingSolution.Core.DataServices;
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
            var availableTickets = _ticketBookingService.GetAvailableTickets(request.Date).ToList();
            if (availableTickets.Any())
            {
                var ticket = availableTickets.First();
                var ticketBooking = CreateTicketBookingObject<TicketBooking>(request);
                ticketBooking.TicketId=ticket.Id;
                _ticketBookingService.Save(ticketBooking);

            }
            return CreateTicketBookingObject<TicketBookingResult>(request);
        }
        private static TTicketBooking CreateTicketBookingObject<TTicketBooking>(TicketBookingRequest ticketBooking) where TTicketBooking : TicketBookingBase, new()
        {
            return new TTicketBooking { Email = ticketBooking.Email, Family = ticketBooking.Family, Name = ticketBooking.Name };
        }
    }
}