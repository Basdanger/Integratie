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

        public SubjectManager(DAL.EF.DashBoardDbContext dashboardDbContext)
        {
            repo = new SubjectRepo(dashboardDbContext);
        }
        
        public IEnumerable<Subject> GetSubjects()
        {
            return repo.ReadSubjects();
        }

        public Subject GetSubjectById(int id)
        {
            return repo.ReadSubjectById(id);
        }

        public Subject GetSubjectByName(string name)
        {
            return repo.ReadSubjectByName(name);
        }

        public IEnumerable<Person> GetPeopleByOrganisation(string orginasation)
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
        public IEnumerable<Person> GetOrganisaties()
        {
            return repo.GetOrganisaties();
        }
        public IEnumerable<Feed> GetFeeds(String person)
        {
            return repo.GetFeeds(person);
        }

        public IEnumerable<Subject> GetPeopleByTown(string town)
        {
            return repo.ReadPeopleByTown(town);
        }
    }
}
