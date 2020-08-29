namespace CarRentalSystem.Application.Features.Identity.Commands.LoginUser
{
    public class LoginSuccessModel
    {
        public LoginSuccessModel(string userId, string token)
        {
            this.UserId = userId;
            this.Token = token;
        }

        public string UserId { get; }

        public string Token { get; }
    }
}
