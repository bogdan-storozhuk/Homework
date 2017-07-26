using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class User:ICloneable
    {
        private readonly string _username;
        private readonly string _password;
        public string _email;

        public User(string username, string password, string email)
        {
            _username = username;
            _password = password;
            _email = email;
        }

        public void PrintInfo()
        {
            Console.WriteLine(_username);
            Console.WriteLine(_password);
            Console.WriteLine(_email);
        }

        public object Clone()
        {
            return new User(this._username, this._password, this._email);
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Value Type:");
            Console.WriteLine("VARIABLE1 INFO:");
            var variable1 = 1;
            Console.WriteLine(variable1);
            Console.WriteLine("VARIABLE2 INFO:");
            var variable2 = variable1;
            Console.WriteLine(variable2);
            Console.WriteLine("Reference Type:");
            Console.WriteLine("USER1 INFO:");
            var user1= new User("username1","password1","email1");
            user1.PrintInfo();
            Console.WriteLine("User1 hashcode:{0}",user1.GetHashCode());
            Console.WriteLine("USER2 INFO:");
            var user2 = user1;
            user2.PrintInfo();
            Console.WriteLine("User2 hashcode:{0}", user2.GetHashCode());
            var user3 = (User) user2.Clone();
            Console.WriteLine("User3 hashcode:{0}", user3.GetHashCode());
            user3._email = "fdsf";
            user3.PrintInfo();
            user2.PrintInfo();
            Console.ReadKey();
        }
    }
}
