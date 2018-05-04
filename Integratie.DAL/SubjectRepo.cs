using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.DAL
{
    public class SubjectRepo : ISubjectRepo
    {
        DashBoardDbContext context = new DashBoardDbContext();

        public void AddSubject(Subject subject)
        {
            context.Subjects.Add(subject);
            context.SaveChanges();
        }

        public Subject GetSubjectById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return context.Subjects.ToList();
        }

        public void RemoveSubject(Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
