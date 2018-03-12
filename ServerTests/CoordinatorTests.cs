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
            c.register(u1);
            c.register(u2);
            Assert.IsTrue(c.UsersList.Count == 1);
            c.register(u3);
            Assert.IsTrue(c.UsersList.Count == 2);
        }

        [TestMethod()]
        public void logInTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            User u2 = new User("Jos", "jc", "1244");
            Dictionary<string, User> usersList = new Dictionary<string, User>();
            usersList.Add(u1.Nickname, u1);
            Coordinator c = new Coordinator(usersList);

            c.logIn(u1);
            Assert.IsTrue(u1.IsLoggedIn);
            c.logIn(u2);
            Assert.IsFalse(u2.IsLoggedIn);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Should throw an exception because user is not registered")]
        public void logInExceptionTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            Coordinator c = new Coordinator();

            c.logIn(u1);
        }
    }
}