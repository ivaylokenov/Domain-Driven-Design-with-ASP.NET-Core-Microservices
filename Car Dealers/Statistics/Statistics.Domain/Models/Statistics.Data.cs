namespace CarRentalSystem.Domain.Statistics.Models
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class StatisticsData : IInitialData
    {
        public Type EntityType => typeof(Statistics);

        public IEnumerable<object> GetData()
            => new List<Statistics>
            {
                new Statistics()
            };
    }
}
