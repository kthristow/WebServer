using BattleCards.Data;
using System.Text;
using WebServer.MvcFramework;

namespace BattleCards.Services
{
    public class UserService : IUsersService
    {
        private readonly ApplicationDbContext db;
        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public string CreateUsers(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Role = IdentityRole.User,
                Password = SHA512(password)
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        public bool isEmailAvailable(string email)
        {
            return !this.db.Users.Any(x=>x.Email== email);
        }

        public bool isUsernameAvailable(string username)
        {
            return !this.db.Users.Any(x => x.Username == username);
        }

        public string GetUserId(string username, string password)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            if (user?.Password != SHA512(password))
            {
                return null;
            }
            return user.Id;
        }
        public static string SHA512(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);

                // Convert to text
                // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }
    }
}
