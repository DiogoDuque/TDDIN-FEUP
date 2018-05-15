using System;
using Common;

namespace ServiceLib
{
    public class Service : IService
    {
        public Ticket[] GetAllTicketsFromAuthor(string username)
        {
            Ticket[] tickets = new Ticket[4];
            for(int i=0; i<4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "GetAllTicketsFromAuthor hard coded description " + i);
            }
            return tickets;
        }

        public Ticket[] GetAllTicketsFromSolver(string username)
        {
            Ticket[] tickets = new Ticket[4];
            for (int i = 0; i < 4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "GetAllTicketsFromSolver(" + username + ") hard coded description " + i);
            }
            return tickets;
        }

        public Ticket[] GetUnassignedTickets()
        {
            Ticket[] tickets = new Ticket[4];
            for (int i = 0; i < 4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "GetUnassignedTickets hard coded description " + i);
            }
            return tickets;
        }

        public void AddTicket(string author, string description)
        {
            throw new NotImplementedException();
        }

        public void AssignSolverToTicket(string author, string description, string solver)
        {
            throw new NotImplementedException();
        }
    }
}
