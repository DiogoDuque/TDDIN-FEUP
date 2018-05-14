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

    [Serializable]
    public class Ticket
    {
        public string author;
        public string description;
        public string creationDate;
        public string status;

        public string solver;
        public string answer;

        public string specializedSolver;
        public string specializedAnswer;

        public Ticket(string author, string description)
        {
            this.author = author;
            this.description = description;
            DateTime creationDate = DateTime.Now;
            this.creationDate = creationDate.ToShortTimeString() + " " + creationDate.ToShortDateString();
            this.status = TicketStatus.UNASSIGNED;
        }

        public Ticket(string author, string description, string creationDate, string status,
            string solver, string answer, string specializedSolver, string specializedAnswer)
        {
            this.author = author;
            this.description = description;
            this.creationDate = creationDate;
            this.status = status;
            this.solver = solver;
            this.answer = answer;
            this.specializedSolver = specializedSolver;
            this.specializedAnswer = specializedAnswer;
        }

        public bool AssignSolver(string solver)
        {
            if (this.status.Equals(TicketStatus.UNASSIGNED))
            {
                this.solver = solver;
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
                this.specializedSolver = specializedSolver;
                this.status = TicketStatus.WAITING;
                return true;
            }
            return false;
        }

        public bool GiveSpecializedAnswer(string specializedAnswer)
        {
            if (this.status.Equals(TicketStatus.WAITING))
            {
                this.specializedAnswer = specializedAnswer;
                return true;
            }
            return false;
        }
    }
}
