namespace Mortgage.Domain.Common
{
    using System;

    public static class DomainEvents
    {
        private static readonly IEventAggregator EventAggregator = new EventAggregator();

        // tell C# compiler not to mark type as beforefieldinit
        static DomainEvents()
        {
        }

        public static void Publish<T>(T @event)
            where T : IDomainEvent
        {
            EventAggregator.Publish<T>(@event);
        }

        public static void Subscribe<T>(Action<T> action)
            where T : IDomainEvent
        {
            EventAggregator.Subscribe(action);
        }
    }
}