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
            c.Register(u1);
            c.Register(u2);
            Assert.IsTrue(c.UsersList.Count == 1);
            c.Register(u3);
            Assert.IsTrue(c.UsersList.Count == 2);
        }

        [TestMethod()]
        public void logInTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            User u2 = new User("Jos", "jcz", "1244");
            Dictionary<string, User> usersList = new Dictionary<string, User>();
            u2.IsLoggedIn = true;
            usersList.Add(u1.Nickname, u1);
            usersList.Add(u2.Nickname, u2);
            Coordinator c = new Coordinator(usersList);

            Assert.IsTrue(c.LogIn(u1));
            Assert.IsTrue(u1.IsLoggedIn);
            Assert.IsFalse(c.LogIn(u2));
            Assert.IsTrue(u2.IsLoggedIn);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Should throw an exception because user is not registered")]
        public void logInExceptionTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            Coordinator c = new Coordinator();

            c.LogIn(u1);
        }

        [TestMethod()]
        public void logOutTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            User u2 = new User("Jos", "jck", "1244");
            u1.IsLoggedIn = true;
            u2.IsLoggedIn = false;
            Dictionary<string, User> usersList = new Dictionary<string, User>();
            usersList.Add(u1.Nickname, u1);
            usersList.Add(u2.Nickname, u2);
            Coordinator c = new Coordinator(usersList);

            Assert.IsTrue(c.logOut(u1));
            Assert.IsFalse(u1.IsLoggedIn);
            Assert.IsFalse(c.logOut(u2));
            Assert.IsFalse(u2.IsLoggedIn);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException), "Should throw an exception because user is not registered")]
        public void logOutExceptionTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            Coordinator c = new Coordinator();

            c.logOut(u1);
        }
    }
}