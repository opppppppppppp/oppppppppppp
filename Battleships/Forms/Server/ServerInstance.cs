using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;
using System.Diagnostics;

namespace Battleships.Forms
{
    public sealed class ServerInstance
    {
        private static ServerInstance serverInstance = null;

        private WebSocketServer webSocketServer = null;
        private ServerInstance()
        {
            webSocketServer = new WebSocketServer($"ws://{Constants.ip_address}");
            Debug.WriteLine("Singleton initialized");
        }

        public static ServerInstance Instance
        {
            get
            {
                if(serverInstance == null)
                {
                    serverInstance = new ServerInstance();
                }
                return serverInstance;
            }
        }

        public WebSocketServer GetWebSocketServer()
        {
            return webSocketServer;
        }
    }
}
