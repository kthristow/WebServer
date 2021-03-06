using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.MvcFramework;

namespace BattleCards.Data
{
    public class User:IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Role = IdentityRole.User;
            this.Cards = new HashSet<UserCard>();
        }
        public virtual ICollection<UserCard> Cards { get; set; }
    }
}
