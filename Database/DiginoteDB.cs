using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                "idUser INTEGER REFERENCES users(id) NOT NULL); ",
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


    }
}
