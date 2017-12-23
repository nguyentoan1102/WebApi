using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYield
{
    class Program
    {
        static void Main(string[] args)
        {//Populate using Add() method
            Dictionary<string, Person> peopleA = new Dictionary<string, Person>();

            peopleA.Add("Homer", new Person
            {
                FirstName = "Homer",
                LastName = "Simpson",
                Age = 47
            });
            peopleA.Add("Marge", new Person
            {
                FirstName = "Marge",
                LastName = "Simpson",
                Age = 45
            });
            peopleA.Add("Lisa", new Person
            {
                FirstName = "Lisa",
                LastName = "Simpson",
                Age = 9
            });
            Person homer = peopleA["Homer"];
            Console.WriteLine(homer.ToString());
            Console.ReadLine();

        }
    }
}
