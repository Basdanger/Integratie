using Integratie.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL
{
    public class UnitOfWork
    {
        private DashBoardDbContext ctx;

        internal DashBoardDbContext Context
        {
            get
            {
                if (ctx == null) ctx = new DashBoardDbContext(true);
                return ctx;
            }
        }

        public void CommitChanges()
        {
            ctx.CommitChanges();
        }
    }
}
