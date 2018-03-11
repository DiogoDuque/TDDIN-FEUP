using Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests
{
    [TestClass()]
    public class CoordinatorTests
    {
        [TestMethod()]
        public void registerTest()
        {
            Coordinator c = new Coordinator();
            User u1 = new User("Jose C", "jc", "1234");
            User u2 = new User("Jos", "jc", "1244");
            User u3 = new User("Jose C", "joca", "1234");
            Console.WriteLine(c.UsersList.Count);
            c.register(u1);
            Console.WriteLine(c.UsersList.Count);
            c.register(u2);
            Console.WriteLine(c.UsersList.Count);
            Assert.IsTrue(c.UsersList.Count == 1);
            Console.WriteLine("Test passed");
            c.register(u3);
            Console.WriteLine(c.UsersList.Count);
            Assert.IsTrue(c.UsersList.Count == 2);
        }
    }
}