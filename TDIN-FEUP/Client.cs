using Common;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_FEUP
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Client.exe.config",false);
            Console.WriteLine("Ready to register");
            User u1 = new User("Diogo","DD","quefixe");
            Coordinator coordinator = new Coordinator();
            coordinator.Register(u1);
            Console.WriteLine("Registered");
            Console.ReadLine();
        }
    }
}
