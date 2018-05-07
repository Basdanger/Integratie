using Integratie.DAL.EF;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories
{
    public class PersonRepo : IPersonRepo
    {
        private DashBoardDbContext context;

        public PersonRepo()
        {
            context = new DashBoardDbContext();
        }

        public bool CheckPersonExist(Person person)
        {
            return context.People.Any(p => p.ID == person.ID);
        }

        public void CreatePerson(Person person)
        {
            context.People.Add(person);
        }

        public IEnumerable<Person> ReadPeople()
        {
            IEnumerable<Person> people = context.People.ToList<Person>();
            return people;
        }

        public Person ReadPerson(double id)
        {
            return context.People.SingleOrDefault(p => p.ID == id);
        }
    }
}
