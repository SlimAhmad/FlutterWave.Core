using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public async Task ShouldThrowValidationExceptionOnPostResendTransactionWebhookIfIdOrWaitIsInvalidAsync(
            int invalidTransactionId, int invalidWait)
        {
            // given
            var invalidTransactionsException =
                new InvalidTransactionsException();

            invalidTransactionsException.AddData(
                key: nameof(ResendTransactionWebhook),
                values: "A valid number is required");

            var expectedTransactionsValidationException =
                new TransactionsValidationException(invalidTransactionsException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
                this.transactionsService.PostResendTransactionWebhookAsync(invalidTransactionId, invalidWait);

            TransactionsValidationException actualTransactionsValidationException =
                await Assert.ThrowsAsync<TransactionsValidationException>(
                    resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsValidationException.Should()
                .BeEquivalentTo(expectedTransactionsValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(
                    It.IsAny<int>(), It.IsAny<int>()),
                        Times.Never);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
