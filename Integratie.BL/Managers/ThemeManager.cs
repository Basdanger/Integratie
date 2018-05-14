using Integratie.DAL.Repositories;
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

        public ThemeManager()
        {
            repo = new ThemeRepo();
        }

        public IEnumerable<Theme> GetThemas()
        {
            return repo.ReadThemas();
        }

        public Theme GetThemeById(int id)
        {
            return repo.GetThema(id);
        }
    }
}
