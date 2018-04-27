using Integratie.BL.Managers.Interfaces;
using Integratie.DAL;
using Integratie.Domain;
using Integratie.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.BL.Managers
{
    public class RecordManager
    {
        private IFeedRepo repo;

        public RecordManager()
        {
            repo = new FeedRepo();
        }
    }
}
