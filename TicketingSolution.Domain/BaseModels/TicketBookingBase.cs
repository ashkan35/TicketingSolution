namespace TicketingSolution.Domain.BaseModels
{
    public abstract class TicketBookingBase
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
    }
}
