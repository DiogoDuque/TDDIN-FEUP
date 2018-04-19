using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Tests
{
    [TestClass()]
    public class TransactionLoggerTests
    {
        [TestMethod()]
        public void RegisterLogTransactionTest()
        {
            TransactionLogger t = new TransactionLogger();

            string nickname1 = "Nickname1";
            string nickname2 = "Nickname2";
            int quantity1 = 3;
            int quantity2 = 1;

            System.IO.File.Create(t.logFilename).Close(); //clean the file
            t.RegisterLogTransaction(nickname1, nickname2, quantity1);
            t.RegisterLogTransaction(nickname2, nickname1, quantity2);
            string[] logText = System.IO.File.ReadAllLines(t.logFilename);
            Console.WriteLine("Start");
            foreach(string s in logText)
            {
                Console.WriteLine(s);
            }
            Assert.IsTrue(logText[0] == "Nickname1 sent 3 diginotes to Nickname2");
            Assert.IsTrue(logText[1] == "Nickname2 sent 1 diginote to Nickname1");


        }
    }
}