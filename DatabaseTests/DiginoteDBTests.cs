using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Data.SQLite;

namespace Database.Tests
{
    [TestClass()]
    public class DiginoteDBTests
    {
        [TestMethod()]
        public void RegisterUserTest()
        {
            DiginoteDB db = new DiginoteDB(true);
            User u1 = new User("Jose C", "jc", "1234");

            db.insertUser(u1);

            SQLiteCommand getUsers = new SQLiteCommand(
                "select * from users;", db.Db);
            SQLiteDataReader reader = getUsers.ExecuteReader();

            Assert.IsTrue(reader.Read());
            Assert.IsTrue(reader.GetString(1) == u1.Name);
            Assert.IsTrue(reader.GetString(2) == u1.Nickname);
            Assert.IsTrue(reader.GetString(3) == u1.Password);
            Assert.IsFalse(reader.Read());

            getUsers.Dispose();
            reader.Dispose();
            CloseDb(db);
        }

        [TestMethod()]
        public void GetAllUsersTest()
        {
            DiginoteDB db = new DiginoteDB(true);
            User u1 = new User("Jose C", "jc", "1234");
            User u2 = new User("Manuel C", "mn", "4321");

            SQLiteCommand insertUser1 = new SQLiteCommand(
                "insert into users(name, nickname, password) values(\""
                + u1.Name + "\",\"" + u1.Nickname + "\",\"" + u1.Password + "\");",
                db.Db);

            SQLiteCommand insertUser2 = new SQLiteCommand(
                "insert into users(name, nickname, password) values(\""
                + u2.Name + "\",\"" + u2.Nickname + "\",\"" + u2.Password + "\");",
                db.Db);

            insertUser1.ExecuteNonQuery();
            insertUser2.ExecuteNonQuery();

            List<User> users = db.getAllUsers();
            Assert.IsTrue(users.Count == 2);
            Assert.IsTrue(users[0].Equals(u1));
            Assert.IsTrue(users[1].Equals(u2));

            insertUser1.Dispose();
            insertUser2.Dispose();
            CloseDb(db);
        }

        [TestMethod()]
        public void GetAllDiginotesTest()
        {
            DiginoteDB db = new DiginoteDB(true);
            int userid = 1;
            User u1 = new User("Jose C", "jc", "1234");
            Diginote d1 = new Diginote(1, "jc");
            Diginote d2 = new Diginote(2, "jc");

            SQLiteCommand insertUser1 = new SQLiteCommand(
                "insert into users(id, name, nickname, password) values(" + userid.ToString() + ",\""
                + u1.Name + "\",\"" + u1.Nickname + "\",\"" + u1.Password + "\");",
                db.Db);

            SQLiteCommand insertNote1 = new SQLiteCommand(
                "insert into diginotes(serialNumber, facialValue, idUser) values(" +
                d1.SerialNumber.ToString() + ",1," + userid.ToString() + ");",
                db.Db);

            SQLiteCommand insertNote2 = new SQLiteCommand(
                "insert into diginotes(serialNumber, facialValue, idUser) values(" +
                d2.SerialNumber.ToString() + ",1," + userid.ToString() + ");",
                db.Db);

            insertUser1.ExecuteNonQuery();
            insertNote1.ExecuteNonQuery();
            insertNote2.ExecuteNonQuery();

            List<Diginote> list = db.getAllDiginotes();
            Assert.IsTrue(list.Count == 2);
            Assert.IsTrue(list[0].Equals(d1));
            Assert.IsTrue(list[1].Equals(d2));

            insertUser1.Dispose();
            insertNote1.Dispose();
            insertNote2.Dispose();
            CloseDb(db);

        }

        private void CloseDb(DiginoteDB db)
        {
            db.Db.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}