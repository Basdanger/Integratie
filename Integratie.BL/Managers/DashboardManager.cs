using Integratie.DAL;
using Integratie.Domain.Entities.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{
    public class DashboardManager
    {
        DashboardRepo repo = new DashboardRepo();
        public List<DashboardItem> GetAllDashboardItems()
        {
            return repo.GetAllDashboardItems();
        }
    }
}
