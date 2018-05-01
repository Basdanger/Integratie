﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.Domain;
using Integratie.Domain.Entities;
using Integratie.DAL.Repositories.Interfaces;

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
            return context.Feeds.Single(h => h.ID == id);
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
    }
}