using Common;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static string dbFilename = "Diginotes.sqlite";
        static void Main(string[] args)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + dbFilename))
                initializeDb();
            RemotingConfiguration.Configure("Server.exe.config", false);
            Console.WriteLine("Server initialized. Press enter to exit");
            Console.ReadLine();
        }

        static void initializeDb()
        {
            SQLiteConnection.CreateFile(dbFilename);
            SQLiteConnection db = new SQLiteConnection("Data Source=" + Server.dbFilename+";Version=3;");
            db.Open();
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

    public class Coordinator : MarshalByRefObject
    {
        /**
         * double -> Diginote.serialNumber
         * string -> User.nickname
         **/
        Dictionary<double, string> ownershipTable;
        Dictionary<string, User> usersList;
        float diginoteQuote;
        SQLiteConnection db;

        public Coordinator()
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<double, string>();
            this.usersList = new Dictionary<string, User>();
            this.diginoteQuote = 1;
            this.db = new SQLiteConnection("Data Source=" + Server.dbFilename + ";Version=3;");
            this.db.Open();
        }

        public Coordinator(Dictionary<string, User> usersList)
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<double, string>();
            this.usersList = usersList;
            this.diginoteQuote = 1;
            this.db = new SQLiteConnection("Data Source=" + Server.dbFilename + ";Version=3;");
            this.db.Open();
        }

        public Dictionary<double, string> OwnershipTable
        {
            get => ownershipTable;
        }
        public Dictionary<string, User> UsersList
        {
            get => usersList;
        }

        public float DiginoteQuote
        {
            get => diginoteQuote;
            set
            {
                if(value > 0)
                {
                    diginoteQuote = value;
                }
                else
                {
                    throw new ArgumentException("Quote cannot be null or negative");
                }
            }
        }

        public SQLiteConnection Db
        {
            get => db;
        }

        /// <summary>
        /// Registers a user in the server database.
        /// PASSWORD MUST BE HASHED
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Register(User user)
        {
            if (!usersList.ContainsKey(user.Nickname))
            {
                usersList.Add(user.Nickname, user);
                registerUserDB(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Logs a user in.
        /// PASSWORD MUST BE HASHED BEFORE
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LogIn(string nickname, string password)
        {
            if (usersList.ContainsKey(nickname))
            {
                if (usersList[nickname].Password == password)
                {
                    if (usersList[nickname].IsLoggedIn)
                        return false;
                    else
                    {
                        usersList[nickname].IsLoggedIn = true;
                        return true;
                    }
                }
                else
                {
                    //TODO Sera que devia lançar uma excepção aqui? Ou acima, no Loggedin?
                    return false;
                }
            }
            else
                throw new System.ArgumentException("User is not registered!");
        }

        public bool LogOut(string nickname)
        {
            if (usersList.ContainsKey(nickname))
            {
                if (!usersList[nickname].IsLoggedIn)
                    return false;
                else
                {
                    usersList[nickname].IsLoggedIn = false;
                    return true;
                }
            }
            else
                throw new System.ArgumentException("User is not registered");
        }

        void registerUserDB(User user)
        {
            SQLiteCommand register = new SQLiteCommand(
                "insert into users(name, nickname, password) values(\""
                + user.Name + "\",\"" + user.Nickname + "\",\"" + user.Password + "\");",
                db);
            register.ExecuteNonQuery();
        }
    }
}
