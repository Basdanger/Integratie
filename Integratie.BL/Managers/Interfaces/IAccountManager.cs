using Integratie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers.Interfaces
{
    public interface IAccountManager
    {
        IEnumerable<Account> GetAccounts();
        Account GetAccountById(string id);
        Account AddAccount(string id, string name, string mail);
        void ChangeAccount(Account account);
        void RemoveAccount(string id);
    }
}
