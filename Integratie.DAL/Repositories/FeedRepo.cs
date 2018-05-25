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
using System.Data.Entity;

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

        public async Task CreateFeeds(List<Feed> feeds)
        {
            context.Feeds.AddRange(feeds);
            await context.SaveChangesAsync();
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

        public async Task<List<Feed>> ReadPersonFeedsSinceAsync(string person, DateTime date)
        {
            return await context.Feeds.Where(f => f.Persons.ToUpper().Contains(person.ToUpper()) && f.Date.CompareTo(date) >= 0).ToListAsync();
        }

        public IEnumerable<Feed> ReadWordFeedsSince(string word, DateTime date)
        {
            return context.Feeds.Where(f => f.Words.ToUpper().Contains(word.ToUpper()) && f.Date.CompareTo(date) >= 0).ToList<Feed>();
        }

        public async Task<List<Feed>> ReadWordFeedsSinceAsync(string word, DateTime date)
        {
            return await context.Feeds.Where(f => f.Words.ToUpper().Contains(word.ToUpper()) && f.Date.CompareTo(date) >= 0).ToListAsync();
        }

        public IEnumerable<Feed> ReadPersonFeedsGender(string person, Gender gender)
        {
            return context.Feeds.Where(f => f.Persons.ToUpper().Contains(person.ToUpper()) && f.Profile.Gender.Equals(gender)).ToList<Feed>();
        }

        public IEnumerable<Feed> ReadFilteredFeed(DateTime StartDate, DateTime Enddate, List<String> AgeFilter, List<String> PersonalityFilter, List<String> GenderFilter, List<String> PersonFilter, double StartSentiment, double EndSentiment, List<String> ThemeWords)
        {

            IEnumerable<Feed> feeds;
            feeds = context.Feeds
            .Where(f => f.Date <= Enddate && f.Date >= StartDate)
            .Where(f => AgeFilter.Any(AF => AF == f.Profile.Age))
            .Where(f => PersonalityFilter.Any(PF => PF == f.Profile.Personality))
            .Where(f => GenderFilter.Any(t => t == f.Profile.Gender.ToString()));

            if(ThemeWords !=null && ThemeWords.Count > 0)
            feeds = feeds.Where(f => ThemeWords.Any(t=> f.Words.Contains(t.ToLower())));

            if (StartSentiment != -1 || EndSentiment != 1)
                feeds = feeds.Where(delegate (Feed f) {
                    if (f.SentimentMean() == -2) return false;
                double x = f.SentimentMean();
                return  x <= EndSentiment && x >= StartSentiment;
            });

            if (PersonFilter.First() != "")
                feeds = feeds.Where(f => PersonFilter.Any(t => f.Persons.Contains(t)));

                return feeds;
        }

        public IEnumerable<int> getLocatieFeeds()
        {
            if(context.Feeds.Select(f => f.Geo) == null)
            {
                return null;
            }
            else
            {
                return context.Feeds.Select(f => Convert.ToInt32(f.Geo));
            }
        }
    }
}
