using Integratie.BL.Managers.Interfaces;
using Integratie.DAL.Repositories;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{
    public class PersonManager : IPersonManager
    {
        private IPersonRepo repo;

        public PersonManager()
        {
            repo = new PersonRepo();
        }
        public IEnumerable<Person> GetPeople()
        {
            return repo.ReadPeople();
        }

        public Person GetPerson(double id)
        {
            return repo.ReadPerson(id);
        }

        public void MakePerson(Person person)
        {
            repo.CreatePerson(person);
        }

        public bool CheckPerson(Person person)
        {
            return repo.CheckPersonExist(person);
        }
    }
}
