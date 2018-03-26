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

        public void registerUser(User user)
        {
            SQLiteCommand register = new SQLiteCommand(
                "insert into users(name, nickname, password) values(\""
                + user.Name + "\",\"" + user.Nickname + "\",\"" + user.Password + "\");",
                db);
            register.ExecuteNonQuery();

            register.Dispose();
        }

        public void registerDiginote(long serialNumber, string ownerNickname)
        {
            //Get owner ID in the database
            SQLiteCommand getOwnerId = new SQLiteCommand(
                "select id from users where nickname = \"" + ownerNickname + "\"",
                db);
            SQLiteDataReader reader = getOwnerId.ExecuteReader();
            int ownerId;
            if (reader.Read())
                ownerId = reader.GetInt32(0); //TODO Nao consigo ainda obter o valor, da erro
            else
                throw new Exception("Could not get ownerID from database");

            //Insert new diginote
            SQLiteCommand registerNote = new SQLiteCommand(
                "insert into diginotes(serialNumber, facialValue, idUser) values("+
                serialNumber.ToString() + ",1," + ownerId.ToString() + ");",
                db);
            registerNote.ExecuteNonQuery();

            getOwnerId.Dispose();
            reader.Dispose();
            registerNote.Dispose();

        }

    }
}
