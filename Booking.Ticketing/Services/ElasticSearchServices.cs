using System.Collections.Generic;
using Booking.Ticketing.Dto;

namespace Booking.Ticketing.Services
{
    public class ElasticSearchServices : IElasticSearchServices
    {
        public ElasticSearchIndexer _elasticIndexer;
        public void IndexAll(IEnumerable<TicketLine> ticketsLines, bool overide = false)
        {
            foreach(var ticket in ticketsLines)
            {
                _elasticIndexer.Index(ticket, overide);
            }
        }
    }
}
