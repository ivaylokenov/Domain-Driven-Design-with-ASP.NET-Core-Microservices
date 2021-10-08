namespace CarRentalSystem.Application.Features.Dealers.Queries.Common
{
    using AutoMapper;
    using Domain.Models.Dealers;
    using Mapping;

    public class DealerOutputModel : IMapFrom<Dealer>
    {
        public int Id { get; private set; }

        public string Name { get; private set; } = default!;

        public string PhoneNumber { get; private set; } = default!;

        public virtual void Mapping(Profile mapper)
            => mapper
                .CreateMap<Dealer, DealerOutputModel>()
                .ForMember(d => d.PhoneNumber, cfg => cfg
                    .MapFrom(d => d.PhoneNumber.Number));
    }
}
