using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Integratie.BL.Managers.Interfaces
{
    public interface ITextgainManager
    {
        void UpdateDatabase(object source, ElapsedEventArgs e);
    }
}
