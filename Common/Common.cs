using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public class Diginote
    {
        private double serialNumber { get; }
        private int facialValue { get; set; }

        public Diginote(double serial)
        {
            facialValue = 1;
            serialNumber = serial;
        }
    }

    /**
     * Nickname should be unique
     **/
    public class User
    {
        private string name { get; }
        private string nickname { get; }
        private string password { get; }

        public User(string name, string nickname, string password)
        {
            this.name = name;
            this.nickname = nickname;
            this.password = password;
        }

        public override bool Equals(object obj)
        {
            User item = obj as User;

            if (item == null)
                return false;

            if (this.nickname.Equals(item.nickname))
                return true;
            else
                return false;
        }
    }
}
