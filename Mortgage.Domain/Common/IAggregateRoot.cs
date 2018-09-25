namespace Mortgage.Domain.Common
{
    using System.Collections.Generic;

    public interface IAggregateRoot : IAggregateRoot<int>, IEntity
    {
    }

    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>, IGeneratesDomainEvents
    {
    }

    public interface IGeneratesDomainEvents
    {
        ICollection<IDomainEvent> DomainEvents { get; }
    }
}