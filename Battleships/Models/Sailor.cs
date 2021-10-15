using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Sailor
    {
        public string UID { get; set; }
        public Sailor(string uid)
        {
            UID = uid;
        }
    }
}
