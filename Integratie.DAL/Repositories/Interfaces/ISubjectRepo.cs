using Integratie.Domain;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL
{
    public interface ISubjectRepo
    {
        List<Subject> GetSubjects();
        Subject AddSubject(Subject subject);
        void RemoveSubject(Subject subject);
        Subject GetSubjectById(int id);
    }
}
