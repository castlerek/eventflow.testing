namespace App
{
    using EventFlow.Aggregates;
    using EventFlow.Aggregates.ExecutionResults;

    public class Aggregate : AggregateRoot<Aggregate, AggregateIdentity>, IEmit<Event>
    {
        private string _chemicalFormula;

        public Aggregate(AggregateIdentity id) : base(id) { }

        public IExecutionResult SetFormula(string value)
        {
            if (!string.IsNullOrEmpty(this._chemicalFormula)) {
                return ExecutionResult.Failed("Chemical formula is already set.");
            }

            Emit(new Event(value));
            return ExecutionResult.Success();
        }

        public void Apply(Event aggregateEvent)
        {
            this._chemicalFormula = aggregateEvent.Formula;
        }
    }
}
