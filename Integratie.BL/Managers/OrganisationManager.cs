using Integratie.BL.Managers.Interfaces;
using Integratie.DAL.Repositories;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{
    public class OrganisationManager : IOrganisationManager
    {
        private IOrganisationRepo repo;

        public OrganisationManager()
        {
            repo = new OrganisationRepo();
        }
        public IEnumerable<Organisation> GetOrganisations()
        {
            return repo.ReadOrganisations();
        }

        public Organisation GetOrganisation(double id)
        {
            return repo.ReadOrganisation(id);
        }

        public void MakeOrganisation(Organisation organisation)
        {
            repo.CreateOrganisation(organisation);
        }

        public bool CheckOrganisation(Organisation organisation)
        {
            return repo.CheckOrganisationExist(organisation);
        }
    }
}
