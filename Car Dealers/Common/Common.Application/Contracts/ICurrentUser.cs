namespace CarRentalSystem.Application.Common.Contracts
{
    using System.Collections.Generic;

    public interface ICurrentUser
    {
        string UserId { get; }

        IEnumerable<string> Roles { get; }
    }
}
