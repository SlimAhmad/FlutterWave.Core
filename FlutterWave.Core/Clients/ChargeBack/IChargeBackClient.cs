using FlutterWave.Core.Models.Services.Foundations.FlutterWave.ChargeBacks;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.ChargeBacks
{
    public interface IChargeBackClient
    {
        /// <exception cref="ChargeBacksClientValidationException" />
        /// <exception cref="ChargeBacksClientDependencyException" />
        /// <exception cref="ChargeBacksClientServiceException" />
        ValueTask<AllChargeBacks> RetrieveAllChargeBacksAsync();
        ValueTask<AcceptDeclineChargeBack> AcceptDeclineChargeBacksAsync(
          string chargeBackId, AcceptDeclineChargeBack chargeBack);
        ValueTask<ChargeBack> RetrieveChargeBackAsync(string flutterWaveReference);
    }
}
