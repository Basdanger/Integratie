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

        public async Task<List<Person>> GetPeopleByOrganisationAsync(string orginasation)
        {
            return await repo.ReadPeopleByOrganisationAsync(orginasation);
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
            List<Subject> subjects = await repo.ReadSubjectsAsync();

            foreach(Subject subject in subjects)
            {
                int days = 6;
                int fcToday = 0;
                int fcHistory = 0;
                float avarage = 0;
                double std = 0;
                double zScore = 0;
                
                List<Feed> feeds;

                DateTime end = now;
                DateTime start = end.AddDays(-7);
                List<double> values = new List<double>();

                if (subject.GetType().Equals(typeof(Person)))
                {
                    feeds = await feedManager.GetPersonFeedsSinceAsync(subject.Name, now.AddDays(-7));
                    subject.FeedCount = feeds.Count();
                }
                else if (subject.GetType().Equals(typeof(Organisation)))
                {
                    feeds = await feedManager.GetOrganisationFeedsSinceAsync(subject.Name, now.AddDays(-7));
                    subject.FeedCount = feeds.Count();
                }
                else
                {
                    feeds = await feedManager.GetWordFeedsSinceAsync(subject.Name, now.AddDays(-7));
                    subject.FeedCount = feeds.Count();
                }

                foreach (Feed f in feeds)
                {
                    if (f.Date.Ticks >= end.AddDays(-1).Ticks)
                    {
                        fcToday++;
                    }
                }

                for (int i = 6; i > 0; i--)
                {
                    foreach (Feed f in feeds)
                    {
                        if (start.AddDays(6 - i).Ticks <= f.Date.Ticks && f.Date.Ticks < end.AddDays(-i).Ticks)
                        {
                            fcHistory++;
                        }
                    }
                    avarage += fcHistory;
                    values.Add(fcHistory);
                    fcHistory = 0;
                }

                avarage = (float)avarage / days;

                foreach (float item in values)
                {
                    std += Math.Pow(item - avarage, 2);
                }

                std = Math.Sqrt(std / days);

                zScore = ((float)fcToday - avarage) / std;

                if (zScore > 2)
                {
                    subject.Trending = true;
                }
                else subject.Trending = false;
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
