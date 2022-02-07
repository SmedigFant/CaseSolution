using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VismaCaseClassLibrary
{

    /// <summary>
    /// An interface that can be implemented if the impleting class wants to find a payment plan.
    /// </summary>
    public interface IPaymentPlanner
    {
        PaymentPlan CalculatePlan();
    }
}
