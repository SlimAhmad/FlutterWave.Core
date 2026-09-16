using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PaymentPlan;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.PaymentPlans
{
    public interface IPaymentPlanClient
    {
        /// <exception cref="PaymentPlanClientValidationException" />
        /// <exception cref="PaymentPlanClientDependencyException" />
        /// <exception cref="PaymentPlanClientServiceException" />
        ValueTask<CreatePaymentPlan> CreatePaymentPlanAsync(
                  CreatePaymentPlan paymentPlan);
        ValueTask<AllPaymentPlans> FetchPaymentPlansAsync();
        ValueTask<PaymentPlan> FetchPaymentPlanAsync(string paymentPlanId);
        ValueTask<UpdatePaymentPlan> SendUpdatePaymentPlanAsync(
            string paymentPlanId, UpdatePaymentPlan paymentPlan);
        ValueTask<PaymentPlan> CancelPaymentPlanAsync(string paymentPlanId);

    }
}
