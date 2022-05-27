
namespace TicketingSolution.Core
{
    public  class TicketBookingRequestHandler
    {
        public TicketBookingRequestHandler()
        {
        }

        public TicketBookingResult BookService(TicketBookingRequest request)
        {
            return new TicketBookingResult
            {
                Name = request.Name,
                Family = request.Family,
                Email = request.Email
            };
        }
    }
}