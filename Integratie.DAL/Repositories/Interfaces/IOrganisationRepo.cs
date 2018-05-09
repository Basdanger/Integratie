using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.Repositories.Interfaces
{
    public interface IOrganisationRepo
    {
        IEnumerable<Organisation> ReadOrganisations();
        Organisation ReadOrganisation(double id);
        void CreateOrganisation(Organisation organisation);
        bool CheckOrganisationExist(Organisation organisation);
    }
}
