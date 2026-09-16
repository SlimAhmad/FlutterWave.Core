using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Subscription;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.OTP
{
    public interface ISubscriptionsClient
    {
        /// <exception cref="SubscriptionClientValidationException" />
        /// <exception cref="SubscriptionClientDependencyException" />
        /// <exception cref="SubscriptionClientServiceException" />
        ValueTask<AllSubscription> FetchAllSubscriptionsAsync();

        ValueTask<Subscription> ActivateSubscriptionAsync(string subscriptionId);
        ValueTask<Subscription> DeactivateSubscriptionAsync(string subscriptionId);
    }
}
