using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12_1
{
    class User:IUser
    {
        public string Email { get; set; }
        public string Name { get; set; }            
        public string Password { get; set; }
        public DateTime Time { get; set; }

        public User(string email, string name, string password)
        {
            Email = email;
            Name = name;
            Password = password;
            Time = DateTime.Now;
        }

        public string GetFullInfo()
        {
            return string.Format("Name:{0},Password:{1},Email:{2}", Name, Password, Email);
        }
    }
}
