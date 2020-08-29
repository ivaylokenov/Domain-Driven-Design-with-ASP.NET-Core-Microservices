namespace CarRentalSystem.Application.Features.Identity.Commands.LoginUser
{
    public class LoginOutputModel
    {
        public LoginOutputModel(string token, int dealerId)
        {
            this.Token = token;
            this.DealerId = dealerId;
        }

        public int DealerId { get; }

        public string Token { get; }
    }
}
