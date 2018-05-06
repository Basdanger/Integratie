using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;

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
        public IEnumerable<Person> GetPersonen()
        {
            return context.People.ToList();
        }
        public Person GetPersoon(String Full_Name)
        {
            //bevat soms geen elementen soms wel gewoon nog eens proberen
            return context.Subjects.OfType<Person>().Where(p => p.Full_Name.ToUpper().Equals(Full_Name.ToUpper())).First();
        }
        public IEnumerable<Organisation> GetOrganisaties()
        {
            return context.Organisations.ToList();
        }
        public IEnumerable<Feed> FeedsByPerson(String Full_Name)
        {
            return context.Feeds.Where(f => f.Persons.ToUpper().Equals(Full_Name.ToUpper())).ToList();
        }
    }
}
