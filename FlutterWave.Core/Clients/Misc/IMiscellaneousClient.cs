using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Misc
{
    public interface IMiscellaneousClient
    {
        /// <exception cref="MiscellaneousClientValidationException" />
        /// <exception cref="MiscellaneousClientDependencyException" />
        /// <exception cref="MiscellaneousClientServiceException" />
        ValueTask<BalanceByCurrency> BalanceByCurrencyAsync(string externalBalanceByCurrencyRequest);

        ValueTask<BalanceByCurrencies> BalanceCurrenciesAsync();

        ValueTask<Statement> AccountStatementAsync();

        ValueTask<BankAccountVerification> BankAccountVerificationAsync(
             BankAccountVerification bankAccountVerification);

        ValueTask<BvnConsent> BvnConsentAsync(
            BvnConsent bvnConsent);

        ValueTask<BinVerification> CardBinVerificationAsync(
           string bin);

    }
}
