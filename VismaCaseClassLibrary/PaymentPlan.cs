using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaCaseClassLibrary
{
    public class PaymentPlan
    {
        public double[] Payment { get; set; }
        public double[] AmountLeft { get; set; }
        public double[] InterestPerPeriod { get; set; }

        public PaymentPlan(double[] payment, double[] amountLeft, double[] interestPerPeriod)
        {
            this.Payment = payment;
            this.AmountLeft = amountLeft;
            this.InterestPerPeriod = interestPerPeriod;
        }

        /// <summary>
        /// This method is supposed to visualize to the user the payment plan for a loan they wanted.
        /// </summary>
        public void VisualizePlan()
        {
            StringBuilder planVisualizer = new StringBuilder();
            string payment = "Payment";
            string interest = "Interest";
            string amountLeft = "Amount Left";
            string header = string.Format("{0}  {1}  {2}", payment, interest, amountLeft);
            planVisualizer.AppendLine(header);

            ///We would like to show the user how the loan looks before the first payment aswell.
            payment = "     ";
            interest = "           ";
            amountLeft = this.AmountLeft[0].ToString();
            string beforeLoanPaymentStart = string.Format("{0}  {1}  {2}", payment, interest, amountLeft);
            planVisualizer.AppendLine(beforeLoanPaymentStart);

            ///For each row of payments we want to update how the loan plan looks
            for (int i = 0; i < Payment.Length; i++)
            {
                
                payment = this.Payment[i].ToString();  
                interest = this.InterestPerPeriod[i].ToString();
                amountLeft = this.AmountLeft[i+1].ToString();
                string newLine = string.Format("{0}    {1}    {2}", payment, interest, amountLeft);
                planVisualizer.AppendLine(newLine);

            }
            ///Simply visualizing the plan in the console.
            Console.WriteLine(planVisualizer.ToString());
        }
    }
}
