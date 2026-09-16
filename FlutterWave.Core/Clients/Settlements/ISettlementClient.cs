using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Settlements;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.SettlementClient
{
    public interface ISettlementClient
    {
        /// <exception cref="SettlementClientValidationException" />
        /// <exception cref="SettlementClientDependencyException" />
        /// <exception cref="SettlementClientServiceException" />
        ValueTask<AllSettlements> RetrieveAllSettlementsAsync();
        ValueTask<Settlement> FetchSettlementByIdAsync(string settlementId);
    }
}
