using Devkoes.Restup.WebServer.File;
using Devkoes.Restup.WebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace AmadeusW.KindleNav.Server
{
    public static class WebServer
    {
        static HttpServer _httpServer;

        public static async Task<bool> Start()
        {
            var httpServer = new HttpServer(1337);
            _httpServer = httpServer;
            
            httpServer.RegisterRoute(new StaticFileRouteHandler(@"Server\www"));
            await httpServer.StartServerAsync();
            GetAddress();
            // Dont release deferral, otherwise app will stop
            return true;
        }

        public static async Task Stop()
        {
            if (_httpServer == null)
            {
                return;
            }

            _httpServer.StopServer();
        }

        public static async void GetAddress()
        {
            var hostnames = NetworkInformation.GetHostNames();
            foreach (var name in hostnames)
            {
                if (name.IPInformation != null)
                {
                    await Logger.Log($"{name.DisplayName} at {name.IPInformation.NetworkAdapter}");
                }
                else
                {
                    await Logger.Log($"{name.DisplayName}");
                }
            }
        }
    }
}
