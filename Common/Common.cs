using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Diginote
    {
        private long serialNumber { get; }
        private int facialValue { get; set; }

        public Diginote(long serial)
        {
            facialValue = 1;
            serialNumber = serial;
        }
    }

    /**
     * Nickname should be unique
     **/
    [Serializable]
    public class User
    {
        private string name;
        private string nickname;
        private string password;
        private bool isLoggedIn;
        public string Name
        {
            get => name;
        }
        public string Nickname
        {
            get => nickname;
        }
        public string Password
        {
            get => password;
        }

        public bool IsLoggedIn
        {
            get => isLoggedIn;
            set => isLoggedIn = value;
        }
        public User(string name, string nickname, string password)
        {
            this.name = name;
            this.nickname = nickname;
            this.password = password;
            this.isLoggedIn = false;
        }

        public override bool Equals(object obj)
        {
            User item = obj as User;

            if (item == null)
                return false;

            if (this.nickname.Equals(item.nickname) || 
                this.name.ToLower().Equals(item.name.ToLower()))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return nickname.GetHashCode();
        }

        public override string ToString()
        {
            return "[" + name + "|" + nickname + "|" + isLoggedIn.ToString() + "]";
        }
    }

    public class Utils
    {
        public static string GetSha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }
}
