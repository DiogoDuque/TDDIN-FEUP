using System;
using RabbitMQ.Client;
using Common;
using Database;
using System.Text;
using System.Net.Mail;

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

        public Ticket[] GetAllTicketsFromAuthor(string useremail)
        {
            Console.WriteLine("GetAllTicketsFromAuthor: " + useremail);
            if (!IsValid(useremail))
                return null;

            return Db.GetInstance().GetAllTicketsFromUser(useremail);
        }

        public Ticket[] GetAllTicketsFromSolver(string useremail)
        {
            Console.WriteLine("GetAllTicketsFromSolver: " + useremail);
            if (!IsValid(useremail))
                return null;

            return Db.GetInstance().GetAllTicketsFromSolver(useremail);
        }

        public Ticket[] GetUnassignedTickets()
        {
            Console.WriteLine("GetUnassignedTickets: ()");
            Ticket[] result = Db.GetInstance().GetUnassignedTickets();
            Console.WriteLine("Num Unassigned Tickets: " + result.Length);
            return result;
        }

        public bool AddTicket(string author, string title, string description)
        {
            if (!IsValid(author) || !IsValid(title) || !IsValid(description))
                return false;

            Db.GetInstance().AddTicket(new Ticket(author, title, description));
            return true;
        }

        public bool AssignSolverToTicket(string solveremail, int ticketid)
        {
            if (!IsValid(solveremail))
                return false;

            return Db.GetInstance().AssignSolverToTicket(solveremail, ticketid);
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
            Console.WriteLine("GetUsers: " + type);
            if (!IsUserType(type))
            {
                Console.WriteLine("Fail");
                return null;
            }
            User[] result = Db.GetInstance().GetUsers(type);
            Console.WriteLine("Num Users of type "+ type + " : " + result.Length);
            return result;
        }

        public bool AskSpecializedQuestion(int id, string question, string creationDate)
        {
            Db.GetInstance().AskSpecializedQuestion(id, question, creationDate);

            // send by MQ to department
            Ticket ticket = Db.GetInstance().GetTicketAndAssociatedQuestions(id);

            ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "DepartmentQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                
                var body = Encoding.UTF8.GetBytes(ticket.ToString());

                channel.BasicPublish(exchange: "",
                                     routingKey: "department",
                                     basicProperties: null,
                                     body: body);
            }

            return true;
        }

        public bool AnswerSpecializedQuestion(int ticketId, string answer)
        {
            Db.GetInstance().AnswerSpecializedQuestion(ticketId, answer);
            return true;
        }

        public Ticket[] GetTicketsForUnansweredSpecializedQuestions()
        {
            return Db.GetInstance().GetTicketsForUnansweredSpecializedQuestions();
        }

        public Ticket[] GetTicketsAndQuestions(string solveremail)
        {
            if(!IsValid(solveremail))
            {
                return null;
            }

            Ticket[] result = Db.GetInstance().GetAllTicketsAndQuestionsFromUser(solveremail);
            return result;
        }

        public bool CloseTicket(int ticketId, string emailtext)
        {
            Ticket ticket = Db.GetInstance().GetTicketAndAssociatedQuestions(ticketId);
            bool closedTicket = Db.GetInstance().CloseTicket(ticketId);

            if (!closedTicket)
                return false;

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient emailclient = new SmtpClient("smtp.fe.up.pt");

                mail.From = new MailAddress("up201404293@fe.up.pt");
                mail.To.Add(ticket.authoremail);
                mail.Subject = "Answer to Ticket \"" + ticket.title + "\"";
                mail.Body = emailtext;

                emailclient.Port = 587;
                emailclient.Credentials = new System.Net.NetworkCredential("up201404293", "4setembro2000_2114"); //RIP, agora o prof sabe a minha pass do mail
                emailclient.EnableSsl = true;

                emailclient.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
            Console.WriteLine(emailtext);

            return true;
        }
    }
}
