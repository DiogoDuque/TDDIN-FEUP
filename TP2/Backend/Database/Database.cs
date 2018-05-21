using System;
using System.Collections;
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

        public static string QUESTIONS = "CREATE TABLE questions(" +
            "id INTEGER PRIMARY KEY, " +
            "solver_id INTEGER REFERENCES users(id) NOT NULL, " +
            "ticket_id INTEGER REFERENCES tickets(id) NOT NULL, " +
            "question VARCHAR(1500) NOT NULL, " +
            "answer VARCHAR(1500)" +
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
                SQLiteCommand createTicketsTable = new SQLiteCommand(DB_Tables.TICKET, db);
                createTicketsTable.ExecuteNonQuery();
                SQLiteCommand createQuestionsTable = new SQLiteCommand(DB_Tables.QUESTIONS, db);
                createQuestionsTable.ExecuteNonQuery();
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
                string author = this.GetUser(reader.GetInt32(1)).email;
                string title = reader.GetString(2);
                string description = reader.GetString(3);
                string creationDate = reader.GetString(4);
                string status = reader.GetString(5);
                string solver = reader.IsDBNull(6)? null: this.GetUser(reader.GetInt32(6)).email;
                string answer = reader.IsDBNull(7) ? null : reader.GetString(7);

                Ticket ticket = new Ticket(author, title, description,
                    creationDate, status, solver, answer);
                tickets.Add(ticket);
            }

            cmd.Dispose();
            return tickets.ToArray();
        }

        //TODO Talvez mudar o nome da variavel para "email"
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
                string author = this.GetUser(reader.GetInt32(1)).email;
                string title = reader.GetString(2);
                string description = reader.GetString(3);
                string creationDate = reader.GetString(4);
                string status = reader.GetString(5);
                string solver = reader.IsDBNull(6) ? null : this.GetUser(reader.GetInt32(6)).email;
                string answer = reader.IsDBNull(7) ? null : reader.GetString(7);

                Ticket ticket = new Ticket(author, title, description,
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
                string author = this.GetUser(reader.GetInt32(1)).email;
                string title = reader.GetString(2);
                string description = reader.GetString(3);
                string creationDate = reader.GetString(4);
                string status = reader.GetString(5);
                string solver = reader.IsDBNull(6) ? null : this.GetUser(reader.GetInt32(6)).email;
                string answer = reader.IsDBNull(7) ? null : reader.GetString(7);

                Ticket ticket = new Ticket(author, title, description,
                    creationDate, status, solver, answer);
                tickets.Add(ticket);
            }

            cmd.Dispose();
            return tickets.ToArray();
        }

        public bool AssignSolverToTicket(string author, string title, string solver)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "UPDATE tickets SET " +
                 "solver=\"" + solver + "\"," +
                 "status=\"Assigned\"" +
                 "WHERE author=\""+author+"\" AND title=\""+title+"\" AND solver IS NULL);",
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

        public void AskSpecializedQuestion(string ticketTitle, string question)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "INSERT INTO questions(solver_id, ticket_id, question) " +
                "(SELECT tickets.solver as solver_id, "+
                "tickets.id as ticket_id "+
                "FROM tickets WHERE title=\""+ticketTitle+"\"), "+
                "\""+question+"\" AS question" +
                ");",
                 db);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public Ticket GetTicketAndAssociatedQuestions(string ticketTitle)
        {
            SQLiteCommand cmd = new SQLiteCommand(
                "SELECT tickets.description, tickets.creationDate, tickets.status, users.email, "+
                "questions.question, question.answer "+
                "FROM tickets WHERE tickets.title=\"" + ticketTitle + "\" " +
                "INNER JOIN questions ON tickets.id=questions.ticket_id "+
                "INNER JOIN users on tickets.author=user.id",
                db);
            SQLiteDataReader reader = cmd.ExecuteReader();

            Dictionary<string, Question> questions = new Dictionary<string, Question>();
            Ticket ticket = null;

            while(reader.Read())
            {
                if(ticket==null)
                {
                    string description = reader.GetString(0);
                    string creationDate = reader.GetString(1);
                    string status = reader.GetString(2);
                    string author = reader.GetString(3);
                    ticket = new Ticket(author, ticketTitle, description);
                    ticket.creationDate = creationDate;
                    ticket.status = status;
                }
                string question = reader.GetString(4);
                string answer = reader.IsDBNull(5) ? null : reader.GetString(5);
                if(!questions.ContainsKey(question))
                {
                    questions.Add(question, new Question(question, answer));
                }
            }
            Dictionary<string, Question>.ValueCollection qVals = questions.Values;
            ticket.questions = new Question[qVals.Count];
            qVals.CopyTo(ticket.questions,0);

            cmd.Dispose();

            return ticket;
        }
        
    }
}
