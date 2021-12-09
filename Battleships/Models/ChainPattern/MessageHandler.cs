using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Models.ChainPattern
{
    abstract class MessageHandler
    {
        public static MessageHandler DefaultMessageHandler()
        {
            MessageHandler censoredMessageHandler = new CensoredMessageHandler();
            MessageHandler longMessageHandler = new LongMessageHandler();
            MessageHandler shortMessageHandler = new ShortMessageHandler();

            censoredMessageHandler.SetNextHandler(longMessageHandler);
            longMessageHandler.SetNextHandler(shortMessageHandler);

            return censoredMessageHandler;
        }

        protected MessageHandler NextHandler;

        public void SetNextHandler(MessageHandler nextHandler)
        {
            NextHandler = nextHandler;
        }

        public abstract string HandleMessage(Message message);
    }
}
