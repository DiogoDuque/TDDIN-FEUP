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

        public DiginoteDB()
        {
            //Create Database file if doesnt exist yet
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + dbFilename))
                SQLiteConnection.CreateFile(dbFilename);

            //Open Database connection
            db = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
            db.Open();

            //Create Database tables
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + dbFilename))
            {
                SQLiteCommand createDatabase = new SQLiteCommand(
                "CREATE TABLE users (id INTEGER PRIMARY KEY," +
                "name VARCHAR(50) NOT NULL," +
                "nickname VARCHAR(30) NOT NULL," +
                "password VARCHAR(64) NOT NULL);" +
                "CREATE TABLE digicoins(" +
                "serialNumber INTEGER PRIMARY KEY," +
                "facialValue INTEGER," +
                "idUser INTEGER REFERENCES users(id) NOT NULL); ",
                db
                );
                createDatabase.ExecuteNonQuery();
            }
        }

        public void registerUser(User user)
        {
            SQLiteCommand register = new SQLiteCommand(
                "insert into users(name, nickname, password) values(\""
                + user.Name + "\",\"" + user.Nickname + "\",\"" + user.Password + "\");",
                db);
            register.ExecuteNonQuery();
        }

    }
}
