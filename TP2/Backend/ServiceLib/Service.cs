using System;
using System.ServiceModel.Web;
using Common;
using Database;

namespace ServiceLib
{
    public class Service : IService
    {
        private bool IsValid(string arg)
        {
            return (arg != null && !arg.Equals(""));
        }

        private bool IsUserType(string arg)
        {
            return (arg == UserType.SOLVER || arg == UserType.WORKER);
        }

        public Ticket[] GetAllTicketsFromAuthor(string username)
        {
            if (!IsValid(username))
                return null;

            Ticket[] tickets = new Ticket[4];
            for(int i=0; i<4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "title"+i, "GetAllTicketsFromAuthor hard coded description " + i);
            }
            return tickets;
        }

        public Ticket[] GetAllTicketsFromSolver(string username)
        {
            if (!IsValid(username))
                return null;

            return Db.GetInstance().GetAllTicketsFromSolver(username);
        }

        public Ticket[] GetUnassignedTickets()
        {
            return Db.GetInstance().GetUnassignedTickets();
        }

        public bool AddTicket(string author, string title, string description)
        {
            if (!IsValid(author) || !IsValid(title) || !IsValid(description))
                return false;

            Db.GetInstance().AddTicket(new Ticket(author, title, description));
            return true;
        }

        public bool AssignSolverToTicket(string author, string title, string solver)
        {
            if (!IsValid(author) || !IsValid(title) || !IsValid(solver))
                return false;

            return Db.GetInstance().AssignSolverToTicket(author, title, solver);
        }

        public bool RegisterUser(string username, string email, string type)
        {
            if (!IsValid(username) || !IsValid(email) || !IsUserType(type))
                return false;

            Db.GetInstance().AddUser(new User(username, email, type));
            return true;
        }

        public User[] GetUsers(string type)
        {
            Console.WriteLine(type);
            if (!IsUserType(type))
            {
                Console.WriteLine("Fail");
                return null;
            }
            User[] result = Db.GetInstance().GetUsers(type);
            Console.WriteLine(result.Length);
            return result;
        }
    }
}
