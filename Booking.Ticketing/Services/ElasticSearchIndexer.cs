using Booking.Ticketing.Dto;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Ticketing.Services
{
    public class ElasticSearchIndexer
    {

        protected readonly ElasticClient Client;

        protected string IndexName = "";
        public ElasticSearchIndexer()
        {
            Client = InitClient("");
            InitIndexes();
        }

        private ElasticClient InitClient(string serverUri)
        {
            var node = new Uri(serverUri);
            var settings = new ConnectionSettings(node);
            settings.DefaultIndex(IndexName);
            settings.PrettyJson();
            settings.DisableDirectStreaming();
            return new ElasticClient(settings);
        }

        private void InitIndexes()
        {
            if (!Client.IndexExists(Indices.Parse(IndexName)).Exists)
            {
                var indexDescriptor = new CreateIndexDescriptor(IndexName).Mappings(ms => ms.Map<TicketLine>(m => m.AutoMap()));
                var creactionResult = Client.CreateIndex(IndexName, i => indexDescriptor);
            }
        }

        public IIndexResponse Index(TicketLine data, bool ovveride = false)
        {
            Refresh();
            if (ovveride)
            {
                DeleteIfExists(data.IndexKey);
            }
            return Client.Index(data, cl => cl.Index(IndexName));
        }

        protected void DeleteIfExists(string elementKey)
        {
            var currentDocument = GetByKey(elementKey);
            if (currentDocument != null)
            {
                Client.Delete<TicketLine>(currentDocument);
            }
        }

        private TicketLine GetByKey(string elementKey)
        {
            var container = new QueryContainerDescriptor<TicketLine>();
            var termQueries = new List<QueryContainer> { container.Term(t => t.Field(AsKeyWord("indexKey")).Value(elementKey)) };

            var response = Client.Search<TicketLine>(cl => cl
                .Index(IndexName)
                .Query(q => q.Bool(b => b.Must(termQueries.ToArray()))));
            return response.Documents.FirstOrDefault();
        }

        private void Refresh()
        {
            Client.Refresh(IndexName);
        }

        protected string AsKeyWord(string key)
        {
            return $"{key}.keyword";
        }
    }
}
