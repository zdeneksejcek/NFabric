using System;
using NFabric.BoundedContext;
using MongoDB.Driver;
using System.Text;
using System.Linq;
using MongoDB.Driver.Builders;

namespace NFabric.Infrastructure.Mongo
{
    public class MongoEventStreamRepository : IEventStreamRepository
    {
        private MongoCollection Collection { get; set; }

        public MongoEventStreamRepository()
        {
            MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient();
            Collection = client.GetServer().GetDatabase("nfabric").GetCollection("events");
        }

        public EventStream GetStream(Guid aggregateId, int? withSequenceHigherThan = default(int?))
        {
            //var oooo = Collection.FindAllAs<EventDocument>().ToList();

            var query = Query.EQ("AggId", aggregateId);

            if (withSequenceHigherThan != null)
                query = Query.And(query, Query.GT("Sequence", withSequenceHigherThan.Value));

            var docs = Collection.FindAs<EventDocument>(query).ToList();

            var records = docs.Select(
                             p => new EventRecord(
                                    p.AggId,
                                    p.Sequence,
                                    p.TypeName,
                                    p.Event,
                                    p.AdditionalData)).ToList();

            return new EventStream(records);
        }

        public void Append(EventStream stream)
        {
            var documents = stream.Events.Select(
                p=>new EventDocument(
                    p.AggregateId,
                    p.Sequence,
                    p.TypeName,
                    p.Event,
                    p.AdditionalData)).ToList();

            Collection.InsertBatch<EventDocument>(documents);
        }
    }
}