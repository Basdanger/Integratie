using System;
using Integratie.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL
{
    public interface IResourceRepo
    {
        IEnumerable<Resource> ReadResources();
        Resource ReadResource(string culture, string name);
        void AddResource(Resource resource);
        void UpdateResource(string culture, string name, string value);
        void RemoveResource(string culture, string name);
    }
}
