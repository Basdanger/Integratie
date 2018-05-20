using System;
using System.Collections.Generic;
using System.IO;
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

        public List<string> GetSubjectNames()
        {
            return repo.GetNames();
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
        public Person GetPersoon(int ID)
        {
            return repo.GetPersoon(ID);
        }
        public IEnumerable<String> GetOrganisaties()
        {
            return repo.GetOrganisaties();
        }
        public IEnumerable<String> GetOrganisaties(String organisatie)
        {
            return repo.GetOrganisaties(organisatie);
        }
        public IEnumerable<String> GetGemeentes()
        {
            return repo.GetGemeente();
        }
        public IEnumerable<String> GetGemeentes(String gemeente)
        {
            return repo.GetGemeente(gemeente);
        }
        public IEnumerable<Subject> GetPeopleByTown(string town)
        {
            return repo.ReadPeopleByTown(town);
        }
        public void ChangePerson(Person person)
        {
            repo.UpdatePersoon(person);
        }
        public void DeletePerson(int id)
        {
            repo.DeletePersoon(id);
        }
        public Person AddPerson(String First_Name, String Last_Name, String District, String Level, String Gender, String Twitter, String Site, DateTime DateOfBirth, String Facebook, String Postal_Code, String Full_Name, String Position, String Organisation, String Town)
        {
            Person person = new Person()
            {
                First_Name = First_Name,
                Last_Name = Last_Name,
                District = District,
                Level = Level,
                Gender = Gender,
                Twitter = Twitter,
                Site = Site,
                DateOfBirth = DateOfBirth,
                Facebook = Facebook,
                Postal_Code = Postal_Code,
                Full_Name = Full_Name,
                Position = Position,
                Organisation = Organisation,
                Town = Town
            };
            repo.CreatePersoon(person);
            return person;
        }
        public void CreatePersons(List<Person> persons)
        {
            repo.CreatePersonen(persons);
        }
        public IEnumerable<Person> GetPeopleByName(string name)
        {
            return repo.ReadPeopleByName(name);
        }
    }
}
