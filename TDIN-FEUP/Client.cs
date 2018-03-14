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
            Console.WriteLine("Ready to register. Press enter...");
            Console.ReadLine();

            User u1 = new User("Diogo","DD","quefixe");
            Coordinator coordinator = new Coordinator();
            if (coordinator.Register(u1))
                Console.WriteLine("User " + u1.ToString() + "successfully registered");
            else
                Console.WriteLine("Could not register user");
            Console.ReadLine();
        }
    }
}
