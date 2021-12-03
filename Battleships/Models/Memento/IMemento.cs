using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.Memento
{
    interface IMemento
    {
        string GetName();

        string GetBackgroundImage();
        string GetBackgroundImageName();
        string GetChatColor();

        string GetDate();
    }
}
