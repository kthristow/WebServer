namespace BattleCards.Services
{
    public interface IUsersService
    {
        string CreateUsers(string username,string email, string password);

        string GetUserId(string username,string password);

        bool isUsernameAvailable(string username);

        bool isEmailAvailable(string email);
    }
}
