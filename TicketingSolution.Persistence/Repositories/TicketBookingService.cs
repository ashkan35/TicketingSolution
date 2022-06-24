using TicketingSolution.Core.DataServices;
using TicketingSolution.Domain.Domain;

namespace TicketingSolution.Persistence.Repositories;

public class TicketBookingService:ITicketBookingService
{
    private readonly TicketingSolutionDbContext _context;

    public TicketBookingService(TicketingSolutionDbContext context)
    {
        _context = context;
    }
    public void Save(TicketBooking ticketBooking)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Ticket> GetAvailableTickets(DateTime date)
    {
        return _context.Tickets.Where(x=>x.Date==date&&!x.TicketBookings.Any(c=>c.TicketId==x.Id));
    }
}