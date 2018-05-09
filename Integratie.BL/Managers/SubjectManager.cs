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
    public class SubjectManager : ISubjectManager
    {
        private ISubjectRepo repo;

        public SubjectManager()
        {
            repo = new SubjectRepo();
        }

        public Subject GetSubject(double id)
        {
            return repo.GetSubjectById(id);
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return repo.GetSubjects();
        }


    }
}
