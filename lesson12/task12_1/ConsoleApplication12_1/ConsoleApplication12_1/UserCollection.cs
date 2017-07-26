using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12_1
{
    class UserCollection 
    {
        IUser[] users = new User[0];


        public void Add(IUser user)
        {
            IUser[] tempArray = new User[users.Length + 1];
            tempArray[0] = user;
            for (var j = 0; j < users.Length; j++)
            {
                tempArray[j + 1] = users[j];
            }
            users = tempArray;
        }

        public int GetLenght()
        {
            return users.Length;
        }

        public IUser this[int index]
        {
            get { return users[index]; }
        }

        public bool GetUser(IUser user)
        {
            for (var i = 0; i < users.Length; i++)
            {
                if (users[i].Name == user.Name && users[i].Email == user.Email &&
                    users[i].Password==user.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
