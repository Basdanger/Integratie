using Integratie.BL.Managers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.Domain.Entities;
using Integratie.DAL.Repositories;
using Integratie.DAL.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;
using Integratie.Domain.Entities.Subjects;

namespace Integratie.BL.Managers
{
    public class AccountManager : IAccountManager
    {
        private AccountRepo repo;
        private UnitOfWorkManager unitOfWorkManager;

        public AccountManager()
        {
            repo = new AccountRepo();
        }

        public AccountManager(UnitOfWorkManager unitOfWorkManager)
        {
            this.unitOfWorkManager = unitOfWorkManager;
            repo = new AccountRepo(unitOfWorkManager.UnitOfWork);
        }

        public Account AddAccount(string id, string name, string mail)
        {
            Account account = new Account(id, name, mail);
            this.Validate(account);
            return repo.CreateAccount(account.ID, account.Name, account.Mail);
        }

        public void ChangeAccount(Account account)
        {
            this.Validate(account);
            repo.UpdateAccount(account);
        }

        public Account GetAccountById(string id)
        {
            return repo.ReadAccountById(id);
        }

        public IEnumerable<Account> GetAccounts()
        {
            return repo.ReadAccounts();
        }

        public void RemoveAccount(string id)
        {
            repo.DeleteAccount(id);
        }

        private void Validate(Account account)
        {
            //Validator.ValidateObject(ticket, new ValidationContext(ticket), validateAllProperties: true);

            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(account, new ValidationContext(account), errors, validateAllProperties: true);

            if (!valid)
                throw new ValidationException("Account not valid!");
        }

        public void AddFollow(string accountId,int subjectId)
        {
            initNonExistingRepo(true);
            Account account = repo.ReadAccountById(accountId);
            SubjectManager subjectManager = new SubjectManager(unitOfWorkManager);
            account.Follows.Add(subjectManager.GetSubjectById(subjectId));
            repo.UpdateAccount(account);
        }

        public void RemoveFollow(string accountId, int subjectId)
        {
            Account account = repo.ReadAccountById(accountId);
            Subject subject = account.Follows.Find(f => f.ID.Equals(subjectId));
            account.Follows.Remove(subject);
            repo.UpdateAccount(account);
        }

        public void initNonExistingRepo(bool createWithUnitOfWork = false)
        {
            if (repo == null)
            {
                if (createWithUnitOfWork)
                {
                    if (unitOfWorkManager == null)
                    {
                        unitOfWorkManager = new UnitOfWorkManager();
                    }
                    repo = new AccountRepo(unitOfWorkManager.UnitOfWork);
                }
                else
                {
                    repo = new AccountRepo();
                }
            }
        }
    }
}
