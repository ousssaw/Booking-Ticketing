using System;
using System.Collections.Generic;
using Booking.Ticketing.Dto;

namespace Booking.Ticketing.Services
{
    public class ElasticSearchServices : IElasticSearchServices
    {
        private readonly ElasticSearchIndexer _elasticIndexer;

        public ElasticSearchServices(ElasticSearchIndexer elasticIndexer)
        {
            _elasticIndexer = elasticIndexer;
        }
        public void IndexAll(IEnumerable<TicketLine> ticketsLines, bool overrides = false)
        {
            int cmp = 0;
            DateTime start = DateTime.Now;
            foreach(var ticket in ticketsLines)
            {
                _elasticIndexer.Index(ticket, overrides);
                cmp++;

            }
            DateTime end = DateTime.Now;
            Console.WriteLine($"indexation of {cmp} lines took {(end - start).TotalSeconds}");
        }
    }
}
