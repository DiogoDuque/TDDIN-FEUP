using System;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace ServiceLib
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        void AddTicket(string author, string description);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Ticket[] GetUnassignedTickets();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Ticket[] GetAllTicketsFromAuthor(string username);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Ticket[] GetAllTicketsFromSolver(string username);

        [OperationContract]
        [WebInvoke(Method = "PUT", ResponseFormat = WebMessageFormat.Json)]
        void AssignSolverToTicket(string author, string description, string solver);
    }

    public enum TicketStatus
    {
        UNASSIGNED,
        ASSIGNED,
        WAITING,
        SOLVED
    }
    
    public class Ticket
    {
        public string author;
        public string description;
        public DateTime creationDate;
        public TicketStatus status;

        public string solver;
        public string answer;

        public string 
    }
}
