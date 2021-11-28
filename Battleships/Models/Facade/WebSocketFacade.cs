using System;
using WebSocketSharp;

namespace Battleships.Forms
{
    public interface IWebSocketFacade
    {
        WebSocket Connect(EventHandler<MessageEventArgs> OnMessage);
        WebSocket Connect(EventHandler<MessageEventArgs> OnMessage, string toSend);
        WebSocket GetWebSocket();
        void PrintArgs();
    }

    class WebSocketFacadeProxy : IWebSocketFacade
    {
        private string ip_address = null;
        private string endpoint = null;
        private WebSocketFacade webSocketFacade = null;

        public WebSocketFacadeProxy(string ip_address, string endpoint)
        {
            this.ip_address = ip_address;
            this.endpoint = endpoint;
        }

        private void InitializeWebSocketFacade()
        {
            this.webSocketFacade = new WebSocketFacade(this.ip_address, this.endpoint);
        }

        public WebSocket Connect(EventHandler<MessageEventArgs> OnMessage)
        {
            if (this.webSocketFacade == null)
            {
                InitializeWebSocketFacade();
            }
            return this.webSocketFacade.Connect(OnMessage);
        }

        public WebSocket Connect(EventHandler<MessageEventArgs> OnMessage, string toSend)
        {
            if (this.webSocketFacade == null)
            {
                InitializeWebSocketFacade();
            }
            return this.webSocketFacade.Connect(OnMessage, toSend);
        }

        public WebSocket GetWebSocket()
        {
            if (this.webSocketFacade == null)
            {
                InitializeWebSocketFacade();
            }
            return this.webSocketFacade.GetWebSocket();
        }

        public void PrintArgs()
        {
            Console.WriteLine(this.ip_address);
            Console.WriteLine(this.endpoint);
        }
    }

    class WebSocketFacade : IWebSocketFacade
    {
        private WebSocket webSocket;
        private string ip_address;
        private string endpoint;

        public WebSocketFacade(string ip_address, string endpoint)
        {
            this.ip_address = ip_address;
            this.endpoint = endpoint;
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

        public WebSocket GetWebSocket()
        {
            return this.webSocket;
        }

        public void PrintArgs()
        {
            Console.WriteLine(this.ip_address);
            Console.WriteLine(this.endpoint);
        }
    }
}
