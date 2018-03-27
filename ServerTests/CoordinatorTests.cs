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
            Coordinator c = new Coordinator(true);
            User u1 = new User("Jose C", "jc", "1234");
            User u2 = new User("Jos", "jc", "1244");
            User u3 = new User("Jose C", "joca", "1234");
            c.Register(u1);
            c.Register(u2);
            Assert.IsTrue(c.UsersList.Count == 1);
            c.Register(u3);
            Assert.IsTrue(c.UsersList.Count == 2);
            closeDB(c);
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
            Coordinator c = new Coordinator(usersList, true);

            Assert.IsTrue(c.LogIn(u1.Nickname, u1.Password));
            Assert.IsTrue(u1.IsLoggedIn);
            Assert.IsFalse(c.LogIn(u2.Nickname, u2.Password));
            Assert.IsTrue(u2.IsLoggedIn);
            closeDB(c);
        }

        [TestMethod()]
        public void logInExceptionTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            Coordinator c = new Coordinator(true);

            try
            {
                c.LogIn(u1.Nickname, u1.Password); //This should throw the exception
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                closeDB(c);
            }
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
            Coordinator c = new Coordinator(usersList, true);

            Assert.IsTrue(c.LogOut(u1.Nickname));
            Assert.IsFalse(u1.IsLoggedIn);
            Assert.IsFalse(c.LogOut(u2.Nickname));
            Assert.IsFalse(u2.IsLoggedIn);
            closeDB(c);
        }

        [TestMethod()]
        public void logOutExceptionTest()
        {
            User u1 = new User("Jose C", "jc", "1234");
            Coordinator c = new Coordinator(true);

            try
            {
                c.LogOut(u1.Nickname); //This should throw an exception
                Assert.Fail();
            }
            catch(ArgumentException)
            {
                closeDB(c);
            }
        }

        [TestMethod()]
        public void createDiginoteTest()
        {
            string userNickname = "jc";
            User u1 = new User("Jose C", userNickname, "1234");
            Dictionary<string, User> usersList = new Dictionary<string, User>();
            usersList.Add(u1.Nickname, u1);
            Coordinator c = new Coordinator(usersList, true);
            c.Db.registerUser(u1); //TODO THIS DEPENDS ON registerUser function. Should not depend, and be more "hardcoded"

            Assert.IsTrue(c.NotesList.Count == 0);
            Assert.IsTrue(c.OwnershipTable.Count == 0);

            //Serial number of diginote created should be 1
            Assert.IsTrue(c.CreateDiginote(userNickname));

            Assert.IsTrue(c.NotesList.Count == 1);
            Assert.IsTrue(c.OwnershipTable.Count == 1);
            Assert.IsTrue(c.NotesList[1].OwnerNickname == userNickname);
            Assert.IsTrue(c.OwnershipTable[1] == userNickname);

            closeDB(c);
        }

        [TestMethod()]
        public void transferDiginotesTest()
        {
            //ARRANGE
            string userNickname1 = "jc";
            string userNickname2 = "mn";
            User u1 = new User("Jose C", userNickname1, "1234");
            User u2 = new User("Manuel C", userNickname2, "1234");
            Dictionary<string, User> usersList = new Dictionary<string, User>();
            usersList.Add(u1.Nickname, u1);
            usersList.Add(u2.Nickname, u2);

            Diginote d1 = new Diginote(1, u1.Nickname);
            Diginote d2 = new Diginote(2, u2.Nickname);
            Dictionary<long, Diginote> notesList = new Dictionary<long, Diginote>();
            Dictionary<long, string> ownershipTable = new Dictionary<long, string>();
            ownershipTable.Add(d1.SerialNumber, u1.Nickname);
            ownershipTable.Add(d2.SerialNumber, u2.Nickname);
            notesList.Add(d1.SerialNumber, d1);
            notesList.Add(d2.SerialNumber, d2);

            Coordinator c = new Coordinator(usersList, notesList, ownershipTable, true);
            c.Db.registerUser(u1); //TODO THIS DEPENDS ON registerUser function. Should not depend, and be more "hardcoded"
            c.Db.registerUser(u2);
            c.Db.registerDiginote(d1.SerialNumber, d1.OwnerNickname);
            c.Db.registerDiginote(d2.SerialNumber, d2.OwnerNickname);


            //ACT AND ASSERT
            Assert.IsTrue(c.TransferDiginotes(u1.Nickname, u2.Nickname, 1));
            Assert.IsTrue(d1.OwnerNickname == u2.Nickname);
            Assert.IsTrue(d2.OwnerNickname == u2.Nickname);

            Assert.IsFalse(c.OwnershipTable.Values.Contains(u1.Nickname));
            Assert.IsTrue(c.OwnershipTable.Count == 2);

            Assert.IsFalse(c.TransferDiginotes(u1.Nickname, u2.Nickname, 1));
            closeDB(c);
        }


        /// <summary>
        /// The test suite must use this in order to avoid crashing
        /// </summary>
        /// <param name="c"></param>
        private void closeDB(Coordinator c)
        {
            c.Db.Db.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}