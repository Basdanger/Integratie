using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.Repositories;
using Integratie.Domain.Entities;

namespace Integratie.BL.Managers
{
    public class AccountManager
    {
        private AccountRepo accountRepo;

        public AccountManager()
        {
            accountRepo = new AccountRepo();
        }
        public IEnumerable<Account> GetAccounts()
        {
            return accountRepo.GetAccounts();
        }
    }
}
