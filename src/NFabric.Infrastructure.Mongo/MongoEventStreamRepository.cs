using System;
using NFabric.BoundedContext.Persistence;
using MongoDB.Driver;
using System.Text;
using System.Linq;
using MongoDB.Driver.Builders;
using NFabric.BoundedContext.Domain;
using System.Collections.Generic;
using NFabric.Common.Messaging;

namespace NFabric.Infrastructure.Mongo
{
    public class MongoEventStreamRepository : MarshalByRefObject, IEventsReader
    {
        private MongoCollection Collection { get; set; }

        public MongoEventStreamRepository()
        {
            MongoDB.Driver.MongoClient client = new MongoDB.Driver.MongoClient();
            Collection = client.GetServer().GetDatabase("nfabric").GetCollection("events");
        }

        public IList<Guid> GetSOs() {
            return Collection.FindAllAs<EventDocument>().SetLimit(100).Select(p=>p.AggId).ToList();
        }

        public IList<EventRecord> GetStream(Guid aggregateId, int? withSequenceHigherThan = default(int?))
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
                                    p.Name,
                                    p.BoundedContext,
                                    p.SerializedEvent,
                                    p.AdditionalData)).ToList();

            return records;
        }

        public void Append(UncommitedMessage[] messages) {
            var documents = messages.Where(p=>p.Type == "event").Select(
                p=>new EventDocument(
                    p.AggregateId,
                    p.Sequence,
                    p.Name,
                    p.BoundedContext,
                    p.Body,
                    null)).ToList();

            Collection.InsertBatch<EventDocument>(documents);
        }
        /*
        public void Append(IList<SequencedEvent> events)
        {
            var documents = events.Select(
                p=>new EventDocument(
                    p.AggregateId,
                    p.Sequence,
                    "event",
                    p.,
                    p.AdditionalData)).ToList();

            Collection.InsertBatch<EventDocument>(documents);
        }
        */
    }
}