using BattleCards.Services;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService userService;

        public UsersController(IUsersService userService)
        {
            this.userService = userService;
        }
        // GET /users/login
        public HttpResponse Login()
        {
            if (this.isUserSignedIn())
            {
                return this.Redirect("/");
            }
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            var username = this.Request.FormData["username"];
            var password=this.Request.FormData["password"];
            var userId = this.userService.GetUserId(username, password);
            if(userId==null)
            {
                return this.Error("Invalid username or password");
            }
            this.SignIn(userId);
            return this.Redirect("/Cards/All");
        }

        // GET /users/register
        public HttpResponse Register()
        {
            return this.View();
        }
        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister(string username, string email, string password, string confirmPassword)
        {
            

            if (username == null || username.Length < 5 || username.Length > 20)
            {
                return this.Error("Invalid username.The username should be between 5 and 20");
            }
            if (!Regex.IsMatch(username,@"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username.Only alphanumeric characters are valid!");
            }
            if(string.IsNullOrWhiteSpace(email)||!new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email!");
            }
            if (password == null || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password!Must be between 6 and 20 characters!");
            }
            if (password != confirmPassword)
            {
                return this.Error("ConfirmPasswords should be the same");
            }
            if (!this.userService.isUsernameAvailable(username))
            {
                return this.Error("Username already taken");
            }
            if (!this.userService.isEmailAvailable(email))
            {
                return this.Error("Email already taken");
            }
           this.userService.CreateUsers(username,email, password); 

            return this.Redirect("/Users/Login");
        }

      

        public HttpResponse Logout()
        {
            if (this.isUserSignedIn())
            {
                this.SignOut();
                return this.Redirect("/");
            }
            else
            {
                return this.Error("Only logged-in users can logged-out!");
            }
            
            
        }
    }
}
