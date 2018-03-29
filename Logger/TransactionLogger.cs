using Common;
using Coord;
using System;
using System.Runtime.Remoting;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Logger.exe.config", false);
            Coordinator c = new Coordinator();
            TransactionLogger l = new TransactionLogger();
            System.Console.WriteLine("Started Logger");
            c.logger += l.RegisterLogTransaction;
            Console.ReadLine();
        }
    }
    
    public class TransactionLogger : MarshalByRefObject
    {
        string logFilename;

        public TransactionLogger()
        {
            logFilename = "transactions.txt";
        }

        public void RegisterLogTransaction(User oldOwner, User newOwner, int quantity)
        {
            string message = oldOwner.Nickname + " sent " + quantity.ToString() + " ";
            if(quantity == 1)
            {
                message = message + "diginote to " + newOwner.Nickname;
            }
            else
            {
                message = message + "diginotes to " + newOwner.Nickname;
            }

            System.IO.File.WriteAllText(logFilename, message);
            Console.WriteLine(message);
        }
    }
}
