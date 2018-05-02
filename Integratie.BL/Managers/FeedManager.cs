using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL;
using Integratie.Domain;
using Integratie.BL.Managers.Interfaces;
using Integratie.Domain.Entities;
using Integratie.DAL.Repositories;
using Integratie.DAL.Repositories.Interfaces;

namespace Integratie.BL.Managers
{
    public class FeedManager : IFeedManager
    {
        private FeedRepo repo;

        public FeedManager()
        {
            repo = new FeedRepo();
        }
        public IEnumerable<Feed> GetFeeds()
        {
            return repo.ReadFeeds();
        }

        public Feed GetFeed(double id)
        {
            return repo.ReadFeed(id);
        }

        public IEnumerable<Feed> GetPersonFeeds(string person)
        {
            return repo.ReadPersonFeeds(person);
        }

        public IEnumerable<Feed> GetWordFeed(string word)
        {
            return repo.ReadWordFeeds(word);
        }

        public IEnumerable<Feed> GetFeedSince(DateTime date)
        {
            return repo.ReadFeedsSince(date);
        }

        public IEnumerable<Feed> GetOrganisationFeeds(string orginasation)
        {
            IEnumerable<Feed> feeds = new List<Feed>();
            SubjectManager subjectManager = new SubjectManager();
            subjectManager.GetPeopleByOrganisation(orginasation).ToList().ForEach(s => feeds.Union(repo.ReadPersonFeeds(s.Name)));
            return feeds;
        }
    }
}
