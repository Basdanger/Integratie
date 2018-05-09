using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers.Interfaces
{
    public interface IPersonManager
    {
        IEnumerable<Person> GetPeople();
        Person GetPerson(double id);
        void MakePerson(Person person);
        bool CheckPerson(Person person);
    }
}
