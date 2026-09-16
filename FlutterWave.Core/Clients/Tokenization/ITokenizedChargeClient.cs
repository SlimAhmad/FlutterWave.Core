using FlutterWave.Core.Models.Services.Foundations.FlutterWave.TokenizedCharge;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.Tokenization
{
    public interface ITokenizedChargeClient
    {
        /// <exception cref="TokenizationClientValidationException" />
        /// <exception cref="TokenizationClientDependencyException" />
        /// <exception cref="TokenizationClientServiceException" />
        ValueTask<CreateTokenizedCharge> CreateTokenizedChargeAsync(
          CreateTokenizedCharge CreateTokenizedCharge);

        ValueTask<CreateBulkTokenizedCharge> CreateBulkTokenizedChargeAsync(
            CreateBulkTokenizedCharge CreateBulkTokenizedCharge);

        ValueTask<FetchBulkTokenizedCharge> RetrieveBulkTokenizedChargesAsync(int bulkId);

        ValueTask<BulkTokenizedStatus> RetrieveBulkTokenizedStatusAsync(int bulkId);

        ValueTask<UpdateCardToken> UpdateCardTokenAsync(
                 string token, UpdateCardToken CreateBulkTokenizedCharge);
    }
}
