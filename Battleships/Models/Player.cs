using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Player
    {
        private string UID { get; set; }
        public Player()
        {
            UID = Guid.NewGuid().ToString();
        }

        public string getUID()
        {
            return UID;
        }
    }
}
