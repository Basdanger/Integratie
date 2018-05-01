using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain;
using Integratie.Domain.Entities.Subjects;
using Integratie.DAL.Repositories.Interfaces;

namespace Integratie.DAL.Repositories
{
    public class DummySubjectRepo : ISubjectRepo
    {
        List<Subject> subjects = new List<Subject>();
        public void AddSubject(Subject subject)
        {
            subjects.Add(subject);
        }

        public Subject GetSubjectById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetSubjects()
        {
            return subjects;
        }

        public void RemoveSubject(Subject subject)
        {
            subjects.Remove(subject);
        }
    }
}
