using Common;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
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


        //CONSTRUCTORS

        public Coordinator()
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<long, string>();
            this.usersList = new Dictionary<string, User>();
            this.notesList = new Dictionary<long, Diginote>();
            this.diginoteQuote = 1;
            this.db = new DiginoteDB(false);
            LoadDataFromDatabase();
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
            }
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
    }
}
