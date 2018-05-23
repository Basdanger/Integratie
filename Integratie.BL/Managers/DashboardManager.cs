using Integratie.DAL;
using Integratie.DAL.Repositories;
using Integratie.Domain.Entities.Dashboard;
using Integratie.Domain.Entities.Graph;
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
        GraphManager graphManager = new GraphManager();
        public List<DashboardItem> GetAllDashboardItems()
        {
            List<DashboardItem> dbis = repo.GetAllDashboardItems();
            foreach(DashboardItem dbi in dbis)
            {
                if(dbi.Graph.GraphType == GraphType.Barchart)
                {
                    dbi.Graph = graphManager.GetFilledBarGraph(dbi.Graph);
                }
                if(dbi.Graph.GraphType == GraphType.Single)
                {
                    
                    dbi.Graph = graphManager.GetFilledSingleGraph(dbi.Graph);
                }
                if(dbi.Graph.GraphType == GraphType.Linechart)
                {

                    dbi.Graph = graphManager.GetFilledLineGraph(dbi.Graph);
                }
                if (dbi.Graph.GraphType == GraphType.SingleTrend)
                {
                    dbi.Graph = graphManager.GetFilledSingleTrendGraph(dbi.Graph);
                }
            }
            return dbis;
        }
        public List<DashboardItem> Update(List<DashboardItem> dbis)
        {
            return repo.Update(dbis);
        }
        public DashboardItem AddDashboardItem(DashboardItem dbi)
        {
            return repo.AddDashboardItem(dbi);
        }

        public void UpdateDashboard(List<DashboardItem> dashboardItems)
        {
            GraphManager graphManager = new GraphManager();
            if (dashboardItems != null && dashboardItems.Count > 0)
            {
                dashboardItems.ForEach(d => d.Graph = graphManager.GetGraphbyId(d.GraphId));
                Update(dashboardItems);
            }
            else
            {
                repo.ClearItems();
            }
        }
        public void RemoveDashboardItem(DashboardItem item)
        {
            repo.Remove(item);
        }
    }
}
