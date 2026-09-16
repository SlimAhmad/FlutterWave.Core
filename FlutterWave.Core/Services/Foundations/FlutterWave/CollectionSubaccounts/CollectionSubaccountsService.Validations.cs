using FlutterWave.Core.Models.Services.Foundations.FlutterWave.CollectionSubaccounts;
using System;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.CollectionSubaccountsService
{
    internal partial class CollectionSubaccountsService
    {


        private static void ValidateCreateCollectionSubaccount(CreateCollectionSubaccount createCollectionSubaccount)
        {
            ValidateCreateCollectionSubaccountNotNull(createCollectionSubaccount);
            ValidateCreateCollectionSubaccountRequestNotNull(createCollectionSubaccount.Request);
            Validate(
                (Rule: IsInvalid(createCollectionSubaccount), Parameter: nameof(createCollectionSubaccount)));

            Validate(
                (Rule: IsInvalid(createCollectionSubaccount.Request.BusinessMobile), Parameter: nameof(CreateCollectionSubaccountRequest.BusinessMobile)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.SplitValue), Parameter: nameof(CreateCollectionSubaccountRequest.SplitValue)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.BusinessName), Parameter: nameof(CreateCollectionSubaccountRequest.BusinessName)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.AccountNumber), Parameter: nameof(CreateCollectionSubaccountRequest.AccountNumber)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.AccountBank), Parameter: nameof(CreateCollectionSubaccountRequest.AccountBank)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.BusinessContact), Parameter: nameof(CreateCollectionSubaccountRequest.BusinessContact)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.BusinessContactMobile), Parameter: nameof(CreateCollectionSubaccountRequest.BusinessContactMobile)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.BusinessEmail), Parameter: nameof(CreateCollectionSubaccountRequest.BusinessEmail)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.Country), Parameter: nameof(CreateCollectionSubaccountRequest.Country)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.Meta), Parameter: nameof(CreateCollectionSubaccountRequest.Meta)),
                (Rule: IsInvalid(createCollectionSubaccount.Request.SplitType), Parameter: nameof(CreateCollectionSubaccountRequest.SplitType))

                );

        }

        private static void ValidateUpdateSubaccount(int subaccountId, UpdateSubaccount updateSubaccount)
        {
            ValidateUpdateSubaccountNotNull(updateSubaccount);
            ValidateUpdateSubaccountRequestNotNull(updateSubaccount.Request);
            Validate(
                (Rule: IsInvalid(updateSubaccount), Parameter: nameof(updateSubaccount)));

            Validate(
                (Rule: IsInvalid(updateSubaccount.Request.SplitValue), Parameter: nameof(UpdateSubaccountRequest.SplitValue)),
                (Rule: IsInvalid(subaccountId), Parameter: nameof(UpdateSubaccount))
                );

        }



        private static void ValidateUpdateSubaccountRequestNotNull(UpdateSubaccountRequest updateSubaccountRequest)
        {
            Validate((Rule: IsInvalid(updateSubaccountRequest), Parameter: nameof(UpdateSubaccountRequest)));
        }
        private static void ValidateCreateCollectionSubaccountRequestNotNull(CreateCollectionSubaccountRequest createCollectionSubaccountRequest)
        {
            Validate((Rule: IsInvalid(createCollectionSubaccountRequest), Parameter: nameof(CreateCollectionSubaccountRequest)));
        }



        private static void ValidateCreateCollectionSubaccountNotNull(CreateCollectionSubaccount createCollectionSubaccount)
        {
            if (createCollectionSubaccount is null)
            {
                throw new NullCollectionSubaccountsException();
            }
        }





        private static void ValidateUpdateSubaccountNotNull(UpdateSubaccount updateSubaccount)
        {
            if (updateSubaccount is null)
            {
                throw new NullCollectionSubaccountsException();
            }
        }

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };

        private static void ValidateDeleteSubaccountId(int id) =>
            Validate((Rule: IsInvalid(id), Parameter: nameof(DeleteSubaccount)));

        private static void ValidateFetchSubaccountId(int id) =>
           Validate((Rule: IsInvalid(id), Parameter: nameof(FetchSubaccount)));


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

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidCollectionSubaccountsException = new InvalidCollectionSubaccountsException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidCollectionSubaccountsException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidCollectionSubaccountsException.ThrowIfContainsErrors();
        }
    }
}