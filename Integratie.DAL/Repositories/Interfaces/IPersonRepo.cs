using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories.Interfaces
{
    public interface IPersonRepo
    {
        IEnumerable<Person> ReadPeople();
        Person ReadPerson(double id);
        void CreatePerson(Person person);
        bool CheckPersonExist(Person person);
    }
}
