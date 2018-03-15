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

        public Coordinator()
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<double, string>();
            this.usersList = new Dictionary<string, User>();
        }

        public Coordinator(Dictionary<string, User> usersList)
        {
            Console.WriteLine("Called Constructor");
            this.ownershipTable = new Dictionary<double, string>();
            this.usersList = usersList;
        }

        public Dictionary<double, string> OwnershipTable
        {
            get => ownershipTable;
        }
        public Dictionary<string, User> UsersList
        {
            get => usersList;
        }

        /**
         * Registers the user if he isn't yet in the usersList
         **/
        public bool Register(User user)
        {
            if (!usersList.ContainsKey(user.Nickname))
            {
                usersList.Add(user.Nickname, user);
                Console.WriteLine("REGISTER: Success");
                return true;
            }
            else
            {
                Console.WriteLine("REGISTER: Failure");
                return false;
            }
        }

        /**
         * Returns true if user was logged out, 
         **/
        public bool LogIn(User user)
        {
            if (usersList.ContainsKey(user.Nickname))
            {
                if (usersList[user.Nickname].IsLoggedIn)
                    return false;
                else
                {
                    usersList[user.Nickname].IsLoggedIn = true;
                    return true;
                }
            }
            else
                throw new System.ArgumentException("User is not registered");
        }

        public bool logOut(User user)
        {
            if (usersList.ContainsKey(user.Nickname))
            {
                if (!usersList[user.Nickname].IsLoggedIn)
                    return false;
                else
                {
                    usersList[user.Nickname].IsLoggedIn = false;
                    return true;
                }
            }
            else
                throw new System.ArgumentException("User is not registered");
        }
    }
}
