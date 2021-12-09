using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ChainPattern
{
    class LongMessageHandler : MessageHandler
    {
        public override string HandleMessage(Message message)
        {
            if (message.MsgType == MessageType.Long)
            {
                return message.Text.Substring(0, Message.LongMessageLimit) + "...";
            }
            else
            {
                return NextHandler.HandleMessage(message);
            }
        }
    }
}
