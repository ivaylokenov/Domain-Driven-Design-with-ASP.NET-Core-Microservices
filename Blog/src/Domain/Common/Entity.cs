namespace Blog.Domain.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Events;

    public abstract class Entity<TKey> : IEntity
    {
        private readonly ICollection<IDomainEvent> events;

        protected Entity()
        {
            this.events = new List<IDomainEvent>();
        }

        public virtual TKey Id { get; set; }

        // Add GetHashCode(), Equals(), etc.

        public IReadOnlyCollection<IDomainEvent> Events => this.events.ToList();

        public void ClearEvents() => this.events.Clear();

        protected void AddEvent(IDomainEvent domainEvent)
            => this.events.Add(domainEvent);
    }
}
