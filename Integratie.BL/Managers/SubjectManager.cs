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
    public class SubjectManager
    {
        private ISubjectRepo repo = new DummySubjectRepo();
        public IEnumerable<Subject> GetSubjects()
        {
            return repo.GetSubjects();
        }
    }
}
