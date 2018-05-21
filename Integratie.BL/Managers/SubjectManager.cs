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
        private UnitOfWorkManager unitOfWorkManager;

        public SubjectManager()
        {
            repo = new SubjectRepo();
        }

        public SubjectManager(UnitOfWorkManager unitOfWorkManager)
        {
            this.unitOfWorkManager = unitOfWorkManager;
            repo = new SubjectRepo(unitOfWorkManager.UnitOfWork);
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

        public List<string> GetSubjectNames()
        {
            return repo.GetNames();
        }

        public IEnumerable<Person> GetPeopleByOrganisation(string orginasation)
        {
            return repo.ReadPeopleByOrganisation(orginasation);
        }
        public IEnumerable<Person> GetPersonen()
        {
            return repo.GetPersonen();
        }
        public Person GetPersoon(int id)
        {
            return repo.GetPersoon(id);
        }
        public IEnumerable<String> GetOrganisaties()
        {
            return repo.GetOrganisaties();
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

        public async Task WeeklyReview(DateTime now)
        {
            FeedManager feedManager = new FeedManager();
            List<Subject> subjects = repo.ReadSubjects().ToList();

            foreach(Subject subject in subjects)
            {
                if (subject.GetType().Equals(typeof(Person)))
                {
                    subject.FeedCount = feedManager.GetPersonFeedsSince(subject.Name,now.AddDays(-7)).Count();
                }
                else if (subject.GetType().Equals(typeof(Organisation)))
                {
                    subject.FeedCount = feedManager.GetOrganisationFeedsSince(subject.Name,now.AddDays(-7)).Count();
                }
                else
                {
                    subject.FeedCount = feedManager.GetWordFeedsSince(subject.Name,now.AddDays(-7)).Count();
                }
            }

            await repo.UpdateSubjects(subjects);
        }
        public IEnumerable<Person> GetPeopleByName(string name)
        {
            return repo.ReadPeopleByName(name);
        }
        public IEnumerable<String> GetOrganisaties(String organisatie)
        {
            return repo.GetOrganisaties(organisatie);
        }
        public IEnumerable<String> GetGemeentes(String gemeente)
        {
            return repo.GetGemeente(gemeente);
        }
        public IEnumerable<Feed> GetWordFeeds(string word)
        {
            return repo.ReadWordFeeds(word);
        }
        public IEnumerable<String> GetGemeentes()
        {
            return repo.GetGemeente();
        }
    }
}
