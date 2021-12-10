using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Battleships.Models.Memento;

namespace Battleships
{
    class Constants
    {
        public const string ip_address = "127.0.0.1:7890";
        public static string IMG_DIR = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName+ "/Images/Settings/battleships.png";
        public static string CHAT_COLOR = "white";
        public static  Caretaker caretaker;
        public static bool inited = false;
    }
}
