using FluentAssertions;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Transactions;
using Moq;
using RESTFulSense.Exceptions;

namespace FlutterWave.Core.Tests.Unit.Services.Foundations.Transactions
{
    public partial class TransactionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostResendTransactionWebhookIfUrlNotFoundAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();
            int someWait = GetRandomNumber();

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransactionsException =
                new InvalidConfigurationTransactionsException(
                    httpResponseUrlNotFoundException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    invalidConfigurationTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
               this.transactionsService.PostResendTransactionWebhookAsync(someTransactionId, someWait);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPostResendTransactionWebhookIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            int someTransactionId = GetRandomNumber();
            int someWait = GetRandomNumber();

            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostResendTransactionWebhookAsync(someTransactionId, someWait))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
               this.transactionsService.PostResendTransactionWebhookAsync(someTransactionId, someWait);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostResendTransactionWebhookIfNotFoundOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();
            int someWait = GetRandomNumber();

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransactionsException =
                new NotFoundTransactionsException(
                    httpResponseNotFoundException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    notFoundTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
               this.transactionsService.PostResendTransactionWebhookAsync(someTransactionId, someWait);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostResendTransactionWebhookIfBadRequestOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();
            int someWait = GetRandomNumber();

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransactionsException =
                new InvalidTransactionsException(
                    httpResponseBadRequestException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    invalidTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
               this.transactionsService.PostResendTransactionWebhookAsync(someTransactionId, someWait);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPostResendTransactionWebhookIfTooManyRequestsOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();
            int someWait = GetRandomNumber();

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransactionsException =
                new ExcessiveCallTransactionsException(
                    httpResponseTooManyRequestsException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    excessiveCallTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostResendTransactionWebhookAsync(someTransactionId, someWait))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
               this.transactionsService.PostResendTransactionWebhookAsync(someTransactionId, someWait);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPostResendTransactionWebhookIfHttpResponseErrorOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();
            int someWait = GetRandomNumber();

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransactionsException =
                new FailedServerTransactionsException(
                    httpResponseException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    failedServerTransactionsException);

            this.flutterWaveBrokerMock.Setup(broker =>
                 broker.PostResendTransactionWebhookAsync(someTransactionId, someWait))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
               this.transactionsService.PostResendTransactionWebhookAsync(someTransactionId, someWait);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPostResendTransactionWebhookIfServiceErrorOccurredAsync()
        {
            // given
            int someTransactionId = GetRandomNumber();
            int someWait = GetRandomNumber();
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.flutterWaveBrokerMock.Setup(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ResendTransactionWebhook> resendTransactionWebhookTask =
               this.transactionsService.PostResendTransactionWebhookAsync(someTransactionId, someWait);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    resendTransactionWebhookTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.flutterWaveBrokerMock.Verify(broker =>
                broker.PostResendTransactionWebhookAsync(someTransactionId, someWait),
                    Times.Once);

            this.flutterWaveBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
