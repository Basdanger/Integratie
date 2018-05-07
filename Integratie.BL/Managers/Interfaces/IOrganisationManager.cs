using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers.Interfaces
{
    public interface IOrganisationManager
    {
        IEnumerable<Organisation> GetOrganisations();
        Organisation GetOrganisation(double id);
        void MakeOrganisation(Organisation organisation);
        bool CheckOrganisation(Organisation organisation);
    }
}
