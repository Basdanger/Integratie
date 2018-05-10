using Integratie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories.Interfaces
{
    public interface IAccountRepo
    {
        IEnumerable<Account> ReadAccounts();
        Account ReadAccountById(string id);
        Account CreateAccount(string id, string name, string mail);
        void UpdateAccount(Account account);
        void DeleteAccount(string id);

    }
}
