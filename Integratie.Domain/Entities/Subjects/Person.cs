using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Subjects
{
    public class Person : Subject
    {
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public String District { get; set; }
        public String Level { get; set; }
        public String Gender { get; set; }
        public String Twitter { get; set; }
        public String Site { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Facebook { get; set; }
        public String Postal_Code { get; set; }
        public String Full_Name { get; set; }
        public String Position { get; set; }
        public String Organisation { get; set; }
        public String ID { get; set; }
        public String Town { get; set; }

        public Person(String first_Name, String last_Name, String district,
                      String level, String gender, String twitter, String site,
                      DateTime dateOfBirth, String facebook, String postal_Code,
                      String full_Name, String position, String organisation,
                      String id, String town) : base(id, full_Name)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            District = district;
            Level = level;
            Gender = gender;
            Twitter = twitter;
            Site = site;
            DateOfBirth = dateOfBirth;
            Facebook = facebook;
            Postal_Code = postal_Code;
            Full_Name = full_Name;
            Position = position;
            Organisation = organisation;
            ID = id;
            Town = town;
        }
    }
}
