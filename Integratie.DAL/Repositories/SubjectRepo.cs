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
using System.Data.Entity.Validation;
using System.Diagnostics;

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

        public IEnumerable<Theme> ReadThemas()
        {
            return context.Subjects.OfType<Theme>();
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

        public Theme GetThema(int id)
        {
            return context.Subjects.OfType<Theme>().First(t=> t.ID.Equals(id));
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
        public IEnumerable<Organisation> GetOrganisaties()
        {
            return context.Organisations.ToList();
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
