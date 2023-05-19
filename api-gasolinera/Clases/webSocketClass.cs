using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace api_gasolinera.Clases
{
    public class webSocketClass
    {
        public class Echo : WebSocketBehavior
        {
            protected override void OnMessage(MessageEventArgs e)
            {
                Console.WriteLine("Si funciona");
            }
        }
        public static void runServer()
        {
            WebSocketServer wssv = new WebSocketServer("ws://127.0.0.1:30000");

            wssv.AddWebSocketService<Echo>("/Echo");

            wssv.Start();

        }
    }
}