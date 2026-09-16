using FlutterWave.Core.Models.Services.Foundations.FlutterWave.BillPayments;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.BillPayment
{
    public interface IBillPaymentsClient
    {
        /// <exception cref="BillPaymentsClientValidationException" />
        /// <exception cref="BillPaymentsClientDependencyException" />
        /// <exception cref="BillPaymentsClientServiceException" />
        ValueTask<BillCategories> FetchBillCategoriesAsync();

        ValueTask<ValidateBillService> FetchValidateBillServiceAsync(
            string itemCode, string code, string customer);

        ValueTask<PostBillPayments> SendCreateBillPaymentAsync(
            PostBillPayments billPayments);

        ValueTask<BulkBillPayments> SendCreateBulkBillAsync(
          BulkBillPayments billPayments);

        ValueTask<BillPaymentsStatus> FetchBillStatusPaymentAsync(
            string reference);

        ValueTask<BillPayments> FetchBillPaymentsAsync();
    }
}
