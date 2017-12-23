using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestYield
{
    public class Person
    {
        public Person()
        {

        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {

            var person = "FristName:" + FirstName + "\n LastName:" + LastName + "\n Age:" + Age.ToString();
            return person;
        }
    }
}
