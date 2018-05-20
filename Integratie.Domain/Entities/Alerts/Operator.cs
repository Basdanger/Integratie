using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.Domain.Entities.Alerts
{
    public enum Operator
    {
        GT,
        LT
    };
    public static class OperatorExtension
    {
        public static string GetOperator(this Enum value)
        {
            if (value.Equals(Operator.GT))
            {
                return ">";
            }
            else
            {
                return "<";
            }
        }
    }
}
