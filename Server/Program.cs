using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
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
            this.ownershipTable = new Dictionary<double, string>();
            this.usersList = new Dictionary<string, User>();
        }

        public Coordinator(Dictionary<string, User> usersList)
        {
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

        public void register(User user)
        {
            if(!usersList.ContainsKey(user.Nickname))
            {
                usersList.Add(user.Nickname, user);
                Console.WriteLine("User with nickname " + user.Nickname + " already exists");
            }
        }

        public bool logIn(User user)
        {
            if (usersList.ContainsKey(user.Nickname))
            {
                return usersList[user.Nickname].IsLoggedIn = true;
            }
            else
                return false;
        }
    }
}
