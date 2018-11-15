using System.Collections.Generic;
using Booking.Ticketing.Dto;

namespace Booking.Ticketing.Services
{
    public interface IElasticSearchServices
    {
        void IndexAll(IEnumerable<TicketLine> ticketsLines, bool overide = false);
    }
}
