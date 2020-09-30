namespace CarRentalSystem.Application.Statistics.Queries.CarAdViews
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetCarAdViewsQuery : IRequest<int>
    {
        public int CarAdId { get; set; }

        public class GetCarAdViewsQueryHandler : IRequestHandler<GetCarAdViewsQuery, int>
        {
            private readonly IStatisticsQueryRepository statistics;

            public GetCarAdViewsQueryHandler(IStatisticsQueryRepository statistics) 
                => this.statistics = statistics;

            public Task<int> Handle(
                GetCarAdViewsQuery request, 
                CancellationToken cancellationToken)
                => this.statistics.GetCarAdViews(request.CarAdId, cancellationToken);
        }
    }
}
