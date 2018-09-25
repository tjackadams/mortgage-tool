namespace Mortgage.Domain.Common
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class AggregateRoot : AggregateRoot<int>
    {
    }

    public class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
    {
        public AggregateRoot()
        {
            DomainEvents = new Collection<IDomainEvent>();
        }

        public virtual ICollection<IDomainEvent> DomainEvents { get; }
    }
}