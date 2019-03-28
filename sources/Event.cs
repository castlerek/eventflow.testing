namespace App
{
    using EventFlow.Aggregates;
    using EventFlow.EventStores;

    [EventVersion("chemical-formula", 1)]
    public class Event : AggregateEvent<Aggregate, AggregateIdentity>
    {
        public Event(string formula)
        {
            Formula = formula;
        }

        public string Formula { get; }
    }
}
