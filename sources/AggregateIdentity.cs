namespace App
{
    using EventFlow.Core;

    public class AggregateIdentity : Identity<AggregateIdentity>
    {
        public AggregateIdentity(string value) : base(value) { }
    }
}
