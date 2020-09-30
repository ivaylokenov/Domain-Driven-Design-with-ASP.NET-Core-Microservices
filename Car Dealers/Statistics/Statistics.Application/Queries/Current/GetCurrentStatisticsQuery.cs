namespace CarRentalSystem.Application.Statistics.Queries.Current
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetCurrentStatisticsQuery : IRequest<GetCurrentStatisticsOutputModel>
    {
        public class GetCurrentStatisticsQueryHandler : IRequestHandler<GetCurrentStatisticsQuery, GetCurrentStatisticsOutputModel>
        {
            private readonly IStatisticsQueryRepository statistics;

            public GetCurrentStatisticsQueryHandler(IStatisticsQueryRepository statistics) 
                => this.statistics = statistics;

            public Task<GetCurrentStatisticsOutputModel> Handle(
                GetCurrentStatisticsQuery request,
                CancellationToken cancellationToken)
                => this.statistics.GetCurrent(cancellationToken);
        }
    }
}
