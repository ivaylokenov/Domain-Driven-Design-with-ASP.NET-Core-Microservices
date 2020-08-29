namespace Blog.Domain.Common
{
    using System.Collections.Generic;
    using Events;

    public interface IEntity
    {
        IReadOnlyCollection<IDomainEvent> Events { get; }

        void ClearEvents();
    }
}
