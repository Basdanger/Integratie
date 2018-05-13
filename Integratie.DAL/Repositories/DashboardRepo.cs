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
        public DashboardItem AddDashboardItem(DashboardItem item)
        {
            DashboardItem dbi = context.Dashboarditems.Add(item);
            context.SaveChanges();
            return dbi;
        }
        public List<DashboardItem> Update (List<DashboardItem> dbis)
        {
            foreach (DashboardItem dbi in dbis)
            {
                context.Entry(dbi).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            return context.Dashboarditems.ToList();
        }
        public void Remove (DashboardItem item)
        {
            DashboardItem i = context.Dashboarditems.Include("Graph").Where(dbi => dbi.Id == item.Id).First();
            context.Graphs.Remove(i.Graph);
            context.Dashboarditems.Remove(i);
            context.SaveChanges();
        }

        public void UpdateDashboardItem(DashboardItem dBI)
        {
            DashboardItem item = context.Dashboarditems.Where(i => i.Id == dBI.Id).First();
            context.Dashboarditems.Remove(item);
            context.Dashboarditems.Add(dBI);
            context.SaveChanges();
        }

        public void ClearItems()
        {
            context.Dashboarditems.RemoveRange(context.Dashboarditems.ToList());
            context.SaveChanges();
        }
    }
}
