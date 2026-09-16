using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Banks;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Banks
{
    public interface IBanksClient
    {
        /// <exception cref="BankClientValidationException" />
        /// <exception cref="BankClientDependencyException" />
        /// <exception cref="BankClientServiceException" />
        ValueTask<BankBranches> RetrieveAllBankBranchesByBankCodeAsync(int bankCode);

        ValueTask<Bank> RetrieveAllBanksByCountryAsync(string country);
    }
}
