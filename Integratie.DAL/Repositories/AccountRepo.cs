using Integratie.DAL.EF;
using Integratie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories
{
    public class AccountRepo
    {
        private DashBoardDbContext context;

        public AccountRepo()
        {
            context = new DashBoardDbContext();
        }
        public IEnumerable<Account> GetAccounts()
        {
            return context.Accounts.ToList();
        }
    }
}
