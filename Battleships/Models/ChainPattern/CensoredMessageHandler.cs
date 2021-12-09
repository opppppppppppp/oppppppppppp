using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ChainPattern
{
    class CensoredMessageHandler : MessageHandler
    {
        public override string HandleMessage(Message message)
        {
            if (message.MsgType == MessageType.Censored)
            {
                return "****";
            }
            else
            {
                return NextHandler.HandleMessage(message);
            }
        }
    }
}
