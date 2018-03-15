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
