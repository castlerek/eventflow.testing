using System.Threading;
using System.Threading.Tasks;
using EventFlow;
using EventFlow.Extensions;
using EventFlow.Queries;
using FluentAssertions;
using Xunit;
using App;

namespace TestSuite
{
    public class DddTests
    {
        [Fact]
        public async Task TestingReadModel()
        {
            const string awaitedValue = "C11H12N2O2";

            using (var resolver = EventFlowOptions.New
                .AddEvents(typeof(Event))
                .AddCommands(typeof(Command))
                .AddCommandHandlers(typeof(CommandHandler))
                .UseInMemoryReadStoreFor<ReadModel>()
                .CreateResolver())
            {
                var identity = AggregateIdentity.New;
                const string tryptophanFormula = "C11H12N2O2";

                var commandBus = resolver.Resolve<ICommandBus>();
                var result = await commandBus.PublishAsync(
                    new Command(identity, tryptophanFormula),
                    CancellationToken.None)
                    .ConfigureAwait(false);

                result.IsSuccess.Should().BeTrue();

                var processor = resolver.Resolve<IQueryProcessor>();
                var readModel = await processor.ProcessAsync(
                    new ReadModelByIdQuery<ReadModel>(identity),
                    CancellationToken.None)
                    .ConfigureAwait(false);

                readModel.Formula.Should().Be(awaitedValue);
            }
        }
    }
}
