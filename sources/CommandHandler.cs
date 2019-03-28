namespace App
{
    using System.Threading;
    using System.Threading.Tasks;
    using EventFlow.Aggregates.ExecutionResults;
    using EventFlow.Commands;

    public class CommandHandler : CommandHandler<Aggregate, AggregateIdentity, IExecutionResult, Command>
    {
        public override Task<IExecutionResult> ExecuteCommandAsync(
            Aggregate aggregate,
            Command command,
            CancellationToken cancellationToken)
        {
            var executionResult = aggregate.SetFormula(command.Formula);
            return Task.FromResult(executionResult);
        }
    }
}
