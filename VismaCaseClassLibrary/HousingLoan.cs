using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaCaseClassLibrary
{
    public class HousingLoan : Loan
    {
        
        /// <summary>
        /// Constructor of a HousingLoan with a current set interest rate at 3.5% yearly and a
        /// current payment period of a month.
        /// </summary>
        /// <param name="loanAmount">The amount initially loaned</param>
        /// <param name="paybackTime">The amount of years to pay back the loan</param>
        public HousingLoan(double loanAmount, int paybackTime)
        {
            ///Currently just setting the fixed rate to what was specified in the case description
            SetFixedRate(0.035);
            this.LoanAmount = loanAmount;
            this.PaybackTime = paybackTime;
            this.PaymentPeriod = PeriodTypesEnum.Monthly;
        }

        private void SetFixedRate(double fixedRate)
        {
            this.FixedRate = fixedRate;
        }
    }
}
