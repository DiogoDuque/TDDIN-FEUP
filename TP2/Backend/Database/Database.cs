using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Common;

namespace Database
{
    class DB_Tables
    {
        public static string TICKET = "CREATE TABLE tickets(" + 
            "id INTEGER PRIMARY KEY, " +
            "author INTEGER REFERENCES users(id) NOT NULL, " +
            "title VARCHAR(80) UNIQUE NOT NULL, " +
            "description VARCHAR(1500) NOT NULL, " +
            "creationDate VARCHAR(30) NOT NULL, " +
            "status VARCHAR(15) NOT NULL, " +
            "solver INTEGER REFERENCES users(id), " +
            "answer VARCHAR(1500)" +
            ");";

        public static string USERS = "CREATE TABLE users(" +
            "id INTEGER PRIMARY KEY, " +
            "name VARCHAR(40) NOT NULL, " +
            "email VARCHAR(50) UNIQUE NOT NULL, " +
            "type VARCHAR(10) NOT NULL" +
            ");";
    }
    public class Db
    {
        public static string dbFilename = "Tickets.sqlite";
        SQLiteConnection db;
        private static Db instance;

        public static Db GetInstance()
        {
            if (instance == null)
                instance = new Db();
            return instance;
        }

        private Db()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + dbFilename))
            {
                Console.WriteLine(Directory.GetCurrentDirectory() + "/" + dbFilename);
                SQLiteConnection.CreateFile(dbFilename);
                Console.WriteLine("Creating a new DB");

                //Open Database connection
                db = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
                db.Open();
                SQLiteCommand createUsersTable = new SQLiteCommand(DB_Tables.USERS, db);
                createUsersTable.ExecuteNonQuery();
                SQLiteCommand createTicketsTable = new SQLiteCommand(DB_Tables.TICKET,db);
                createTicketsTable.ExecuteNonQuery();
            }
            else
            {
                Console.WriteLine("Opening DB");
                db = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
                db.Open();
            }
        }

        public void AddTicket(Ticket ticket)
        {
            int authorid = this.GetUserId(ticket.authoremail);
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO tickets(author, title, description, creationDate, status) VALUES(\"" +
                 authorid.ToString() + "\",\"" +
                 ticket.title + "\",\"" +
                 ticket.description + "\",\"" +
                 ticket.creationDate + "\",\"" +
                 ticket.status + "\");",
                 db);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public void AddUser(User user)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO users(name, email, type) VALUES(\"" +
                 user.name + "\",\"" +
                 user.email + "\",\"" +
                 user.type + "\");",
                 db);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public Ticket[] GetUnassignedTickets()
        {
            SQLiteCommand cmd = new SQLiteCommand(
                                "SELECT * FROM tickets WHERE status=\"Unassigned\"",
                                db);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Ticket> tickets = new List<Ticket>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string author = this.GetUser(reader.GetInt32(1)).email;
                string title = reader.GetString(2);
                string description = reader.GetString(3);
                string creationDate = reader.GetString(4);
                string status = reader.GetString(5);
                string solver = reader.IsDBNull(6)? null: this.GetUser(reader.GetInt32(6)).email;
                string answer = reader.IsDBNull(7) ? null : reader.GetString(7);

                Ticket ticket = new Ticket(id, author, title, description,
                    creationDate, status, solver, answer);
                tickets.Add(ticket);
            }

            cmd.Dispose();
            return tickets.ToArray();
        }

        public Ticket[] GetAllTicketsFromSolver(string useremail)
        {
            int userid = GetUserId(useremail);
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM tickets WHERE solver="+ userid.ToString(),
                db);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Ticket> tickets = new List<Ticket>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string author = this.GetUser(reader.GetInt32(1)).email;
                string title = reader.GetString(2);
                string description = reader.GetString(3);
                string creationDate = reader.GetString(4);
                string status = reader.GetString(5);
                string solver = reader.IsDBNull(6) ? null : this.GetUser(reader.GetInt32(6)).email;
                string answer = reader.IsDBNull(7) ? null : reader.GetString(7);

                Ticket ticket = new Ticket(id, author, title, description,
                    creationDate, status, solver, answer);
                tickets.Add(ticket);
            }

            cmd.Dispose();
            return tickets.ToArray();
        }

        public Ticket[] GetAllTicketsFromUser(string useremail)
        {
            int userid = GetUserId(useremail);
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM tickets WHERE author=" + userid.ToString() ,
                db);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Ticket> tickets = new List<Ticket>();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string author = this.GetUser(reader.GetInt32(1)).email;
                string title = reader.GetString(2);
                string description = reader.GetString(3);
                string creationDate = reader.GetString(4);
                string status = reader.GetString(5);
                string solver = reader.IsDBNull(6) ? null : this.GetUser(reader.GetInt32(6)).email;
                string answer = reader.IsDBNull(7) ? null : reader.GetString(7);

                Ticket ticket = new Ticket(id, author, title, description,
                    creationDate, status, solver, answer);
                tickets.Add(ticket);
            }

            cmd.Dispose();
            return tickets.ToArray();
        }

        public bool AssignSolverToTicket(string solveremail, int ticketid)
        {
            int solverid = GetUserId(solveremail);
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE tickets SET " +
                 "solver=" + solverid.ToString() + "," +
                 "status=\"Assigned\" " +
                 "WHERE id="+ ticketid.ToString() + " AND solver IS NULL;",
                 db);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            return true;
        }

        public int GetUserId(string useremail)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT id FROM users WHERE email=\"" + useremail + "\"",
                db);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int id = reader.GetInt32(0);
                cmd.Dispose();
                return id;
            }
            else
            {
                cmd.Dispose();
                return 0;
            }
        }

        public User GetUser(int id)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM users WHERE id=" + id.ToString(),
                db);
            SQLiteDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string name = reader.GetString(1);
            string email = reader.GetString(2);
            string type = reader.GetString(3);

            cmd.Dispose();

            return new User(name, email, type);
        }

        public User[] GetUsers(string type)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM users WHERE type=\"" + type + "\"",
                db);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<User> users = new List<User>();
            while (reader.Read())
            {
                string name = reader.GetString(1);
                string email = reader.GetString(2);
                string usertype = reader.GetString(3);


                User user = new User(name, email, usertype);
                users.Add(user);
            }

            cmd.Dispose();
            return users.ToArray();
        }
    }
}
