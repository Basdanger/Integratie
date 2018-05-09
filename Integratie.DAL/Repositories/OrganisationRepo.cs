using Integratie.DAL.EF;
using Integratie.DAL.Repositories.Interfaces;
using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories
{
    public class OrganisationRepo : IOrganisationRepo
    {
        private DashBoardDbContext context;

        public OrganisationRepo()
        {
            context = new DashBoardDbContext();
        }

        public bool CheckOrganisationExist(Organisation organisation)
        {
            return context.Organisations.Any(p => p.ID == organisation.ID);
        }

        public void CreateOrganisation(Organisation organisation)
        {
            context.Organisations.Add(organisation);
        }

        public IEnumerable<Organisation> ReadOrganisations()
        {
            IEnumerable<Organisation> people = context.Organisations.ToList<Organisation>();
            return people;
        }

        public Organisation ReadOrganisation(double id)
        {
            return context.Organisations.SingleOrDefault(p => p.ID == id);
        }
    }
}
