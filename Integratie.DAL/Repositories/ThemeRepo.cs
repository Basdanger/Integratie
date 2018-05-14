using Integratie.DAL.EF;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
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

        public Theme GetThema(int id)
        {
            return context.Subjects.OfType<Theme>().First(t => t.ID.Equals(id));
        }

    }
}
