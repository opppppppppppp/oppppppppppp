using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ChainPattern
{
    class ShortMessageHandler : MessageHandler
    {
        public override string HandleMessage(Message message)
        {
            if (message.MsgType == MessageType.Short)
            {
                return message.Text;
            }
            else
            {
                return NextHandler.HandleMessage(message);
            }
        }
    }
}
