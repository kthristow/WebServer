using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.ViewModels.Cards
{
    public class DoAddViewModel
    {
        public int Attack { get; set; }

        public int Health { get; set; }

        public int Damage => this.Attack * 10 + Health;
    }
}
