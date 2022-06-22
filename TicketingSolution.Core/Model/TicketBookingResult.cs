using TicketingSolution.Core.Enum;
using TicketingSolution.Domain.BaseModels;

namespace TicketingSolution.Core.Model
{
    public class TicketBookingResult:TicketBookingBase
    {
        public BookingResultFlag Flag { get; set; }
        public int? TicketBookingId { get; set; }
    }
}