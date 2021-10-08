namespace CarRentalSystem.Domain.Specifications.Dealers
{
    using System;
    using System.Linq.Expressions;
    using Models.Dealers;

    public class DealerByIdSpecification : Specification<Dealer>
    {
        private readonly int? id;

        public DealerByIdSpecification(int? id)
            => this.id = id;

        protected override bool Include => this.id != null;

        public override Expression<Func<Dealer, bool>> ToExpression()
            => dealer => dealer.Id == this.id;
    }
}
