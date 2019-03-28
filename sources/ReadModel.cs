namespace App
{
    using EventFlow.Aggregates;
    using EventFlow.ReadStores;

    public class ReadModel : IReadModel, IAmReadModelFor<Aggregate, AggregateIdentity, Event>
    {
        public string Formula { get; private set; }

        public void Apply(IReadModelContext context, IDomainEvent<Aggregate, AggregateIdentity, Event> domainEvent)
        {
            Formula = domainEvent.AggregateEvent.Formula;
        }
    }
}
