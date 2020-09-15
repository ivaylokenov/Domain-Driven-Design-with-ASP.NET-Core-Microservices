namespace CarRentalSystem.Domain.Common.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Entity<TId> : IEntity
        where TId : struct
    {
        private readonly ICollection<IDomainEvent> events;

        protected Entity() => this.events = new List<IDomainEvent>();

        public TId Id { get; private set; } = default;

        public IReadOnlyCollection<IDomainEvent> Events 
            => this.events.ToList().AsReadOnly();

        public void ClearEvents() => this.events.Clear();

        protected void AddEvent(IDomainEvent domainEvent)
            => this.events.Add(domainEvent);

        public override bool Equals(object? obj)
        {
            if (!(obj is Entity<TId> other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.GetType() != other.GetType())
            {
                return false;
            }

            if (this.Id.Equals(default) || other.Id.Equals(default))
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TId>? first, Entity<TId>? second)
        {
            if (first is null && second is null)
            {
                return true;
            }

            if (first is null || second is null)
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Entity<TId>? first, Entity<TId>? second) => !(first == second);

        public override int GetHashCode() => (this.GetType().ToString() + this.Id).GetHashCode();
    }
}
