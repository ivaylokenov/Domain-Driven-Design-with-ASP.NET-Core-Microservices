namespace CarRentalSystem.Domain.Specifications.CarAds
{
    using System;
    using System.Linq.Expressions;
    using Models.CarAds;

    public class CadAdOnlyAvailableSpecification : Specification<CarAd>
    {
        private readonly bool onlyAvailable;

        public CadAdOnlyAvailableSpecification(bool onlyAvailable) 
            => this.onlyAvailable = onlyAvailable;

        public override Expression<Func<CarAd, bool>> ToExpression()
        {
            if (this.onlyAvailable)
            {
                return carAd => carAd.IsAvailable;
            }

            return carAd => true;
        }
    }
}
