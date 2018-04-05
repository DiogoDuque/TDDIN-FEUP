using Common;
using Database;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Coord
{
    public class Coordinator : MarshalByRefObject
    {
        /**
         * double -> Diginote.serialNumber
         * string -> User.nickname
         **/
        Dictionary<long, string> ownershipTable;
        Dictionary<string, User> usersList;
        Dictionary<long, Diginote> notesList;
        float diginoteQuote;
        DiginoteDB db;
        public event LogDelegate logger;
        public event UpdateDelegate update;
        public event QuoteChange onQuoteChange;
        private MessageQueue sellingMessageQueue;
        private MessageQueue buyingMessageQueue;
        private Queue<Order> sellingOrders;
        private Queue<Order> buyingOrders;


        //CONSTRUCTORS

        public Coordinator()
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<long, string>();
            this.usersList = new Dictionary<string, User>();
            this.notesList = new Dictionary<long, Diginote>();
            this.sellingOrders = new Queue<Order>();
            this.buyingOrders = new Queue<Order>();
            this.db = new DiginoteDB(false);
            this.diginoteQuote = db.GetCurrentQuote();
            LoadDataFromDatabase();
            InitMessageQueues();
        }

        /// <summary>
        /// Deletes and creates a new Database if dbreset is true
        /// </summary>
        /// <param name="dbreset"></param>
        public Coordinator(bool dbreset)
            : this(new Dictionary<string, User>(), new Dictionary<long, Diginote>(), new Dictionary<long, string>(), dbreset)
        {
            if (!dbreset)
                LoadDataFromDatabase();
        }

        /// <summary>
        /// Deletes and creates a new Database if dbreset is true
        /// </summary>
        /// <param name="usersList"></param>
        /// <param name="dbreset"></param>
        public Coordinator(Dictionary<string, User> usersList, bool dbreset = false)
            : this(usersList, new Dictionary<long, Diginote>(), new Dictionary<long, string>(), dbreset)
        {

        }

        public Coordinator(Dictionary<string, User> usersList, Dictionary<long, Diginote> notesList,
            Dictionary<long, string> ownershipTable, bool dbreset = false)
        {
            Console.WriteLine("Called Constructor");
            this.diginoteQuote = 1;
            this.db = new DiginoteDB(dbreset);
            this.ownershipTable = ownershipTable;
            this.notesList = notesList;
            this.usersList = usersList;
        }


        //GETTERS AND SETTERS
        /*
         * Maybe we shouldnt allow the programmer to access directly to the Ownership table
        public Dictionary<long, string> OwnershipTable
        {
            get => ownershipTable;
        }
        */
        public Dictionary<string, User> UsersList
        {
            get => usersList;
        }

        public Dictionary<long, Diginote> NotesList
        {
            get => notesList;
        }

        public Dictionary<long, string> OwnershipTable
        {
            get => ownershipTable;
        }

        public float DiginoteQuote
        {
            get => diginoteQuote;
            /*
            set
            {
                if (value > 0)
                {
                    diginoteQuote = value;
                }
                else
                {
                    throw new ArgumentException("Quote cannot be null or negative");
                }
            }*/
        }

        public DiginoteDB Db
        {
            get => db;
        }

        /// <summary>
        /// Registers a user in the server database.
        /// PASSWORD MUST BE HASHED
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool Register(User user)
        {
            if (!usersList.ContainsKey(user.Nickname))
            {
                usersList.Add(user.Nickname, user);
                db.insertUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Logs a user in.
        /// PASSWORD MUST BE HASHED BEFORE
        /// </summary>
        /// <param name="nickname"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool LogIn(string nickname, string password)
        {
            if (usersList.ContainsKey(nickname))
            {
                if (usersList[nickname].Password == password)
                {
                    if (usersList[nickname].IsLoggedIn)
                        return false;
                    else
                    {
                        usersList[nickname].IsLoggedIn = true;
                        return true;
                    }
                }
                else
                {
                    //TODO Sera que devia lançar uma excepção aqui? Ou acima, no Loggedin?
                    return false;
                }
            }
            else
                throw new System.ArgumentException("User is not registered!");
        }

        public bool LogOut(string nickname)
        {
            if (usersList.ContainsKey(nickname))
            {
                if (!usersList[nickname].IsLoggedIn)
                    return false;
                else
                {
                    usersList[nickname].IsLoggedIn = false;
                    return true;
                }
            }
            else
                throw new System.ArgumentException("User is not registered");
        }

        public bool CreateDiginote(string ownerNickname)
        {
            if (!usersList.ContainsKey(ownerNickname))
                throw new ArgumentException("Nickname doesnt exist");

            long serialNumber = ownershipTable.Count + 1;
            Diginote note = new Diginote(serialNumber, ownerNickname);
            notesList.Add(serialNumber, note);
            ownershipTable.Add(serialNumber, ownerNickname);
            db.insertDiginote(serialNumber, ownerNickname);
            return true;
        }

        public int GetUserDiginoteQuantity(string ownerNickname)
        {
            int result = 0;

            foreach(KeyValuePair<long, string> pair in ownershipTable)
            {
                if (pair.Value == ownerNickname)
                    result += 1;
            }

            return result;
        }

        /// <summary>
        /// Transfers a quantity of diginotes from the first user to the second
        /// </summary>
        /// <param name="oldOwnerNickname"></param>
        /// <param name="newOwnerNickname"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool TransferDiginotes(string oldOwnerNickname, string newOwnerNickname, int quantity)
        {
            List<Diginote> oldOwnerDiginotes = new List<Diginote>();
            bool ownerHasEnough = false;

            foreach (KeyValuePair<long, string> entry in ownershipTable)
            {
                if (entry.Value == oldOwnerNickname)
                {
                    oldOwnerDiginotes.Add(notesList[entry.Key]);
                }

                if (oldOwnerDiginotes.Count == quantity)
                {
                    ownerHasEnough = true;
                    break;
                }
            }

            if (ownerHasEnough)
            {
                foreach (Diginote note in oldOwnerDiginotes)
                {
                    note.OwnerNickname = newOwnerNickname;
                    ownershipTable[note.SerialNumber] = newOwnerNickname;
                    db.transferDiginote(note.SerialNumber, newOwnerNickname);
                }

                //Send transaction to the logs
                if (this.logger != null)
                    this.logger(oldOwnerNickname, newOwnerNickname, oldOwnerDiginotes.Count);
                else
                    Console.WriteLine("Logger not available");
                return true;
            }
            else
            {
                return false;
            }
        }

        //TODO this should not be public, but tests need that the method is public.
        public void LoadDataFromDatabase()
        {
            List<User> userList = db.getAllUsers();
            List<Diginote> noteList = db.getAllDiginotes();
            sellingOrders = db.getAllSellingOrders();
            buyingOrders = db.GetBuyingOrders();

            foreach (User user in userList)
            {
                this.usersList.Add(user.Nickname, user);
            }

            foreach (Diginote note in noteList)
            {
                this.notesList.Add(note.SerialNumber, note);
                this.ownershipTable.Add(note.SerialNumber, note.OwnerNickname);
            }
        }

        private void InitMessageQueues()
        {
            if (MessageQueue.Exists(@".\Private$\sellingOrders"))
            {
                sellingMessageQueue = new MessageQueue(@".\private$\sellingOrders");
                sellingMessageQueue.Formatter = new BinaryMessageFormatter();
                sellingMessageQueue.ReceiveCompleted += SellingQueueReceiver;
                sellingMessageQueue.BeginReceive();
            }
            else Console.WriteLine("Could not init sellingOrders MessageQueue");

            if (MessageQueue.Exists(@".\Private$\purchaseOrders"))
            {
                buyingMessageQueue = new MessageQueue(@".\private$\purchaseOrders");
                buyingMessageQueue.Formatter = new BinaryMessageFormatter();
                buyingMessageQueue.ReceiveCompleted += BuyingQueueReceiver;
                buyingMessageQueue.BeginReceive();
            }
            else Console.WriteLine("Could not init purchaseOrders MessageQueue");
        }

        private void SellingQueueReceiver(object src, ReceiveCompletedEventArgs rcea)
        {
            Message msg = sellingMessageQueue.EndReceive(rcea.AsyncResult);
            Order sellingOrder;
            if (msg.Body is Order && ((Order)msg.Body).type.Equals(OrderType.SELLING))
            {
                sellingOrder = (Order)msg.Body;
                int userDiginotes = GetUserDiginoteQuantity(sellingOrder.owner);
                int userSellingOrders = GetAmountSellingOrders(sellingOrder.owner);
                if (userDiginotes - userSellingOrders < 1)
                    throw new InvalidOperationException("Cannot create selling orders when there is no more diginotes to sell");

                db.AddOrder(sellingOrder);

                //handle and trigger action if necessary
                sellingOrders.Enqueue(sellingOrder);
                if (buyingOrders.Count > 0)
                {
                    MatchOrders();
                }

                if (update != null)
                {
                    this.update();
                }

                sellingMessageQueue.BeginReceive();
            }
            else Console.WriteLine("Invalid selling order received!");
        }

        private void BuyingQueueReceiver(object src, ReceiveCompletedEventArgs rcea)
        {
            Message msg = buyingMessageQueue.EndReceive(rcea.AsyncResult);

            Order buyingOrder;
            if (msg.Body is Order && ((Order)msg.Body).type.Equals(OrderType.BUYING))
            {
                buyingOrder = (Order)msg.Body;
                db.AddOrder(buyingOrder);

                //handle and trigger action if necessary
                buyingOrders.Enqueue(buyingOrder);
                if (sellingOrders.Count > 0)
                {
                    MatchOrders();
                }

                if(update != null)
                {
                    this.update();
                }

                buyingMessageQueue.BeginReceive();
            }
            else Console.WriteLine("Invalid buying order received!");
        }

        private void MatchOrders()
        {
            while(sellingOrders.Count>0 && buyingOrders.Count>0)
            {
                Order sellingOrder = sellingOrders.Dequeue();
                Order buyingOrder = buyingOrders.Dequeue();
                bool result = TransferDiginotes(sellingOrder.owner, buyingOrder.owner, 1);
                if (result)
                {
                    db.RemoveOrder(sellingOrder);
                    db.RemoveOrder(buyingOrder);
                }
                else Console.WriteLine("Error happened when matching orders!");
            }
        }

        public int GetAmountSellingOrders(string nickname = null)
        {
            if (nickname == null)
                return sellingOrders.Count;

            int count=0;
            foreach(Order order in sellingOrders)
            {
                if (order.owner.Equals(nickname))
                    count++;
            }
            return count;
        }

        public int GetAmountBuyingOrders(string nickname = null)
        {
            if (nickname == null)
                return buyingOrders.Count;

            int count = 0;
            foreach (Order order in buyingOrders)
            {
                if (order.owner.Equals(nickname))
                    count++;
            }
            return count;
        }

        public void CancelSellingOrders(int numberOfOrders)
        {
            for (int i = 0; i < numberOfOrders; i++)
            {
                Order sellingOrder = sellingOrders.Dequeue();
                db.RemoveOrder(sellingOrder);
            }
        }

        public void CancelPurchasingOrders(int numberOfOrders)
        {
            for (int i = 0; i < numberOfOrders; i++)
            {
                Order purchasingOrder = buyingOrders.Dequeue();
                db.RemoveOrder(purchasingOrder);
            }
        }

        public void ChangeQuote(string username, float newquote, OrderType orderType)
        {
            if (newquote > 0)
            {
                if ((newquote >= diginoteQuote && orderType == OrderType.BUYING) ||
                    (newquote <= diginoteQuote && orderType == OrderType.SELLING))
                {
                    diginoteQuote = newquote;
                    db.UpdateCurrentQuote(newquote);
                    if (onQuoteChange != null)
                    {
                        onQuoteChange(username, (decimal)diginoteQuote, orderType);
                    }
                }
                else
                {
                    throw new ArgumentException("Quote surpassed the limits");
                }
            }
            else
            {
                throw new ArgumentException("Quote cannot be null or negative");
            }
        }
    }
}
