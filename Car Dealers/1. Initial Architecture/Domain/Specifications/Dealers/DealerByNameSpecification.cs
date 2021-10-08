namespace CarRentalSystem.Domain.Specifications.Dealers
{
    using System;
    using System.Linq.Expressions;
    using Models.Dealers;

    public class DealerByNameSpecification : Specification<Dealer>
    {
        private readonly string? name;

        public DealerByNameSpecification(string? name) 
            => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Dealer, bool>> ToExpression()
            => dealer => dealer.Name.ToLower().Contains(this.name!.ToLower());
    }
}
