using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace Battleships.Forms
{
    class WebSocketFacade
    {
        public WebSocket webSocket { get; private set; }

        public WebSocketFacade(string ip_address, string endpoint)
        {
            webSocket = new WebSocket($"ws://{ip_address}/{endpoint}");
        }

        public WebSocket Connect(EventHandler<MessageEventArgs> OnMessage)
        {
            webSocket.OnMessage += OnMessage;
            webSocket.Connect();
            return webSocket;
        }

        public WebSocket Connect(EventHandler<MessageEventArgs> OnMessage, string toSend)
        {
            Connect(OnMessage);
            webSocket.Send(toSend);
            return webSocket;
        }
    }
}
