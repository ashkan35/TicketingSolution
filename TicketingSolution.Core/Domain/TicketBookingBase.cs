using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketingSolution.Core.Domain
{
    public abstract class TicketBookingBase
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
    }
}
