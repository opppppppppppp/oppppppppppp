using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models
{
    public class Sailor
    {
        private  string UID { get; set; }
        public Sailor()
        {

        }

        public virtual void assignUID(string uid)
        {
            UID = uid;
        }

        public virtual string getUID()
        {
            return UID ?? "-1";
        }
    }
}
