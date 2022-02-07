
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaCaseClassLibrary
{
    public class FixedPaymentCalculator : IPaymentPlanner
    {
        public Loan Loan { get; set; }

        /// <summary>
        /// Initiates a PaymentIncrementCalculator to be used for calculating the fixed payments of a Loan over a
        /// set period.
        /// </summary>
        /// <param name="loan">A type of loan specifying the interest rate, loan amount and loan duration</param>
        public FixedPaymentCalculator(Loan loan)
        {
            this.Loan = loan;
        }

        /// <summary>
        /// Calculates a payment plan
        /// </summary>
        public PaymentPlan CalculatePlan()
        {
            int totalPayments = (int)GetTotalPayments();

            ///In order to return a PaymentPlan we have to fill in the numbers that will be presented
            ///To the user. This includes the fixed payment amount, the resulting interest of the current month,
            ///The amount left of the loan after interest.
            double[] fixedPaymentAmount = new double[totalPayments];
            double[] amountLeftAfterInterest = new double[totalPayments+1];
            double[] interestThisMonth = new double[totalPayments];

            double fixedPayment = CalculateFixedPayments();
            double amountLeftBeforeInterest;
            double interestPerPeriod = Math.Pow((1.0+this.Loan.FixedRate),  (1.0/12.0)) - 1.0;


            amountLeftAfterInterest[0] = Loan.LoanAmount;

            ///This for loop sets the state of the loan after each payment, currently it is giving some error in the
            ///calculations. Because the last payment results in a negative amount left of the loan we know that this
            ///is not correct.
            for (int i = 0; i < totalPayments; i++)
            {
                
                ///Using math.round because it is not that important to include more than two decimals
                fixedPaymentAmount[i] = Math.Round(fixedPayment, 2);

                ///We take away the payment received each month and calculate this
                amountLeftBeforeInterest = Math.Round(CalculateAmountLeftBeforeInterest(amountLeftAfterInterest[i], fixedPayment), 2);

                ///And then we add the interest from the number we just calculated.
                interestThisMonth[i] = Math.Round(CalculateInterestThisMonth(interestPerPeriod, amountLeftBeforeInterest), 2);

                ///Lastly we add this interest to the amount we got from the CalculateAmountBeforeInterest-method.
                amountLeftAfterInterest[i+1] = Math.Round((amountLeftBeforeInterest + interestThisMonth[i]), 2);
            }

            ///We return a new PaymentPlan which contains all the information we want to show the user at this point.
            return new PaymentPlan(fixedPaymentAmount, amountLeftAfterInterest, interestThisMonth);
        }

        /// <summary>
        /// This function calculates the payment per period(in our example per month).
        /// The actual formula used in the function was found on this website: 
        /// https://www.kasasa.com/blog/how-to-calculate-loan-payments-in-3-easy-steps
        /// on the 3rd of february.
        /// 
        /// A = Payment amount per period
        /// P = Initial principal or loan amount(in this example, $10,000)
        /// r = Interest rate per period(in our example, that's 7.5% divided by 12 months)
        /// n = Total number of payments or periods
        /// The formula for calculating your monthly payment is:
        /// 
        /// A = P(r(1 + r) ^ n) / ((1 + r) ^ n - 1)
        /// 
        /// </summary>
        /// <returns></returns>
        public double CalculateFixedPayments()
        {
            ///Using all double types and no ints in fear of getting a rounding miscalculation
            double totalAmountLoaned = Loan.LoanAmount;
            double interestRatePerPeriod = Loan.FixedRate/(double)Loan.PaymentPeriod;
            double totalPayments = GetTotalPayments();


            ///Using Formula:
            ///I find it easier to split the fraction into two calculations
            double topOfFraction = totalAmountLoaned*(interestRatePerPeriod*Math.Pow((1.0 + interestRatePerPeriod), totalPayments));
            double bottomOfFraction = Math.Pow((1.0 + interestRatePerPeriod), totalPayments) - 1.0;

            ///And then do the fraction afterwards
            double fixedPayments = topOfFraction / bottomOfFraction;

            
            return fixedPayments;
        }




        /// <summary>
        /// Returns the total payments based on the payment period in years and how many payments per year.
        /// </summary>
        /// <returns></returns>
        private double GetTotalPayments()
        {
            return (double)Loan.PaymentPeriod * Loan.PaybackTime;
        }

        /// <summary>
        /// Helper method for calculations in the CalculatePlan method
        /// </summary>
        /// <param name="previousPeriodAmountLeft"></param>
        /// <param name="fixedPayment"></param>
        /// <returns></returns>
        private double CalculateAmountLeftBeforeInterest(double previousPeriodAmountLeft, double fixedPayment)
        {
            return previousPeriodAmountLeft - fixedPayment;
        }

        /// <summary>
        /// Helper method for calculations in the CalculatePlan method
        /// </summary>
        /// <param name="periodInterestRate"></param>
        /// <param name="interestBasis"></param>
        /// <returns></returns>
        private double CalculateInterestThisMonth(double periodInterestRate, double interestBasis)
        {
            return periodInterestRate * interestBasis;
        }
    }
}
