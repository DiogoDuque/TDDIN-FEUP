using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceLib
{
    public class Service : IService
    {
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
            throw new NotImplementedException();
        }
    }
}
