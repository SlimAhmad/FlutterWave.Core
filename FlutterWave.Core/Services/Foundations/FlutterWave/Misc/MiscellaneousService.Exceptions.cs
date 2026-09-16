using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Misc;
using RESTFulSense.Exceptions;
using System;
using System.Threading.Tasks;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.MiscService
{
    internal partial class MiscellaneousService
    {
        private delegate ValueTask<BvnConsent> ReturningBvnConsentFunction();

        private delegate ValueTask<BinVerification> ReturningBinVerificationFunction();

        private delegate ValueTask<BalanceByCurrencies> ReturningBalanceByCurrenciesFunction();

        private delegate ValueTask<BalanceByCurrency> ReturningBalanceByCurrencyFunction();

        private delegate ValueTask<BankAccountVerification> ReturningBankAccountVerificationFunction();

        private delegate ValueTask<Statement> ReturningStatementFunction();

        private async ValueTask<BvnConsent> TryCatch(ReturningBvnConsentFunction returningBvnConsentFunction)
        {
            try
            {
                return await returningBvnConsentFunction();
            }
            catch (NullMiscellaneousException nullMiscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMiscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMiscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMiscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMiscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMiscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMiscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMiscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMiscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMiscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMiscellaneousServiceException);
            }
        }

        private async ValueTask<BinVerification> TryCatch(ReturningBinVerificationFunction returningBinVerificationFunction)
        {
            try
            {
                return await returningBinVerificationFunction();
            }
            catch (NullMiscellaneousException nullMiscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMiscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMiscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMiscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMiscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMiscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMiscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMiscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMiscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMiscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMiscellaneousServiceException);
            }
        }

        private async ValueTask<BalanceByCurrencies> TryCatch(ReturningBalanceByCurrenciesFunction returningBalanceByCurrenciesFunction)
        {
            try
            {
                return await returningBalanceByCurrenciesFunction();
            }
            catch (NullMiscellaneousException nullMiscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMiscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMiscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMiscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMiscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMiscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMiscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMiscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMiscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMiscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMiscellaneousServiceException);
            }
        }

        private async ValueTask<BalanceByCurrency> TryCatch(ReturningBalanceByCurrencyFunction returningBalanceByCurrencyFunction)
        {
            try
            {
                return await returningBalanceByCurrencyFunction();
            }
            catch (NullMiscellaneousException nullMiscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMiscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMiscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMiscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMiscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMiscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMiscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMiscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMiscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMiscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMiscellaneousServiceException);
            }
        }

        private async ValueTask<BankAccountVerification> TryCatch(ReturningBankAccountVerificationFunction returningBankAccountVerificationFunction)
        {
            try
            {
                return await returningBankAccountVerificationFunction();
            }
            catch (NullMiscellaneousException nullMiscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMiscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMiscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMiscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMiscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMiscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMiscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMiscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMiscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMiscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMiscellaneousServiceException);
            }
        }

        private async ValueTask<Statement> TryCatch(ReturningStatementFunction returningStatementFunction)
        {
            try
            {
                return await returningStatementFunction();
            }
            catch (NullMiscellaneousException nullMiscellaneousException)
            {
                throw new MiscellaneousValidationException(nullMiscellaneousException);
            }
            catch (InvalidMiscellaneousException invalidMiscellaneousException)
            {
                throw new MiscellaneousValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationMiscellaneousException =
                    new InvalidConfigurationMiscException(httpResponseUrlNotFoundException);

                throw new MiscellaneousDependencyException(invalidConfigurationMiscellaneousException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseUnauthorizedException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedMiscellaneousException =
                    new UnauthorizedMiscException(httpResponseForbiddenException);

                throw new MiscellaneousDependencyException(unauthorizedMiscellaneousException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundMiscellaneousException =
                    new NotFoundMiscException(httpResponseNotFoundException);

                throw new MiscellaneousDependencyValidationException(notFoundMiscellaneousException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidMiscellaneousException =
                    new InvalidMiscellaneousException(httpResponseBadRequestException);

                throw new MiscellaneousDependencyValidationException(invalidMiscellaneousException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallMiscellaneousException =
                    new ExcessiveCallMiscException(httpResponseTooManyRequestsException);

                throw new MiscellaneousDependencyValidationException(excessiveCallMiscellaneousException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerMiscellaneousException =
                    new FailedServerMiscException(httpResponseException);

                throw new MiscellaneousDependencyException(failedServerMiscellaneousException);
            }
            catch (Exception exception)
            {
                var failedMiscellaneousServiceException =
                    new FailedMiscServiceException(exception);

                throw new MiscellaneousServiceException(failedMiscellaneousServiceException);
            }
        }

    }
}