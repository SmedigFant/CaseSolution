using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaCaseClassLibrary
{
    /// <summary>
    /// Each enum value refers to the number of payments in a year.
    /// </summary>
    public enum PeriodTypesEnum
    {
        Yearly = 1,
        SemiAnnualy = 2,
        Quarterly = 3,
        Monthly = 12,
        Weekly = 52,
    }
}
