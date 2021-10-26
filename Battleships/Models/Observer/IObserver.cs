using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Observer
{
    interface IObserver
    {
        void PlayerTurn(string playUID);
    }
}
