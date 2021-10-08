namespace CarRentalSystem.Application.Dealerships.CarAds.Queries.Categories
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;

    public class GetCarAdCategoriesQuery : IRequest<IEnumerable<GetCarAdCategoryOutputModel>>
    {
        public class GetCarAdCategoriesQueryHandler : IRequestHandler<
            GetCarAdCategoriesQuery, 
            IEnumerable<GetCarAdCategoryOutputModel>>
        {
            private readonly ICarAdQueryRepository carAdRepository;

            public GetCarAdCategoriesQueryHandler(ICarAdQueryRepository carAdRepository) 
                => this.carAdRepository = carAdRepository;

            public async Task<IEnumerable<GetCarAdCategoryOutputModel>> Handle(
                GetCarAdCategoriesQuery request,
                CancellationToken cancellationToken)
                => await this.carAdRepository.GetCarAdCategories(cancellationToken);
        }
    }
}
