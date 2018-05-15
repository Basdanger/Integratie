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

        public ThemeManager()
        {
            repo = new ThemeRepo();
            subjRepo = new SubjectRepo();
        }

        public IEnumerable<Theme> GetThemas()
        {
            return repo.ReadThemas();
        }

        public Theme GetThemeById(int id)
        {
            return repo.GetThema(id);
        }

        public void AddTheme(Theme thema)
        {
            thema = UpdateTheme(thema);
            repo.addTheme(thema);
        }

        private Theme UpdateTheme(Theme thema)
        {
            thema.TopPersons = setTopPersons(thema.TermsList);

            return thema;
        }
        
        private string setTopPersons(List<string> termsList)
        {
            string topPersons="";
            Dictionary<Person, int> map = new Dictionary<Person, int>();
            IEnumerable<Person> personen = subjRepo.GetPersonen();
            foreach(Person p in personen) {
                int totalcounter = 0;
                IEnumerable<Feed> feeds= subjRepo.GetFeeds(p.Full_Name);
                foreach (Feed f in feeds) {
                    totalcounter = totalcounter + f.GetWords().Intersect(termsList).Count();
                }
                System.Diagnostics.Debug.WriteLine("Persoon: "+p.Full_Name+" Relevantie: " + totalcounter);
                map.Add(p, totalcounter);
            }
            var myList = map.ToList();
            myList.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));
            for(int i=0;i<5;i++)
            {
                topPersons = topPersons + myList.ElementAt(i).Key.Full_Name+',';
            }
            topPersons = topPersons.Remove(topPersons.Length - 1);

            return topPersons;
        }
    }
}
