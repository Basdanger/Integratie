using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain
{
    public class Person : Subject
    {
        public String gemeente { get; set; }
        public DateTime Geboortedatum { get; set; }
        public String URL { get; set; }

        public Person(int iD, string name) : base(iD, name)
        {
            
        }
    }
}
