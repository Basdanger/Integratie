using Integratie.DAL.EF;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories
{
    public class ThemeRepo
    {
        private DashBoardDbContext context;

        public ThemeRepo()
        {
            context = new DashBoardDbContext();
            context.Database.Initialize(false);
        }

        public ThemeRepo(DashBoardDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Theme> ReadThemas()
        {
            return context.Subjects.OfType<Theme>();
        }

        public void addTheme(Theme thema)
        {
            context.Subjects.Add(thema);
            context.SaveChanges();
        }

        public void addStory(Story story)
        {
            context.Stories.Add(story);
            context.SaveChanges();
        }

        public Theme GetThema(int id)
        {
            return context.Subjects.OfType<Theme>().First(t => t.ID.Equals(id));
        }
        public Theme GetThemaByName(string name)
        {
            return context.Subjects.OfType<Theme>().First(t => t.Name == name);
        }

        public void UpdateThema(Theme thema)
        {
            context.Entry(thema).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void deleteStory(int storyId)
        {
            Story story = context.Stories.Find(storyId);
            context.Stories.Remove(story);
            context.SaveChanges();
        }

        public void deleteTermMention(int termMentionId) {
            TermMention termMention = context.TermMentions.Find(termMentionId);
            context.TermMentions.Remove(termMention);
            context.SaveChanges();
        }

        public void deleteTheme(int themaId)
        {
            Theme t = (Theme)context.Subjects.Find(themaId);
            context.Subjects.Remove(t);
            context.SaveChanges();
        }
    }
}
