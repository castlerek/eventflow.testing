namespace App
{
    using EventFlow.Aggregates.ExecutionResults;
    using EventFlow.Commands;

    public class Command : Command<Aggregate, AggregateIdentity, IExecutionResult>
    {
        public Command(AggregateIdentity aggregateId, string formula) : base(aggregateId)
        {
            Formula = formula;
        }

        public string Formula { get; }
    }
}
