using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Database
{
    public class DiginoteDB
    {
        public static string dbFilename = "Diginotes.sqlite";
        SQLiteConnection db;

        public SQLiteConnection Db
        {
            get => this.db;
        }

        public DiginoteDB() : this(false) { }

        public DiginoteDB(bool reset)
        {
            if(reset || !File.Exists(Directory.GetCurrentDirectory() + "/" + dbFilename))
            {
                SQLiteConnection.CreateFile(dbFilename);
                Console.WriteLine("Creating a new DB");

                //Open Database connection
                db = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
                db.Open();

                //Create Database tables
                SQLiteCommand createDatabase = new SQLiteCommand(
                "CREATE TABLE users(id INTEGER PRIMARY KEY," +
                "name VARCHAR(50) NOT NULL," +
                "nickname VARCHAR(30) NOT NULL," +
                "password VARCHAR(64) NOT NULL);" +

                "CREATE TABLE diginotes(" +
                "serialNumber INTEGER PRIMARY KEY," +
                "facialValue INTEGER," +
                "idUser INTEGER REFERENCES users(id) NOT NULL); " +

                "CREATE TABLE orders(" +
                "owner VARCHAR(30) NOT NULL,"+
                "type VARCHAR(15) NOT NULL);",
                db
                );
                createDatabase.ExecuteNonQuery();
            }
            else
            {
                //Open Database connection
                db = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
                db.Open();
            }
        }

        public void insertUser(User user)
        {
            SQLiteCommand register = new SQLiteCommand(
                "insert into users(name, nickname, password) values(\""
                + user.Name + "\",\"" + user.Nickname + "\",\"" + user.Password + "\");",
                db);
            register.ExecuteNonQuery();

            register.Dispose();
        }

        public void insertDiginote(long serialNumber, string ownerNickname)
        {
            //Get owner ID in the database
            int ownerId = getUserId(ownerNickname);

            //Insert new diginote
            SQLiteCommand registerNote = new SQLiteCommand(
                "insert into diginotes(serialNumber, facialValue, idUser) values("+
                serialNumber.ToString() + ",1," + ownerId.ToString() + ");",
                db);
            registerNote.ExecuteNonQuery();

            registerNote.Dispose();

        }

        public void insertDiginote(Diginote note)
        {
            insertDiginote(note.SerialNumber, note.OwnerNickname);
        }

        public void transferDiginote(long serialNumber, string newOwnerNickname)
        {
            int newOwnerId = getUserId(newOwnerNickname);

            if(updateDiginote(serialNumber, newOwnerId) < 1)
            {
                throw new ArgumentException("Diginote serial number " + serialNumber.ToString() + " does not exist");
            }
        }

        public List<User> getAllUsers()
        {
            List<User> list = new List<User>();

            SQLiteCommand getUsers = new SQLiteCommand(
                "select * from users;", db);
            SQLiteDataReader reader = getUsers.ExecuteReader();

            while(reader.Read())
            {
                User user = new User(reader.GetString(1), reader.GetString(2), reader.GetString(3));
                list.Add(user);
            }

            return list;
        }

        public Queue<Order> getAllSellingOrders()
        {
            Queue<Order> list = new Queue<Order>();

            SQLiteCommand GetSellingOrders = new SQLiteCommand(
                "select owner from orders WHERE type='SELLING';", db);
            SQLiteDataReader reader = GetSellingOrders.ExecuteReader();

            while (reader.Read())
            {
                Order order = new Order(reader.GetString(0), Order.OrderType.SELLING);
                list.Enqueue(order);
            }

            return list;
        }

        public Queue<Order> GetBuyingOrders()
        {
            Queue<Order> list = new Queue<Order>();

            SQLiteCommand getBuyingOrders = new SQLiteCommand(
                "select owner from orders WHERE type='BUYING';", db);
            SQLiteDataReader reader = getBuyingOrders.ExecuteReader();

            while (reader.Read())
            {
                Order order = new Order(reader.GetString(0), Order.OrderType.BUYING);
                list.Enqueue(order);
            }

            return list;
        }

        public List<Diginote> getAllDiginotes()
        {
            List<Diginote> list = new List<Diginote>();

            SQLiteCommand getNotes = new SQLiteCommand(
                "select serialNumber, nickname from diginotes, users where diginotes.iduser = users.id;", db);
            SQLiteDataReader reader = getNotes.ExecuteReader();

            while(reader.Read())
            {
                Diginote note = new Diginote(reader.GetInt64(0), reader.GetString(1));
                list.Add(note);
            }

            return list;
        }

        private int getUserId(string nickname)
        {
            SQLiteCommand getOwnerId = new SQLiteCommand(
                "select id from users where nickname = \"" + nickname + "\"",
                db);
            SQLiteDataReader reader = getOwnerId.ExecuteReader();
            int ownerId;
            if (reader.Read())
            {
                ownerId = reader.GetInt32(0);

                getOwnerId.Dispose();
                reader.Dispose();
            }
            else
            {
                getOwnerId.Dispose();
                reader.Dispose();
                throw new Exception("Could not get ownerID from database");
            }

            return ownerId;
        }

        private int updateDiginote(long serialNumber, int idUser, int facialValue = 1)
        {
            SQLiteCommand update = new SQLiteCommand(
                "update diginotes set facialValue = " + facialValue.ToString() +
                ", idUser = " + idUser.ToString() + " where serialNumber = " + serialNumber.ToString() + ";"
                , db);

            return update.ExecuteNonQuery();
        }

        public void AddOrder(Order order)
        {
            SQLiteCommand registerOrder = new SQLiteCommand(
                "insert into orders(owner, type) values('" +
                order.owner + "','" + order.type.ToString() + "');",
                db);
            registerOrder.ExecuteNonQuery();

            registerOrder.Dispose();
        }

        public void RemoveOrder(Order order)
        {
            SQLiteCommand removeOrder = new SQLiteCommand(
                "DELETE FROM orders WHERE owner='" + order.owner +
                "' AND type='" + order.type.ToString() + "';",
                db);
            removeOrder.ExecuteNonQuery();

            removeOrder.Dispose();
        }
    }
}
