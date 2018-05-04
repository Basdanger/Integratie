using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.DAL.Repositories
{
    public class SubjectRepo : ISubjectRepo
    {
        private DashBoardDbContext context;

        public SubjectRepo()
        {
            context = new DashBoardDbContext();
        }

        public void AddSubject(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }

        public IEnumerable<Person> GetPersons()
        {
            return context.People.ToList();
        }

        public Subject GetSubjectById(int id)
        {
            return context.Subjects.Find(id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects.ToList<Subject>();
        }

        public void RemoveSubject(Subject subject)
        {
            context.Subjects.Remove(subject);
        }
    }
}
