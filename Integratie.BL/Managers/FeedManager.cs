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
using Integratie.Domain.Entities.Graph;

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

        public IEnumerable<Feed> GetWordFeeds(string word)
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

        public IEnumerable<Feed> GetPersonFeedsSince(string person, DateTime date)
        {
            return repo.ReadPersonFeedsSince(person,date);
        }

        public IEnumerable<Feed> GetWordFeedsSince(string word, DateTime date)
        {
            return repo.ReadWordFeedsSince(word,date);
        }

        public IEnumerable<Feed> GetOrganisationFeedsSince(string orginasation, DateTime date)
        {
            IEnumerable<Feed> feeds = new List<Feed>();
            SubjectManager subjectManager = new SubjectManager();
            subjectManager.GetPeopleByOrganisation(orginasation).ToList().ForEach(s => feeds.Union(repo.ReadPersonFeedsSince(s.Name,date)));
            return feeds;
        }

        public IEnumerable<Feed> GetPersonFeedsGender(string person,Gender gender)
        {
            return repo.ReadPersonFeedsGender(person, gender);
        }

        public IEnumerable<Feed> GetFilteredFeeds(Graph graph)
        {
            List<String> Agefilter = new List<string>();
            List<String> Personalityfilter = new List<string>();
            List<String> Genderfilter = new List<string>();
            if(graph.AgeFilter == AgeFilter.Both)
            {
                Agefilter.Add("");
                Agefilter.Add("25+");
                Agefilter.Add("25-");
            }
            if(graph.AgeFilter == AgeFilter.min25)
            {
                Agefilter.Add("25-");
            }
            if (graph.AgeFilter == AgeFilter.plus25)
            {
                Agefilter.Add("25+");
            }

            if(graph.PersonalityFilter == PersonalityFilter.Both)
            {
                Personalityfilter.Add("");
                Personalityfilter.Add("I");
                Personalityfilter.Add("E");
            }
            if (graph.PersonalityFilter == PersonalityFilter.I)
            {
                Personalityfilter.Add("I");
            }
            if (graph.PersonalityFilter == PersonalityFilter.E)
            {
                Personalityfilter.Add("E");
            }

            if (graph.GenderFilter == GenderFilter.Both)
            {
                Genderfilter.Add("f");
                Genderfilter.Add("m");
                Genderfilter.Add("");
            }
            if (graph.GenderFilter == GenderFilter.Male)
            {
                Genderfilter.Add("m");
            }
            if (graph.GenderFilter == GenderFilter.Female)
            {
                Genderfilter.Add("f");
            }
            if (graph.PersonFilter == null) graph.PersonFilter = "";

            if (graph.PeriodSort == PeriodSort.Flex)
            {
                graph.EndDate = DateTime.Now;
                graph.StartDate = graph.EndDate.AddDays(graph.PeriodLength * -1);
            }
            IEnumerable<Feed> filteredList = repo.ReadFilteredFeed(graph.StartDate, graph.EndDate, Agefilter, Personalityfilter, Genderfilter, graph.PersonFilter.Split(',').Select(s=>s.Trim()).ToList());
            return filteredList;
        }
        public IEnumerable<int> getFeedLocaties()
        {
            return repo.getLocatieFeeds();
        }
    }
}
 