using Integratie.Domain;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories.Interfaces
{
    public interface ISubjectRepo
    {
        IEnumerable<Subject> ReadSubjects();
        void AddSubject(Subject subject);
        void RemoveSubject(Subject subject);
        Subject ReadSubjectById(int id);
    }
}
