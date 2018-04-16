using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.DAL.EF;
using Integratie.Domain.Entities;

namespace Integratie.DAL
{
    public class ResourceRepo : IResourceRepo
    {
        private DashBoardDbContext context;

        public ResourceRepo()
        {
            context = new DashBoardDbContext();
        }

        public IEnumerable<Resource> ReadResources()
        {
            IEnumerable<Resource> resources = context.Resources.ToList<Resource>();

            return resources;
        }

        public Resource ReadResource(string culture, string name)
        {
            Resource resource = context.Resources.Find(culture, name);

            return resource;
        }

        public void AddResource(Resource resource)
        {
            context.Resources.Add(resource);
            context.SaveChanges();
        }

        public void UpdateResource(string culture, string name, string value)
        {
            Resource update = ReadResource(culture, name);
            update.Value = value;
            context.SaveChanges();
        }

        public void RemoveResource(string culture, string name)
        {
            Resource remove = ReadResource(culture, name);
            context.Resources.Remove(remove);
            context.SaveChanges();
        }
    }
}
