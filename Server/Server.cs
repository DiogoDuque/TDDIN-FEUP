using Database;
using System;
using System.Runtime.Remoting;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Server.exe.config", false);
            Console.WriteLine("Server initialized. Instantiating Coordinator object.");
            Console.WriteLine("Press enter to exit");
            new DiginoteDB();
            Console.ReadLine();
        }
    }
}
