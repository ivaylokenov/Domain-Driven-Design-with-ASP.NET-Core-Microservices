namespace Common.Models
{
    using System.Collections.Generic;

    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}
