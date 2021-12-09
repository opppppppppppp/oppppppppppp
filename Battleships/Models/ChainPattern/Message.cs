using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ChainPattern
{
    class Message
    {
        public static int LongMessageLimit = 50;
        private const string CensoredWord = "keiksmazodis";
        public MessageType MsgType { get; }
        public string Text { get; set; }

        public Message(string text)
        {
            Text = text;
            if (text.Contains(CensoredWord))
            {
                MsgType = MessageType.Censored;
                return;
            }
            else if (text.Length > LongMessageLimit)
            {
                MsgType = MessageType.Long;
                return;
            }
            else
            {
                MsgType = MessageType.Short;
            }
        }
    }
}
