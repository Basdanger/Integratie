using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Person
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String District { get; set; }
        public String Level { get; set; }
        public Gender Gender { get; set; }
        public String Twitter { get; set; }
        public String Site { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Facebook { get; set; }
        public String PostalCode { get; set; }
        public String FullName { get; set; }
        public String Position { get; set; }
        public String Organisation { get; set; }
        public String Id { get; set; }
        public String Town { get; set; }

        public Person(int iD, string name)
        {
            
        }

        public Person(String firstName, String lastName, String district, 
                      String level, Gender gender, String twitter, String site,
                      DateTime dateOfBirth, String facebook, String postalCode,
                      String fullName, String position, String organisation,
                      String id, String town)
        {

        }
    }
}
