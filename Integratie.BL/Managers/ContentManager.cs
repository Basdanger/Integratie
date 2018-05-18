using Integratie.DAL.Repositories;
using Integratie.Domain.Entities.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{
    public class ContentManager
    {
        ContentRepo repo = new ContentRepo();
        public SiteContent AddSiteContent(SiteContent sc)
        {
            return repo.AddSiteContent(sc);
        }
        public bool RemoveSiteContent(SiteContent sc)
        {
            return repo.DeleteSiteContent(sc);
        }
        public bool UpdateSiteContent(SiteContent sc)
        {
            return repo.UpdateSiteContent(sc);
        }
    }
}
