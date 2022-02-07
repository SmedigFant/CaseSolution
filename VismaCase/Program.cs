using System;
using System.Net.Http;
using VismaCaseClassLibrary;

namespace VismaCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
           


            Loan exampleLoan = new HousingLoan(10000, 3);

            FixedPaymentCalculator exampleCalc = new FixedPaymentCalculator(exampleLoan);

            PaymentPlan examplePlan = exampleCalc.CalculatePlan();

            examplePlan.VisualizePlan();


        }
    }
}
