using Integratie.DAL.EF;
using Integratie.Domain.Entities.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories
{
    public class DashboardRepo
    {
        DashBoardDbContext context = new DashBoardDbContext();
        public List<DashboardItem> GetAllDashboardItems()
        {
            return context.Dashboarditems.Include("Graph").ToList();
        }
        public List<DashboardItem> Update (List<DashboardItem> dbis)
        {
            foreach(DashboardItem dbi in dbis)
            {
                DashboardItem item = context.Dashboarditems.Where(i => i.Id == dbi.Id).First();
                context.Dashboarditems.Remove(item);
                context.Dashboarditems.Add(dbi);
                context.SaveChanges();
            }
            return context.Dashboarditems.ToList();
        }
    }
}
