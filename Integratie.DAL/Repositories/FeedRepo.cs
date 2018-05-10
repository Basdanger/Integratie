using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.DAL.Repositories
{
    public class FeedRepo : IFeedRepo
    {
        private DashBoardDbContext context;

        public FeedRepo()
        {
            context = new DashBoardDbContext(); 
        }

        public IEnumerable<Feed> ReadFeeds()
        {
            IEnumerable<Feed> feeds = context.Feeds.ToList<Feed>();
            return feeds;
        }

        public void CreateFeed(Feed feed)
        {
            context.Feeds.Add(feed);
            context.SaveChanges();
        }

        public Feed ReadFeed(double id)
        {
            return context.Feeds.Find(id);
        }

        public IEnumerable<Feed> ReadPersonFeeds(string person)
        {
            return context.Feeds.Where(f => f.Persons.ToUpper().Contains(person.ToUpper())).ToList<Feed>();
        }

        public IEnumerable<Feed> ReadWordFeeds(string word)
        {
            return context.Feeds.Where(f => f.Words.ToUpper().Contains(word.ToUpper())).ToList<Feed>();
        }

        public IEnumerable<Feed> ReadFeedsSince(DateTime date)
        {
            return context.Feeds.Where(f => f.Date.CompareTo(date) >= 0).ToList<Feed>();
        }

        public IEnumerable<Feed> ReadPersonFeedsSince(string person, DateTime date)
        {
            return context.Feeds.Where(f => f.Persons.ToUpper().Contains(person.ToUpper()) && f.Date.CompareTo(date) >= 0).ToList<Feed>();
        }

        public IEnumerable<Feed> ReadWordFeedsSince(string word, DateTime date)
        {
            return context.Feeds.Where(f => f.Words.ToUpper().Contains(word.ToUpper()) && f.Date.CompareTo(date) >= 0).ToList<Feed>();
        }

        public IEnumerable<Feed> ReadPersonFeedsGender(string person, Gender gender)
        {
            return context.Feeds.Where(f => f.Persons.ToUpper().Contains(person.ToUpper()) && f.Profile.Gender.Equals(gender)).ToList<Feed>();
        }

        public IEnumerable<Feed> ReadFilteredFeed( DateTime StartDate, DateTime Enddate, List<String> AgeFilter, List<String> PersonalityFilter, List<String> GenderFilter, List<String> PersonFilter)
        {
            IEnumerable<Feed> feeds;
            if (PersonFilter.Count > 0)
                feeds = context.Feeds
                .Where(f => f.Date <= Enddate && f.Date >= StartDate)
                .Where(f => AgeFilter.Any(AF => AF == f.Profile.Age))
                .Where(f => PersonalityFilter.Any(PF => PF == f.Profile.Personality))
                .Where(f => PersonFilter.Any(t => f.Persons.Contains(t)));
            else
            {
                feeds =
                context.Feeds
                .Where(f => f.Date <= Enddate && f.Date >= StartDate).ToList()
                .Where(f => AgeFilter.Any(AF => AF == f.Profile.Age))
                .Where(f => PersonalityFilter.Any(PF => PF == f.Profile.Personality));

            }
            return feeds;
        }
    }
}
