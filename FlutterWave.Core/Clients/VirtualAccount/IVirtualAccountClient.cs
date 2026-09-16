using FlutterWave.Core.Models.Services.Foundations.FlutterWave.VirtualAccounts;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.VirtualAccount
{
    public interface IVirtualAccountsClient
    {
        /// <exception cref="VirtualAccountsClientValidationException" />
        /// <exception cref="VirtualAccountsClientDependencyException" />
        /// <exception cref="VirtualAccountsClientServiceException" />
        ValueTask<CreateVirtualAccounts> CreateVirtualAccountAsync(
     CreateVirtualAccounts virtualAccounts);


        ValueTask<BulkCreateVirtualAccounts> BulkCreateVirtualAccountsAsync(
        BulkCreateVirtualAccounts virtualAccounts);


        ValueTask<FetchVirtualAccounts> RetrieveVirtualAccountNumberAsync(
        string orderReference);

        ValueTask<BulkVirtualAccountDetails> RetrieveBulkVirtualAccountDetailsAsync(
        string batchId);

        ValueTask<DeleteVirtualAccounts> RemoveVirtualAccountsAsync(
        DeleteVirtualAccounts virtualAccounts, string orderReference);

        ValueTask<UpdateBvnVirtualAccounts> UpdateVirtualAccountsBvnAsync(
        UpdateBvnVirtualAccounts virtualAccounts, string orderReference);
    }
}
