using System.ComponentModel.DataAnnotations;

namespace TicketingSolution.Domain.Domain
{
    public class Ticket
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public ICollection<TicketBooking> TicketBookings { get; set; }
    }
}
