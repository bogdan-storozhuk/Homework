using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace ConsoleApplication1
{
    class Human
    {
        private int age;
        private DateTime birthDate;
        private string firstName;
        private string lastName;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public Human(int age, DateTime birthDate, string firstName, string lastName)
        {
            this.age = age;
            BirthDate = birthDate;
            FirstName = firstName;
            LastName = lastName;
        }

        public Human(DateTime birthDate, string firstName, string lastName)
        {
            BirthDate = birthDate;
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            return obj != null && this.GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return age.GetHashCode() ^ birthDate.GetHashCode() ^ firstName.GetHashCode() ^ lastName.GetHashCode();
        }

        public static bool Equal(Human human1, Human human2)
        {
            return human1.Equals(human2);
        }
    }

}
    class Program
    {
        static void Main(string[] args)
        {
            var firstHuman= new Human(new DateTime(2013,02,02), "Name1","LastName1");
            var secondHuman= new Human(28,new DateTime(2013,02,02), "Name2","LastName2");
            var thirdHuman= new Human(new DateTime(2013,02,02), "Name1","LastName1");

            var fourthHuman = new Human(new DateTime(2013, 02, 02), "Name1", "LastName1");
            Console.WriteLine(firstHuman.Age);

           Console.WriteLine(Human.Equal(firstHuman,fourthHuman));
            Console.ReadKey();
        }
    }


