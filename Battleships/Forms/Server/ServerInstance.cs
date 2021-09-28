using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp.Server;

namespace Battleships.Forms
{
    class ServerInstance
    {

        private static WebSocketServer wsServer;

        public static WebSocketServer GetInstance(string ip_address)
        {
            if (wsServer == null)
            {
                    wsServer = new WebSocketServer($"ws://{ip_address}");
            }
            return wsServer;
        }



    }
}
