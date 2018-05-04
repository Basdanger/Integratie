using Integratie.Domain.Entities.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers.Interfaces
{
    interface ISubjectManager
    {
        IEnumerable<Subject> GetSubjects();
    }
}
