using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new Validator();
            var userCollection = new UserCollection();
            while (true)
            {
                var userIsExist = false;
                Console.WriteLine("Enter UserName:");
                var name = Console.ReadLine();
                Console.WriteLine("Enter Password:");
                var password = Console.ReadLine();
                Console.WriteLine("Enter Email:");
                var email = Console.ReadLine();
                if (name == "exit" && password == "exit" && email == "exit")
                {
                    break;
                }
                IUser userTemp = new User(email,name,password);
                    for (int i = 0; i < userCollection.GetLenght(); i++)
                    {
                        if (userCollection[i].Name == name)
                        {
                            userIsExist = true;
                            if (validator.AuthenticationSuccess(userTemp))
                            {
                                Console.WriteLine("Last time was logged in:{0}",userCollection[i].Time);
                                userCollection[i].Time=DateTime.Now;
                                break;
                            }
                        }
                    }
                if (!userIsExist)
                {
                    Console.WriteLine("User has been added.");
                    userCollection.Add(userTemp);
                }
            }
        }
    }
}
