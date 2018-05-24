using Integratie.DAL.Repositories;
using Integratie.Domain.Entities;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{

    public class ThemeManager
    {
        private ThemeRepo repo;
        private SubjectRepo subjRepo;
        private FeedRepo feedRepo;

        public ThemeManager()
        {
            repo = new ThemeRepo();
            subjRepo = new SubjectRepo();
            feedRepo = new FeedRepo();
        }

        public IEnumerable<Theme> GetThemas()
        {
            return repo.ReadThemas();
        }

        public Theme GetThemeById(int id)
        {
            return repo.GetThema(id);
        }
        public Theme GetThemeByName(string name)
        {
            return repo.GetThemaByName(name);
        }

        public void AddTheme(Theme thema)
        {
            thema = UpdateTheme(thema);
            repo.addTheme(thema);
        }

        private Theme UpdateTheme(Theme thema)
        {
            thema = setTopFive(thema.TermsList, thema);
            thema.TermMentions = setTermMentions(thema.TermsList);

            return thema;
        }


        private List<TermMention> setTermMentions(List<string> termsList)
        {
            List<TermMention> termMentionList = new List<TermMention>();
            foreach (String t in termsList)
            {
                int counter = 0;
                TermMention termMention = null;
                foreach (Feed f in feedRepo.ReadFeeds())
                {
                    if (f.GetWords().Contains(t))
                    {
                        counter++;
                    }
                    termMention = new TermMention(t, counter);

                }
                termMentionList.Add(termMention);
            }
            return termMentionList;
        }

        public List<Story> GetStories(int themaId)
        {
            return repo.GetThema(themaId).Stories;
        }

        public void AddStory(Story story, int themaId)
        {
            repo.addStory(story);
            Theme thema = repo.GetThema(themaId);
            if (thema.Stories == null)
            {
                thema.Stories = new List<Story>();
            }
            thema.Stories.Add(story);

            repo.UpdateThema(thema);
        }

        public void DeleteTheme(int themaId)
        {
            List<Story> stories = repo.GetThema(themaId).Stories;
            List<TermMention> termMentions = repo.GetThema(themaId).TermMentions.ToList();
            foreach (Story story in stories) {
                DeleteStory(story.Id);
            }
            foreach (TermMention term in termMentions) {
                DeleteTermMention(term.Id);
            }
            repo.deleteTheme(themaId);
        }

        private void DeleteTermMention(int id)
        {
            repo.deleteTermMention(id);
        }

        public void DeleteStory(int storyId)
        {
            repo.deleteStory(storyId);
        }

        private Theme setTopFive(List<string> termsList, Theme thema)
        {
            string topPersons = "";
            string topOrganisations = "";
            Dictionary<Person, int> mapPerson = new Dictionary<Person, int>();
            Dictionary<string, int> mapOrg = new Dictionary<string, int>();
            IEnumerable<Person> personen = subjRepo.GetPersonen();
            foreach (Person p in personen)
            {
                int totalcounter = 0;
                IEnumerable<Feed> feeds = feedRepo.ReadPersonFeeds(p.Full_Name);
                foreach (Feed f in feeds)
                {
                    totalcounter = totalcounter + f.GetWords().Intersect(termsList).Count();
                }
                mapPerson.Add(p, totalcounter);
            }
            var myList = mapPerson.ToList();
            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            foreach (KeyValuePair<Person, int> p in myList)
            {
                if (mapOrg.ContainsKey(p.Key.Organisation))
                {
                    int count;
                    mapOrg.TryGetValue(p.Key.Organisation, out count);
                    mapOrg[p.Key.Organisation] = count + p.Value;
                }
                else
                {
                    mapOrg.Add(p.Key.Organisation, p.Value);

                }

            }
            var myList2 = mapOrg.ToList();
            myList2.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            for (int i = 0; i < 5; i++)
            {
                topPersons = topPersons + myList.ElementAt(i).Key.Full_Name + ',';
                topOrganisations = topOrganisations + myList2.ElementAt(i).Key + ',';
            }
            topPersons = topPersons.Remove(topPersons.Length - 1);
            topOrganisations = topOrganisations.Remove(topOrganisations.Length - 1);
            thema.TopPersons = topPersons;
            thema.TopOrganisations = topOrganisations;
            return thema;
        }
    }
}
