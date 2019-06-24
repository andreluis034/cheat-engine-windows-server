using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CEServerWindows;

namespace CEServerApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CEServerWindows.CheatEngineServer server = new CEServerWindows.CheatEngineServer();

            server.StartAsync().Wait();
        }
    }
}
