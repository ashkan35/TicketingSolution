using System.ComponentModel.DataAnnotations;
using TicketingSolution.Domain.BaseModels;

namespace TicketingSolution.Domain.Domain
{
    public  class TicketBooking:TicketBookingBase
    {
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        public int TicketId { get; set; }
    }
}
