using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.Repositories;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.BL.Managers
{
    public class SubjectManager
    {
        private SubjectRepo repo;

        public SubjectManager()
        {
            repo = new SubjectRepo();
        }

        public IEnumerable<Subject> GetSubjects()
        {
            return repo.ReadSubjects();
        }

        public Subject GetSubjectById(string id)
        {
            return repo.ReadSubjectById(id);
        }

        public IEnumerable<Subject> GetPeopleByOrganisation(string orginasation)
        {
            return repo.ReadPeopleByOrganisation(orginasation);
        }
        public IEnumerable<Person> GetPersonen()
        {
            return repo.GetPersonen();
        }
        public Person GetPersoon(String Full_Name)
        {
            return repo.GetPersoon(Full_Name);
        }
        public IEnumerable<Organisation> GetOrganisaties()
        {
            return repo.GetOrganisaties();
        }
        public IEnumerable<Feed> GetFeeds(String person)
        {
            return repo.GetFeeds(person);
        }
    }
}
