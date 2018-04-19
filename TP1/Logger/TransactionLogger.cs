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
            c.logger -= l.RegisterLogTransaction;
        }
    }
    
    public class TransactionLogger : MarshalByRefObject
    {
        public string logFilename;

        public TransactionLogger()
        {
            logFilename = "transactions.txt";
        }

        public void RegisterLogTransaction(string oldOwner, string newOwner, int quantity)
        {
            string message = oldOwner+ " sent " + quantity.ToString() + " ";
            if(quantity == 1)
            {
                message = message + "diginote to " + newOwner;
            }
            else
            {
                message = message + "diginotes to " + newOwner;
            }

            string[] argument = new string[] { message };
            System.IO.File.AppendAllLines(logFilename, argument);
            Console.WriteLine(message);
        }
    }
}
