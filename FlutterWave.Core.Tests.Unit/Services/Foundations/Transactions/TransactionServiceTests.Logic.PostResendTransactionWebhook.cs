using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalTransactions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldResendTransactionWebhookWithTransactionIdAsync()
        {
            // given
            int inputTransactionId = GetRandomNumber();
            int inputWait = GetRandomNumber();

            dynamic resendTransactionWebhookRandomProperties =
                CreateRandomResendTransactionWebhookProperties();

            var externalResendTransactionWebhookResponse = new ExternalResendTransactionWebhookResponse
            {
                Status = resendTransactionWebhookRandomProperties.Status,
                Message = resendTransactionWebhookRandomProperties.Message,
                Data = resendTransactionWebhookRandomProperties.Data,
            };

            var expectedResendTransactionWebhookResponse = new ResendTransactionWebhookResponse
            {
                Status = resendTransactionWebhookRandomProperties.Status,
                Message = resendTransactionWebhookRandomProperties.Message,
                Data = resendTransactionWebhookRandomProperties.Data,
            };

            var expectedResendTransactionWebhook = new ResendTransactionWebhook
            {
                Response = expectedResendTransactionWebhookResponse
            };

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostResendTransactionWebhookAsync(inputTransactionId, inputWait))
                    .ReturnsAsync(externalResendTransactionWebhookResponse);

            // when
            ResendTransactionWebhook actualResendTransactionWebhook =
                await this.transactionsService.PostResendTransactionWebhookAsync(inputTransactionId, inputWait);

            // then
            actualResendTransactionWebhook.Should().BeEquivalentTo(expectedResendTransactionWebhook);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(inputTransactionId, inputWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
        }
    }
}
