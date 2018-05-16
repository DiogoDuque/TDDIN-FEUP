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
            if (!IsValid(username))
                return null;

            if (!AllowCORS())
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

            if (!AllowCORS())
                return null;

            Ticket[] tickets = new Ticket[4];
            for (int i = 0; i < 4; i++)
            {
                tickets[i] = new Ticket("user0" + i, "title"+i, "GetAllTicketsFromSolver(" + username + ") hard coded description " + i);
            }
            return tickets;
        }

        public Ticket[] GetUnassignedTickets()
        {
            if (!AllowCORS())
                return null;

            return Db.GetInstance().GetUnassignedTickets();
        }

        public void AddTicket(string author, string title, string description)
        {
            if (!IsValid(author) || !IsValid(title) || !IsValid(description))
                return;

            if (!AllowCORS())
                return;

            Db.GetInstance().AddTicket(new Ticket(author, title, description));
        }

        public void AssignSolverToTicket(string author, string title, string solver)
        {
            if (!IsValid(author) || !IsValid(title) || !IsValid(solver))
                return;

            if (!AllowCORS())
                return;

            throw new NotImplementedException();
        }
    }
}
