using System;
using System.ComponentModel;

namespace Common
{
    [Serializable]
    public class TicketStatus
    {
        public static string UNASSIGNED = "Unassigned"; // default status
        public static string ASSIGNED = "Assigned";     // assigned to solver
        public static string WAITING = "Waiting";       // waiting for specialized response
        public static string SOLVED = "Solved";         // solved
    }

    //TODO isto nao devia ser um enum?
    [Serializable]
    public class UserType
    {
        public static string WORKER = "Worker";
        public static string SOLVER = "Solver";
    }

    [Serializable]
    public class Ticket
    {
        public int id;
        public string authoremail;
        public string title;
        public string description;
        public string creationDate;
        public string status;

        public string solveremail;
        public string answer;

        public Ticket(string author, string title, string description)
        {
            this.id = 0;
            this.authoremail = author;
            this.title = title;
            this.description = description;
            DateTime creationDate = DateTime.Now;
            this.creationDate = creationDate.ToShortTimeString() + " " + creationDate.ToShortDateString();
            this.status = TicketStatus.UNASSIGNED;
        }

        public Ticket(int id, string author, string title, string description, string creationDate, string status,
            string solver, string answer)
        {
            this.id = id;
            this.authoremail = author;
            this.title = title;
            this.description = description;
            this.creationDate = creationDate;
            this.status = status;
            this.solveremail = solver;
            this.answer = answer;
        }

        public bool AssignSolver(string solver)
        {
            if (this.status.Equals(TicketStatus.UNASSIGNED))
            {
                this.solveremail = solver;
                this.status = TicketStatus.ASSIGNED;
                return true;
            }
            return false;
        }

        public bool Solve(string answer)
        {
            if (this.status.Equals(TicketStatus.ASSIGNED) || this.status.Equals(TicketStatus.WAITING))
            {
                this.answer = answer;
                this.status = TicketStatus.SOLVED;
                return true;
            }
            return false;
        }

        public bool AssignSpecializedSolver(string specializedSolver)
        {
            if (this.status.Equals(TicketStatus.ASSIGNED))
            {
                //TODO REFACTOR WHEN QUESTION OBJECTS ARE IMPLEMENTED
                //this.specializedSolver = specializedSolver;
                this.status = TicketStatus.WAITING;
                return true;
            }
            return false;
        }

        public bool GiveSpecializedAnswer(string specializedAnswer)
        {
            if (this.status.Equals(TicketStatus.WAITING))
            {
                //TODO REFACTOR WHEN QUESTION OBJECTS ARE IMPLEMENTED
                //this.specializedAnswer = specializedAnswer;
                return true;
            }
            return false;
        }
    }

    [Serializable]
    public class User
    {
        public string name;
        public string email;
        public string type;

        public User(string name, string email, string type)
        {
            this.name = name;
            this.email = email;
            if(type == UserType.WORKER || type == UserType.SOLVER)
            {
                this.type = type;
            }
            else
            {
                throw new ArgumentException("Invalid user type");
            }
        }
    }
}
