using Devkoes.Restup.WebServer.File;
using Devkoes.Restup.WebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            // Dont release deferral, otherwise app will stop
            return true;
        }
    }
}
