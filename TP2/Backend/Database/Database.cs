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
            "author VARCHAR(30) NOT NULL, " +
            "title VARCHAR(80) UNIQUE NOT NULL, " +
            "description VARCHAR(1500) NOT NULL, " +
            "creationDate VARCHAR(30) NOT NULL, " +
            "status VARCHAR(15) NOT NULL, " +
            "solver VARCHAR(30), " +
            "answer VARCHAR(1500), " +
            "specializedSolver VARCHAR(30), " +
            "specializedAnswer VARCHAR(1500)" +
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
                SQLiteConnection.CreateFile(dbFilename);
                Console.WriteLine("Creating a new DB");

                //Open Database connection
                db = new SQLiteConnection("Data Source=" + dbFilename + ";Version=3;");
                db.Open();
                SQLiteCommand createDatabase = new SQLiteCommand(DB_Tables.TICKET,db);
                createDatabase.ExecuteNonQuery();
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
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO tickets(author, title, description, creationDate, status) VALUES(\"" +
                 ticket.author + "\",\"" +
                 ticket.title + "\",\"" +
                 ticket.description + "\",\"" +
                 ticket.creationDate + "\",\"" +
                 ticket.status + "\");",
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
                Ticket ticket = new Ticket(reader.GetString(1), reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                    reader.GetString(8), reader.GetString(9));
                tickets.Add(ticket);
            }

            cmd.Dispose();
            return tickets.ToArray();
        }

        public Ticket[] GetAllTicketsFromSolver(string username)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT * FROM tickets WHERE solver=\""+username+"\"",
                db);
            SQLiteDataReader reader = cmd.ExecuteReader();

            List<Ticket> tickets = new List<Ticket>();
            while (reader.Read())
            {
                Ticket ticket = new Ticket(reader.GetString(1), reader.GetString(2), reader.GetString(3),
                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7),
                    reader.GetString(8), reader.GetString(9));
                tickets.Add(ticket);
            }

            cmd.Dispose();
            return tickets.ToArray();
        }
    }
}
