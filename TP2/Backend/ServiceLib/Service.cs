using System;
using System.ServiceModel.Web;
using Common;

namespace ServiceLib
{
    public class Service : IService
    {
        private bool AllowCORS()
        {
            WebOperationContext.Current.OutgoingResponse.Headers
                .Add("Access-Control-Allow-Origin", "*");
            //identify preflight request and add extra headers
            if (WebOperationContext.Current.IncomingRequest.Method == "OPTIONS")
            {
                WebOperationContext.Current.OutgoingResponse.Headers
                    .Add("Access-Control-Allow-Methods", "POST, OPTIONS, GET");
                WebOperationContext.Current.OutgoingResponse.Headers
                    .Add("Access-Control-Allow-Headers",
                         "Content-Type, Accept, Authorization, x-requested-with");
                return false;
            }
            return true;
        }
        public Ticket[] GetAllTicketsFromAuthor(string username)
        {
            if (!AllowCORS())
                return null;

            Ticket[] tickets = new Ticket[4];
            for(int i=0; i<4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "GetAllTicketsFromAuthor hard coded description " + i);
            }
            return tickets;
        }

        public Ticket[] GetAllTicketsFromSolver(string username)
        {
            if (!AllowCORS())
                return null;

            Ticket[] tickets = new Ticket[4];
            for (int i = 0; i < 4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "GetAllTicketsFromSolver(" + username + ") hard coded description " + i);
            }
            return tickets;
        }

        public Ticket[] GetUnassignedTickets()
        {
            if (!AllowCORS())
                return null;

            Ticket[] tickets = new Ticket[4];
            for (int i = 0; i < 4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "GetUnassignedTickets hard coded description " + i);
            }
            return tickets;
        }

        public void AddTicket(string author, string description)
        {
            /*if (!AllowCORS())
                return null;*/

            throw new NotImplementedException();
        }

        public void AssignSolverToTicket(string author, string description, string solver)
        {
            /*if (!AllowCORS())
                return null;*/

            throw new NotImplementedException();
        }
    }
}
