using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.Domain;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.DAL
{
    public class DummySubjectRepo : ISubjectRepo
    {
        DashBoardDbContext context = new DashBoardDbContext();
        List<Subject> subjects = new List<Subject>();
        public Subject AddSubject(Subject subject)
        {
            subjects.Add(subject);
            return subjects.Last();
        }

        public IEnumerable<Person> GetPersons()
        {
            return context.People.ToList();
        }

        public Subject GetSubjectById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubject(Subject subject)
        {
            subjects.Remove(subject);
        }

        void ISubjectRepo.AddSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Subject> ISubjectRepo.GetSubjects()
        {
            return context.Subjects.ToList();
        }
    }
}
