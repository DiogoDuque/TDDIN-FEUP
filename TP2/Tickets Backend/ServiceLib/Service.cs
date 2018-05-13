using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
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
                tickets[i] = new Ticket("user0" + i, "GetAllTicketsFromSolver hard coded description " + i);
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

        void IService.AddTicket(string author, string description)
        {
            throw new NotImplementedException();
        }

        void IService.AssignSolverToTicket(string author, string description, string solver)
        {
            throw new NotImplementedException();
        }

        Ticket[] IService.GetAllTicketsFromAuthor(string username)
        {
            throw new NotImplementedException();
        }

        Ticket[] IService.GetAllTicketsFromSolver(string username)
        {
            throw new NotImplementedException();
        }

        Ticket[] IService.GetUnassignedTickets()
        {
            Ticket[] tickets = new Ticket[4];
            for (int i = 0; i < 4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "GetUnassignedTickets hard coded description " + i);
            }
            return tickets;
        }
    }
}
