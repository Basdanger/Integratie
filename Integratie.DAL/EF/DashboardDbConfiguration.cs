using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.EF
{
    internal class DashboardDbConfiguration : DbConfiguration
    {
        public DashboardDbConfiguration()
        {
            this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
            this.SetProviderServices("System.Data.Client", System.Data.Entity.SqlServer.SqlProviderServices.Instance);
            this.SetDatabaseInitializer<DashBoardDbContext>(new DashboardDbInitializer());
        }
    }
}
