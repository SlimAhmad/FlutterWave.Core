using FlutterWave.Core.Models.Services.Foundations.FlutterWave.PayoutSubaccounts;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PayoutSubaccountsService
{
    internal partial class PayoutSubaccountsService
    {


        private static void ValidateCreatePayoutSubaccount(CreatePayoutSubaccount createPayoutSubaccount)
        {
            ValidateCreatePayoutSubaccountNotNull(createPayoutSubaccount);
            ValidateCreatePayoutSubaccountRequestNotNull(createPayoutSubaccount.Request);
            Validate(
                (Rule: IsInvalid(createPayoutSubaccount), Parameter: nameof(createPayoutSubaccount)));

            Validate(
                (Rule: IsInvalid(createPayoutSubaccount.Request.AccountName), Parameter: nameof(CreatePayoutSubaccountRequest.AccountName)),
                (Rule: IsInvalid(createPayoutSubaccount.Request.Email), Parameter: nameof(CreatePayoutSubaccountRequest.Email)),
                (Rule: IsInvalid(createPayoutSubaccount.Request.MobileNumber), Parameter: nameof(CreatePayoutSubaccountRequest.MobileNumber)),
                (Rule: IsInvalid(createPayoutSubaccount.Request.Country), Parameter: nameof(CreatePayoutSubaccountRequest.Country))


                );

        }

        private static void ValidateUpdatePayoutSubaccount(string accountReference, UpdatePayoutSubaccount updatePayoutSubaccount)
        {
            ValidateUpdatePayoutSubaccountNotNull(updatePayoutSubaccount);
            ValidateUpdatePayoutSubaccountRequestNotNull(updatePayoutSubaccount.Request);
            Validate(
                (Rule: IsInvalid(updatePayoutSubaccount), Parameter: nameof(updatePayoutSubaccount)));

            Validate(
                (Rule: IsInvalid(updatePayoutSubaccount.Request.AccountName), Parameter: nameof(UpdatePayoutSubaccountRequest.AccountName)),
                (Rule: IsInvalid(updatePayoutSubaccount.Request.MobileNumber), Parameter: nameof(UpdatePayoutSubaccountRequest.MobileNumber)),
                (Rule: IsInvalid(accountReference), Parameter: nameof(UpdatePayoutSubaccountRequest)),
                (Rule: IsInvalid(updatePayoutSubaccount.Request.Email), Parameter: nameof(UpdatePayoutSubaccountRequest.Email))
                );

        }





        private static void ValidateUpdatePayoutSubaccountRequestNotNull(UpdatePayoutSubaccountRequest updatePayoutSubaccountRequest)
        {
            Validate((Rule: IsInvalid(updatePayoutSubaccountRequest), Parameter: nameof(UpdatePayoutSubaccountRequest)));
        }
        private static void ValidateCreatePayoutSubaccountRequestNotNull(CreatePayoutSubaccountRequest createPayoutSubaccountRequest)
        {
            Validate((Rule: IsInvalid(createPayoutSubaccountRequest), Parameter: nameof(CreatePayoutSubaccountRequest)));
        }



        private static void ValidateCreatePayoutSubaccountNotNull(CreatePayoutSubaccount createPayoutSubaccount)
        {
            if (createPayoutSubaccount is null)
            {
                throw new NullPayoutSubaccountsException();
            }
        }
        private static void ValidateUpdatePayoutSubaccountNotNull(UpdatePayoutSubaccount updatePayoutSubaccount)
        {
            if (updatePayoutSubaccount is null)
            {
                throw new NullPayoutSubaccountsException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateFetchPayoutSubaccountString(string text) =>
            Validate((Rule: IsInvalid(text), Parameter: nameof(FetchPayoutSubaccount)));

        private static void ValidatePayoutSubaccountTransactionsString(string text) =>
        Validate((Rule: IsInvalid(text), Parameter: nameof(FetchPayoutSubaccountTransactions)));

        private static void ValidateFetchStaticVirtualAccountsString(string text) =>
       Validate((Rule: IsInvalid(text), Parameter: nameof(FetchStaticVirtualAccounts)));

        private static void ValidateFetchSubaccountAvailableBalanceString(string text) =>
       Validate((Rule: IsInvalid(text), Parameter: nameof(FetchSubaccountAvailableBalance)));





        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };
        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static dynamic IsInvalid(decimal number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static dynamic IsInvalid(int number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidPayoutSubaccountsException = new InvalidPayoutSubaccountsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidPayoutSubaccountsException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidPayoutSubaccountsException.ThrowIfContainsErrors();
        }
    }
}