using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Alerts
{
   public enum SubjectProperty 
    {
        count,
        relativeCount,
        pos,
        neg
    };
    public static class SubjectExtension
    {
        public static string GetSubject(this Enum value)
        {
            if (value.Equals(SubjectProperty.count))
            {
                return "#";
            }
            else if (value.Equals(SubjectProperty.relativeCount))
            {
                return "%";
            }
            else if (value.Equals(SubjectProperty.pos))
            {
                return "+";
            }
            else
            {
                return "-";
            }
            
        }
    }
}

