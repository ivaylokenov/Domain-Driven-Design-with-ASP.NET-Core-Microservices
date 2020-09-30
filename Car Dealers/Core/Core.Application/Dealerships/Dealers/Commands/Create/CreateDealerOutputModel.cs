namespace CarRentalSystem.Application.Dealerships.Dealers.Commands.Create
{
    public class CreateDealerOutputModel
    {
        public CreateDealerOutputModel(int dealerId)
            => this.DealerId = dealerId;

        public int DealerId { get; }
    }
}
