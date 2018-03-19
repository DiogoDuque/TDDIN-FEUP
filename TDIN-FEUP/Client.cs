using Common;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_FEUP
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("Client.exe.config",false);
            Coordinator coordinator = new Coordinator();
            string message = null;
            while (true)
            {
                try
                {
                    switch (Menu(new string[] { "Register", "Login", "Logout" }, message))
                    {
                        case 0:
                            User registerResult = Register(coordinator);
                            if (registerResult != null)
                                Console.WriteLine("User successfully registered");
                            else
                                Console.WriteLine("Could not register user");
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadLine();
                            break;

                        case 1:
                            bool loginResult = Login(coordinator);
                            if (loginResult)
                                Console.WriteLine("User successfully logged in");
                            else
                                Console.WriteLine("Could not log in");
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadLine();
                            break;

                        case 2:
                            bool logoutResult = Logout(coordinator);
                            if (logoutResult)
                                Console.WriteLine("User successfully logged out");
                            else
                                Console.WriteLine("Could not log out");
                            Console.WriteLine("Press ENTER to continue...");
                            Console.ReadLine();
                            break;

                        default:
                            return;
                    }
                    message = null;
                } catch(ArgumentException aEx)
                {
                    message="Warning: "+aEx.Message;
                }

            }
        }

        private static bool Logout(Coordinator coordinator)
        {
            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();

            return coordinator.LogOut(nickname);
        }

        //TODO Falta hashar a password
        private static bool Login(Coordinator coordinator)
        {
            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            return coordinator.LogIn(nickname, password);
        }

        private static User Register(Coordinator coordinator)
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Nickname: ");
            string nickname = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            User user = new User(name, nickname, password);

            if (coordinator.Register(user))
                return user;
            else return null;
        }

        private static int Menu(string[] options, string message = null)
        {
            int currentIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press Esc to exit at any time.");
                Console.WriteLine();
                if (message != null)
                {
                    Console.WriteLine(message);
                    Console.WriteLine();
                }
                for (int i=0; i<options.Length; i++)
                {
                    Console.Write(i==currentIndex?"-> ":"   ");
                    Console.WriteLine(options[i]);
                }
                System.ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        return -1;
                    case ConsoleKey.UpArrow:
                        if (currentIndex == 0)
                            currentIndex = options.Length - 1;
                        else currentIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentIndex == options.Length-1)
                            currentIndex = 0;
                        else currentIndex++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        return currentIndex;
                }
            }
        }
    }
}
