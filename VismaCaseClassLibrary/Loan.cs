using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaCaseClassLibrary
{
    public abstract class Loan
    {
        public double FixedRate { get; protected set; }
        public int PaybackTime { get; protected set; }    
        public double LoanAmount { get; protected set; }   
        public PeriodTypesEnum PaymentPeriod { get; protected set; }
    }
}
