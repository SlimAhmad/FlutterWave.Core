﻿using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalCharge;
using FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave.ExternalPreauthorization;
using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;
using Newtonsoft.Json;
using System.Threading.Tasks;
using static PayloadEncryptor;

namespace FlutterWave.Core.Services.Foundations.FlutterWave.PreauthorizationService
{
    internal partial class PreauthorizationService : IPreauthorizationService
    {
        private readonly IFlutterWaveBroker flutterWaveBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public PreauthorizationService(
            IFlutterWaveBroker flutterWaveBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.flutterWaveBroker = flutterWaveBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<CreateCharge> PostCreateChargeRequestAsync(CreateCharge createCharge, string encryptionKey) =>
        TryCatch(async () =>
        {

            ValidateCreateCharge(createCharge);
            ExternalCreateChargeRequest externalCreateChargeRequest = ConvertToPreauthorizationRequest(createCharge);
            var encryptRequested = JsonConvert.SerializeObject(externalCreateChargeRequest);
            var encrypted = Encrypt(encryptionKey, encryptRequested);
            ExternalEncryptedChargeRequest externalEncryptedKey = ConvertToEncryptedRequest(encrypted);
            ExternalCreateChargeResponse externalCreateChargeResponse = await flutterWaveBroker.PostCreateChargeAsync(
             externalEncryptedKey);
            return ConvertToPreauthorizationResponse(createCharge, externalCreateChargeResponse);
        });

        public ValueTask<CaptureCharge> PostCaptureChargeRequestAsync(string flwRef, CaptureCharge captureCharge) =>
        TryCatch(async () =>
        {
            ValidateCaptureCharge(captureCharge);
            ValidateCaptureChargeString(flwRef);
            ExternalCaptureChargeRequest externalCaptureChargeRequest = ConvertToPreauthorizationRequest(captureCharge);
            ExternalCaptureChargeResponse externalCaptureChargeResponse = await flutterWaveBroker.PostCaptureChargeAsync(
             flwRef, externalCaptureChargeRequest);
            return ConvertToPreauthorizationResponse(captureCharge, externalCaptureChargeResponse);
        });

        public ValueTask<VoidCharge> PostVoidChargeRequestAsync(string flwRef) =>
        TryCatch(async () =>
        {
            ValidateVoidChargeString(flwRef);
            ExternalVoidChargeResponse externalVoidChargeResponse = await flutterWaveBroker.PostVoidChargeAsync(
               flwRef);
            return ConvertToPreauthorizationResponse(externalVoidChargeResponse);
        });

        public ValueTask<CreatePreauthorizationRefund> PostCreateRefundRequestAsync(string flwRef, CreatePreauthorizationRefund createPreauthorizationRefund) =>
        TryCatch(async () =>
        {
            ValidateCreatePreauthorizationRefund(flwRef, createPreauthorizationRefund);
            ExternalCreatePreauthorizationRefundRequest externalCreatePreauthorizationRefundRequest = ConvertToPreauthorizationRequest(createPreauthorizationRefund);
            ExternalCreatePreauthorizationRefundResponse externalCaptureChargeResponse = await flutterWaveBroker.PostCreateRefundAsync(
             flwRef, externalCreatePreauthorizationRefundRequest);
            return ConvertToPreauthorizationResponse(createPreauthorizationRefund, externalCaptureChargeResponse);
        });

        public ValueTask<CapturePayPalCharge> PostCapturePayPalChargeRequestAsync(CapturePayPalCharge capturePayPalCharge) =>
        TryCatch(async () =>
        {
            ValidateCapturePaypalCharge(capturePayPalCharge);
            ExternalCapturePayPalChargeRequest externalCapturePaypalChargeRequest = ConvertToPreauthorizationRequest(capturePayPalCharge);
            ExternalCapturePayPalChargeResponse externalCaptureChargeResponse = await flutterWaveBroker.PostCapturePayPalChargeAsync(
               externalCapturePaypalChargeRequest);
            return ConvertToPreauthorizationResponse(capturePayPalCharge, externalCaptureChargeResponse);
        });

        public ValueTask<VoidPayPalCharge> PostVoidPayPalChargeRequestAsync(string flwRef) =>
        TryCatch(async () =>
        {
            ValidateVoidPayPalChargeString(flwRef);
            ExternalVoidPayPalChargeResponse externalVoidPaypalChargeResponse = await flutterWaveBroker.PostVoidPayPalChargeAsync(
               flwRef);
            return ConvertToPreauthorizationResponse(externalVoidPaypalChargeResponse);
        });


        private ExternalEncryptedChargeRequest ConvertToEncryptedRequest(string encryptedKey)
        {
            return new ExternalEncryptedChargeRequest
            {
                Client = encryptedKey,

            };
        }
        private VoidCharge ConvertToPreauthorizationResponse(ExternalVoidChargeResponse externalVoidChargeResponse)
        {
            return new VoidCharge
            {
                Response = new VoidChargeResponse
                {
                    Message = externalVoidChargeResponse.Message,
                    Data = new VoidChargeResponse.VoidChargeData
                    {
                        AccountId = externalVoidChargeResponse.Data.AccountId,
                        Amount = externalVoidChargeResponse.Data.Amount,
                        FlwRef = externalVoidChargeResponse.Data.FlwRef,
                        Status = externalVoidChargeResponse.Data.Status,
                        ProcessorResponse = externalVoidChargeResponse.Data.ProcessorResponse,
                        Narration = externalVoidChargeResponse.Data.Narration,
                        PaymentType = externalVoidChargeResponse.Data.PaymentType,
                        MerchantFee = externalVoidChargeResponse.Data.MerchantFee,
                        Ip = externalVoidChargeResponse.Data.Ip,
                        AppFee = externalVoidChargeResponse.Data.AppFee,
                        CreatedAt = externalVoidChargeResponse.Data.CreatedAt,
                        Currency = externalVoidChargeResponse.Data.Currency,
                        AuthModel = externalVoidChargeResponse.Data.AuthModel,
                        Customer = new VoidChargeResponse.Customer
                        {
                            Id = externalVoidChargeResponse.Data.Customer.Id,
                            CreatedAt = externalVoidChargeResponse.Data.Customer.CreatedAt,
                            Email = externalVoidChargeResponse.Data.Customer.Email,
                            Name = externalVoidChargeResponse.Data.Customer.Name,
                            PhoneNumber = externalVoidChargeResponse.Data.Customer.PhoneNumber
                        },
                        TxRef = externalVoidChargeResponse.Data.TxRef,
                        Card = new VoidChargeResponse.Card
                        {
                            Country = externalVoidChargeResponse.Data.Card.Country,
                            Expiry = externalVoidChargeResponse.Data.Card.Expiry,
                            First6digits = externalVoidChargeResponse.Data.Card.First6digits,
                            Issuer = externalVoidChargeResponse.Data.Card.Issuer,
                            Last4digits = externalVoidChargeResponse.Data.Card.Last4digits,
                            Type = externalVoidChargeResponse.Data.Card.Type
                        },
                        Id = externalVoidChargeResponse.Data.Id,
                        ChargedAmount = externalVoidChargeResponse.Data.ChargedAmount,
                        ChargeType = externalVoidChargeResponse.Data.ChargeType,
                        DeviceFingerprint = externalVoidChargeResponse.Data.DeviceFingerprint,
                        FraudStatus = externalVoidChargeResponse.Data.FraudStatus,
                        OrderId = externalVoidChargeResponse.Data.OrderId


                    },
                    Status = externalVoidChargeResponse.Status,


                }

            };
        }

        private ExternalCreateChargeRequest ConvertToPreauthorizationRequest(CreateCharge createCharge)
        {
            return new ExternalCreateChargeRequest
            {
                Amount = createCharge.Request.Amount,
                Currency = createCharge.Request.Currency,
                Email = createCharge.Request.Email,
                CardNumber = createCharge.Request.CardNumber,
                ClientIp = createCharge.Request.ClientIp,
                DeviceFingerprint = createCharge.Request.DeviceFingerprint,
                PaymentPlan = createCharge.Request.PaymentPlan,
                UseSecureAuth = createCharge.Request.UseSecureAuth,
                Authorization = new ExternalCreateChargeRequest.ExternalAuthorizationData
                {
                    Address = createCharge.Request.Authorization.Address,
                    City = createCharge.Request.Authorization.City,
                    Country = createCharge.Request.Authorization.Country,
                    Mode = createCharge.Request.Authorization.Mode,
                    Pin = createCharge.Request.Authorization.Pin,
                    State = createCharge.Request.Authorization.State,
                    ZipCode = createCharge.Request.Authorization.ZipCode,
                },
                Cvv = createCharge.Request.Cvv,
                ExpiryMonth = createCharge.Request.ExpiryMonth,
                ExpiryYear = createCharge.Request.ExpiryYear,
                FullName = createCharge.Request.FullName,
                Meta = new ExternalCreateChargeRequest.ExternalMeta
                {
                    SideNote = createCharge.Request.Meta.SideNote,
                    FlightId = createCharge.Request.Meta.FlightId
                },
                Preauthorize = createCharge.Request.Preauthorize,
                RedirectUrl = createCharge.Request.RedirectUrl,
                TxRef = createCharge.Request.TxRef
            };
        }
        private CreateCharge ConvertToPreauthorizationResponse(CreateCharge createCharge, ExternalCreateChargeResponse externalCreateChargeResponse)
        {

            createCharge.Response = new CreateChargeResponse
            {

                Data = externalCreateChargeResponse.Data,
                Message = externalCreateChargeResponse.Message,
                Status = externalCreateChargeResponse.Status,

            };
            return createCharge;

        }

        private ExternalCaptureChargeRequest ConvertToPreauthorizationRequest(CaptureCharge captureCharge)
        {
            return new ExternalCaptureChargeRequest
            {
                Amount = captureCharge.Request.Amount,
            };
        }
        private CaptureCharge ConvertToPreauthorizationResponse(CaptureCharge captureCharge, ExternalCaptureChargeResponse externalCaptureChargeResponse)
        {

            captureCharge.Response = new CaptureChargeResponse
            {
                Message = externalCaptureChargeResponse.Message,
                Data = new CaptureChargeResponse.CaptureChargeData
                {
                    Currency = externalCaptureChargeResponse.Data.Currency,
                    TxRef = externalCaptureChargeResponse.Data.TxRef,
                    AccountId = externalCaptureChargeResponse.Data.AccountId,
                    Amount = externalCaptureChargeResponse.Data.Amount,
                    AppFee = externalCaptureChargeResponse.Data.AppFee,
                    AuthModel = externalCaptureChargeResponse.Data.AuthModel,
                    AuthUrl = externalCaptureChargeResponse.Data.AuthUrl,
                    DeviceFingerprint = externalCaptureChargeResponse.Data.DeviceFingerprint,
                    Status = externalCaptureChargeResponse.Data.Status,
                    FlwRef = externalCaptureChargeResponse.Data.FlwRef,
                    FraudStatus = externalCaptureChargeResponse.Data.FraudStatus,
                    Id = externalCaptureChargeResponse.Data.Id,
                    Ip = externalCaptureChargeResponse.Data.Ip,
                    MerchantFee = externalCaptureChargeResponse.Data.MerchantFee,
                    Narration = externalCaptureChargeResponse.Data.Narration,
                    PaymentType = externalCaptureChargeResponse.Data.PaymentType,
                    Plan = externalCaptureChargeResponse.Data.Plan,
                    ProcessorResponse = externalCaptureChargeResponse.Data.ProcessorResponse,
                    Card = new CaptureChargeResponse.Card
                    {
                        Country = externalCaptureChargeResponse.Data.Card.Country,
                        Expiry = externalCaptureChargeResponse.Data.Card.Expiry,
                        First6digits = externalCaptureChargeResponse.Data.Card.First6digits,
                        Issuer = externalCaptureChargeResponse.Data.Card.Issuer,
                        Last4digits = externalCaptureChargeResponse.Data.Card.Last4digits,
                        Type = externalCaptureChargeResponse.Data.Card.Type
                    },
                    ChargedAmount = externalCaptureChargeResponse.Data.ChargedAmount,
                    ChargeType = externalCaptureChargeResponse.Data.ChargeType,
                    CreatedAt = externalCaptureChargeResponse.Data.CreatedAt,
                    Customer = new CaptureChargeResponse.Customer
                    {
                        CreatedAt = externalCaptureChargeResponse.Data.Customer.CreatedAt,
                        Email = externalCaptureChargeResponse.Data.Customer.Email,
                        Id = externalCaptureChargeResponse.Data.Customer.Id,
                        Name = externalCaptureChargeResponse.Data.Customer.Name,
                        PhoneNumber = externalCaptureChargeResponse.Data.Customer.PhoneNumber
                    }

                },

                Status = externalCaptureChargeResponse.Status,


            };
            return captureCharge;

        }

        private ExternalCapturePayPalChargeRequest ConvertToPreauthorizationRequest(CapturePayPalCharge capturePayPalCharge)
        {
            return new ExternalCapturePayPalChargeRequest
            {
                FlwRef = capturePayPalCharge.Request.FlwRef,

            };
        }
        private CapturePayPalCharge ConvertToPreauthorizationResponse(CapturePayPalCharge capturePayPalCharge, ExternalCapturePayPalChargeResponse externalCapturePaypalChargeResponse)
        {

            capturePayPalCharge.Response = new CapturePaypalChargeResponse
            {
                Message = externalCapturePaypalChargeResponse.Message,
                Data = new CapturePaypalChargeResponse.CapturePaypalChargeData
                {
                    Customer = new CapturePaypalChargeResponse.Customer
                    {
                        PhoneNumber = externalCapturePaypalChargeResponse.Data.Customer.PhoneNumber,
                        CreatedAt = externalCapturePaypalChargeResponse.Data.Customer.CreatedAt,
                        Email = externalCapturePaypalChargeResponse.Data.Customer.Email,
                        Id = externalCapturePaypalChargeResponse.Data.Customer.Id,
                        Name = externalCapturePaypalChargeResponse.Data.Customer.Name
                    },
                    Currency = externalCapturePaypalChargeResponse.Data.Currency,
                    TxRef = externalCapturePaypalChargeResponse.Data.TxRef,
                    AccountId = externalCapturePaypalChargeResponse.Data.AccountId,
                    Amount = externalCapturePaypalChargeResponse.Data.Amount,
                    AppFee = externalCapturePaypalChargeResponse.Data.AppFee,
                    AuthModel = externalCapturePaypalChargeResponse.Data.AuthModel,
                    AuthUrl = externalCapturePaypalChargeResponse.Data.AuthUrl,
                    ChargedAmount = externalCapturePaypalChargeResponse.Data.ChargedAmount,
                    ChargeType = externalCapturePaypalChargeResponse.Data.ChargeType,
                    CreatedAt = externalCapturePaypalChargeResponse.Data.CreatedAt,
                    Status = externalCapturePaypalChargeResponse.Data.Status,
                    Id = externalCapturePaypalChargeResponse.Data.Id,
                    DeviceFingerprint = externalCapturePaypalChargeResponse.Data.DeviceFingerprint,
                    FlwRef = externalCapturePaypalChargeResponse.Data.FlwRef,
                    FraudStatus = externalCapturePaypalChargeResponse.Data.FraudStatus,
                    Ip = externalCapturePaypalChargeResponse.Data.Ip,
                    MerchantFee = externalCapturePaypalChargeResponse.Data.MerchantFee,
                    Narration = externalCapturePaypalChargeResponse.Data.Narration,
                    PaymentType = externalCapturePaypalChargeResponse.Data.PaymentType,
                    ProcessorResponse = externalCapturePaypalChargeResponse.Data.ProcessorResponse
                },
                Status = externalCapturePaypalChargeResponse.Status,


            };
            return capturePayPalCharge;

        }

        private ExternalCreatePreauthorizationRefundRequest ConvertToPreauthorizationRequest(CreatePreauthorizationRefund createPreauthorizationRefund)
        {
            return new ExternalCreatePreauthorizationRefundRequest
            {
                Amount = createPreauthorizationRefund.Request.Amount,
            };
        }
        private CreatePreauthorizationRefund ConvertToPreauthorizationResponse(CreatePreauthorizationRefund captureCharge,
            ExternalCreatePreauthorizationRefundResponse externalCreatePreauthorizationRefundResponse)
        {

            captureCharge.Response = new CreatePreauthorizationRefundResponse
            {
                Message = externalCreatePreauthorizationRefundResponse.Message,
                Data = new CreatePreauthorizationRefundResponse.CreatePreauthorizationRefundData
                {
                    Currency = externalCreatePreauthorizationRefundResponse.Data.Currency,
                    TxRef = externalCreatePreauthorizationRefundResponse.Data.TxRef,
                    AccountId = externalCreatePreauthorizationRefundResponse.Data.AccountId,
                    Amount = externalCreatePreauthorizationRefundResponse.Data.Amount,
                    AppFee = externalCreatePreauthorizationRefundResponse.Data.AppFee,
                    AuthModel = externalCreatePreauthorizationRefundResponse.Data.AuthModel,
                    AuthUrl = externalCreatePreauthorizationRefundResponse.Data.AuthUrl,
                    Card = new CreatePreauthorizationRefundResponse.Card
                    {
                        Country = externalCreatePreauthorizationRefundResponse.Data.Card.Country,
                        Expiry = externalCreatePreauthorizationRefundResponse.Data.Card.Expiry,
                        First6digits = externalCreatePreauthorizationRefundResponse.Data.Card.First6digits,
                        Issuer = externalCreatePreauthorizationRefundResponse.Data.Card.Issuer,
                        Last4digits = externalCreatePreauthorizationRefundResponse.Data.Card.Last4digits,
                        Type = externalCreatePreauthorizationRefundResponse.Data.Card.Type,

                    },
                    ChargedAmount = externalCreatePreauthorizationRefundResponse.Data.ChargedAmount,
                    ChargeType = externalCreatePreauthorizationRefundResponse.Data.ChargeType,
                    CreatedAt = externalCreatePreauthorizationRefundResponse.Data.CreatedAt,
                    DeviceFingerprint = externalCreatePreauthorizationRefundResponse.Data.DeviceFingerprint,
                    FlwRef = externalCreatePreauthorizationRefundResponse.Data.FlwRef,
                    FraudStatus = externalCreatePreauthorizationRefundResponse.Data.FraudStatus,
                    Id = externalCreatePreauthorizationRefundResponse.Data.Id,
                    Ip = externalCreatePreauthorizationRefundResponse.Data.Ip,
                    MerchantFee = externalCreatePreauthorizationRefundResponse.Data.MerchantFee,
                    Narration = externalCreatePreauthorizationRefundResponse.Data.Narration,
                    PaymentType = externalCreatePreauthorizationRefundResponse.Data.PaymentType,
                    ProcessorResponse = externalCreatePreauthorizationRefundResponse.Data.ProcessorResponse,
                    Status = externalCreatePreauthorizationRefundResponse.Data.Status,
                    Customer = new CreatePreauthorizationRefundResponse.Customer
                    {
                        CreatedAt = externalCreatePreauthorizationRefundResponse.Data.Customer.CreatedAt,
                        Email = externalCreatePreauthorizationRefundResponse.Data.Customer.Email,
                        Id = externalCreatePreauthorizationRefundResponse.Data.Customer.Id,
                        AccountId = externalCreatePreauthorizationRefundResponse.Data.Customer.AccountId,
                        Customertoken = externalCreatePreauthorizationRefundResponse.Data.Customer.Customertoken,
                        DeletedAt = externalCreatePreauthorizationRefundResponse.Data.Customer.DeletedAt,
                        FullName = externalCreatePreauthorizationRefundResponse.Data.Customer.FullName,
                        Phone = externalCreatePreauthorizationRefundResponse.Data.Customer.Phone,
                        UpdatedAt = externalCreatePreauthorizationRefundResponse.Data.Customer.UpdatedAt
                    }
                },
                Status = externalCreatePreauthorizationRefundResponse.Status,


            };
            return captureCharge;

        }


        private VoidPayPalCharge ConvertToPreauthorizationResponse(ExternalVoidPayPalChargeResponse externalVoidPayPalChargeResponse)
        {
            return new VoidPayPalCharge
            {



                Response = new VoidPayPalChargeResponse
                {
                    Message = externalVoidPayPalChargeResponse.Message,
                    Data = new VoidPayPalChargeResponse.VoidPaypalChargeData
                    {
                        Currency = externalVoidPayPalChargeResponse.Data.Currency,
                        TxRef = externalVoidPayPalChargeResponse.Data.TxRef,
                        AccountId = externalVoidPayPalChargeResponse.Data.AccountId,
                        Amount = externalVoidPayPalChargeResponse.Data.Amount,
                        AppFee = externalVoidPayPalChargeResponse.Data.AppFee,
                        AuthModel = externalVoidPayPalChargeResponse.Data.AuthModel,
                        AuthUrl = externalVoidPayPalChargeResponse.Data.AuthUrl,
                        ChargedAmount = externalVoidPayPalChargeResponse.Data.ChargedAmount,
                        ChargeType = externalVoidPayPalChargeResponse.Data.ChargeType,
                        CreatedAt = externalVoidPayPalChargeResponse.Data.CreatedAt,
                        DeviceFingerprint = externalVoidPayPalChargeResponse.Data.DeviceFingerprint,
                        FlwRef = externalVoidPayPalChargeResponse.Data.FlwRef,
                        FraudStatus = externalVoidPayPalChargeResponse.Data.FraudStatus,
                        Id = externalVoidPayPalChargeResponse.Data.Id,
                        Ip = externalVoidPayPalChargeResponse.Data.Ip,
                        MerchantFee = externalVoidPayPalChargeResponse.Data.MerchantFee,
                        Narration = externalVoidPayPalChargeResponse.Data.Narration,
                        PaymentType = externalVoidPayPalChargeResponse.Data.PaymentType,
                        ProcessorResponse = externalVoidPayPalChargeResponse.Data.ProcessorResponse,
                        Status = externalVoidPayPalChargeResponse.Data.Status,

                        Customer = new VoidPayPalChargeResponse.Customer
                        {
                            CreatedAt = externalVoidPayPalChargeResponse.Data.Customer.CreatedAt,
                            Email = externalVoidPayPalChargeResponse.Data.Customer.Email,
                            Id = externalVoidPayPalChargeResponse.Data.Customer.Id,
                            Name = externalVoidPayPalChargeResponse.Data.Customer.Name,
                            PhoneNumber = externalVoidPayPalChargeResponse.Data.Customer.PhoneNumber,

                        },


                    },

                    Status = externalVoidPayPalChargeResponse.Status,
                }

            };
        }

    }


}




