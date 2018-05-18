using Integratie.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities;
using Integratie.DAL.EF;

namespace Integratie.DAL.Repositories
{
    public class AccountRepo : IAccountRepo
    {
        private DashBoardDbContext context;

        public AccountRepo()
        {
            context = new DashBoardDbContext();
        }

        public AccountRepo(DashBoardDbContext context)
        {
            this.context = context;
        }

        public DashBoardDbContext GetContext()
        {
            return context;
        }

        public Account CreateAccount(string id, string name, string mail)
        {
            Account account = new Account(id, name, mail);

            context.Accounts.Add(account);
            context.SaveChanges();
            return account;
        }

        public void DeleteAccount(string id)
        {
            Account account = context.Accounts.Find(id);
            context.Accounts.Remove(account);
            context.SaveChanges();
        }

        public Account ReadAccountById(string id)
        {
            return context.Accounts.Find(id);
        }

        public IEnumerable<Account> ReadAccounts()
        {
            IEnumerable<Account> accounts = context.Accounts.ToList<Account>();
            return accounts;
        }

        public void UpdateAccount(Account account)
        {
            context.Entry(account).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
