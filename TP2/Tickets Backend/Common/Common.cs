using System;

namespace Common
{
    [Serializable]
    public enum TicketStatus
    {
        UNASSIGNED, // default status
        ASSIGNED,   // assigned to solver
        WAITING,    // waiting for specialized response
        SOLVED      // solved
    }

    public class Ticket
    {
        public string author;
        public string description;
        public DateTime creationDate;
        public TicketStatus status;

        public string solver;
        public string answer;

        public string specializedSolver;
        public string specializedAnswer;

        public Ticket(string author, string description)
        {
            this.author = author;
            this.description = description;
            this.creationDate = new DateTime();
            this.status = TicketStatus.UNASSIGNED;
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
