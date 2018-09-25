namespace Mortgage.Domain.Common
{
    using System;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

    public interface IEventAggregator : IDisposable
    {
        void Publish<T>(T @event) where T : IDomainEvent;
        IDisposable Subscribe<T>(Action<T> action) where T : IDomainEvent;
    }

    public class EventAggregator : IEventAggregator
    {
        private readonly Subject<object> _subject = new Subject<object>();

        public IDisposable Subscribe<T>(Action<T> action) where T : IDomainEvent
        {
            return _subject.OfType<T>()
                .AsObservable()
                .Subscribe(action);
        }

        public void Publish<T>(T @event) where T : IDomainEvent
        {
            _subject.OnNext(@event);
        }

        public void Dispose()
        {
            _subject.Dispose();
        }
    }
}