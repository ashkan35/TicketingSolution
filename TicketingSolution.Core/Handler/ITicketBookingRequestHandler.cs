using TicketingSolution.Core.Model;

namespace TicketingSolution.Core.Handler;

public interface ITicketBookingRequestHandler
{
    TicketBookingResult BookService(TicketBookingRequest request);
}