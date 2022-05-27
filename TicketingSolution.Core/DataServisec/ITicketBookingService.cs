using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSolution.Core.Domain;

namespace TicketingSolution.Core.DataServisec
{
    public interface ITicketBookingService
    {
        void Save(TicketBooking ticketBooking);
    }
}
