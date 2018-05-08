using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;
using System.Data.Entity;
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

        public Subject ReadSubjectById(string id)
        {
            return context.Subjects.Find(id);
        }

        public IEnumerable<Subject> ReadSubjects()
        {
            return context.Subjects.ToList<Subject>();
        }

        public void RemoveSubject(Subject subject)
        {
            context.Subjects.Remove(subject);
        }

        public IEnumerable<Subject> ReadSubjectByName(string name)
        {
            return context.Subjects.Where(s => s.Name.ToUpper().Equals(name.ToUpper())).ToList<Subject>();
        }

        public IEnumerable<Subject> ReadPeopleByOrganisation(string organisation)
        {
            return context.Subjects.OfType<Person>().Where(p => p.Organisation.ToUpper().Equals(organisation.ToUpper())).ToList<Subject>();
        }

        public IEnumerable<Subject> ReadPeopleByTown(string town)
        {
            return context.Subjects.OfType<Person>().Where(p => p.Town.Equals(town.ToUpper()));
        }

        public IEnumerable<Person> GetPersonen()
        {
            return context.People.ToList();
        }
        public Person GetPersoon(String Full_Name)
        {
            //bevat soms geen elementen soms wel gewoon nog eens proberen
            return context.People.Include(p => p.Feeds).First(p => p.Full_Name.ToUpper().Equals(Full_Name));

            //return context.Subjects.OfType<Person>().Where(p => p.Full_Name.ToUpper().Equals(Full_Name.ToUpper())).First();
        }
        public IEnumerable<String> GetOrganisaties()
        {
            //return context.People.ToList();
            //return context.People.SqlQuery("SELECT DISTINCT * FROM dbo.Subject").ToList();
            return context.People.Select(o => o.Organisation).Distinct();
        }
        public Person FeedsByPerson(String Full_Name)
        {
            //return context.People.Where(p => p.Feeds.First(f => f.Persons.ToUpper().Equals(Full_Name)));
            return context.People.Include(p => p.Feeds).First(p => p.Full_Name.ToUpper().Equals(Full_Name));
        }
        public IEnumerable<Feed> GetFeeds(String person)
        {
            return context.Feeds.Where(f => f.Persons.ToUpper().Equals(person));
        }
    }
}
