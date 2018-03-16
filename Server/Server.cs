using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Server.exe.config", false);
            Console.WriteLine("Server initialized. Press enter to exit");
            Console.ReadLine();
        }
    }

    public class Coordinator : MarshalByRefObject
    {
        /**
         * double -> Diginote.serialNumber
         * string -> User.nickname
         **/
        Dictionary<double, string> ownershipTable;
        Dictionary<string, User> usersList;
        float diginoteQuote;

        public Coordinator()
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<double, string>();
            this.usersList = new Dictionary<string, User>();
            this.diginoteQuote = 1;
        }

        public Coordinator(Dictionary<string, User> usersList)
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<double, string>();
            this.usersList = usersList;
            this.diginoteQuote = 1;
        }

        public Dictionary<double, string> OwnershipTable
        {
            get => ownershipTable;
        }
        public Dictionary<string, User> UsersList
        {
            get => usersList;
        }

        public float DiginoteQuote
        {
            get => diginoteQuote;
            set
            {
                if(value > 0)
                {
                    diginoteQuote = value;
                }
                else
                {
                    throw new ArgumentException("Quote cannot be null or negative");
                }
            }
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
                throw new System.ArgumentException("User is not registered");
        }

        public bool logOut(string nickname)
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
    }
}
