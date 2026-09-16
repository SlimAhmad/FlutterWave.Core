using FluentAssertions;
using FlutterWave.Core.Webhooks;
using FlutterWave.Core.Webhooks.Events;
using Newtonsoft.Json;

namespace FlutterWave.Core.Tests.Unit.Webhooks
{
    public class WebhookEventDeserializationTests
    {
        [Fact]
        public void ShouldDeserializeChargeCompletedWebhookEvent()
        {
            // given
            string json = @"{
                ""event"": ""charge.completed"",
                ""data"": {
                    ""id"": 285959875,
                    ""tx_ref"": ""Links-616626414629"",
                    ""flw_ref"": ""PeterEkene/FLW270177170"",
                    ""device_fingerprint"": ""a42937f4a73ce8bb8b8df14e63a2df31"",
                    ""amount"": 100,
                    ""currency"": ""NGN"",
                    ""charged_amount"": 100,
                    ""app_fee"": 1.4,
                    ""merchant_fee"": 0,
                    ""processor_response"": ""Approved by Financial Institution"",
                    ""auth_model"": ""PIN"",
                    ""ip"": ""197.210.64.96"",
                    ""narration"": ""CARD Transaction "",
                    ""status"": ""successful"",
                    ""payment_type"": ""card"",
                    ""created_at"": ""2020-07-06T19:17:04.000Z"",
                    ""account_id"": 17321,
                    ""customer"": {
                        ""id"": 215604089,
                        ""name"": ""Yemi Desola"",
                        ""phone_number"": null,
                        ""email"": ""user@gmail.com"",
                        ""created_at"": ""2020-07-06T19:17:04.000Z""
                    },
                    ""card"": {
                        ""first_6digits"": ""123456"",
                        ""last_4digits"": ""7889"",
                        ""issuer"": ""VERVE FIRST CITY MONUMENT BANK PLC"",
                        ""country"": ""NG"",
                        ""type"": ""VERVE"",
                        ""expiry"": ""02/23""
                    }
                }
            }";

            // when
            WebhookEvent<ChargeCompletedWebhookEventData> actualEvent =
                JsonConvert.DeserializeObject<WebhookEvent<ChargeCompletedWebhookEventData>>(json);

            // then
            actualEvent.Event.Should().Be("charge.completed");
            actualEvent.Data.Id.Should().Be(285959875);
            actualEvent.Data.TxRef.Should().Be("Links-616626414629");
            actualEvent.Data.Status.Should().Be("successful");
            actualEvent.Data.Amount.Should().Be(100);
            actualEvent.Data.Customer.Email.Should().Be("user@gmail.com");
            actualEvent.Data.Card.Last4digits.Should().Be("7889");
        }

        [Fact]
        public void ShouldDeserializeTransferCompletedWebhookEvent()
        {
            // given
            string json = @"{
                ""event"": ""transfer.completed"",
                ""event.type"": ""Transfer"",
                ""data"": {
                    ""id"": 33286,
                    ""account_number"": ""0690000033"",
                    ""bank_name"": ""ACCESS BANK NIGERIA"",
                    ""bank_code"": ""044"",
                    ""fullname"": ""Bale Gary"",
                    ""created_at"": ""2020-04-14T16:39:17.000Z"",
                    ""currency"": ""NGN"",
                    ""debit_currency"": ""NGN"",
                    ""amount"": 30020,
                    ""fee"": 26.875,
                    ""status"": ""SUCCESSFUL"",
                    ""reference"": ""a0a827b1eca65311_PMCKDU_5"",
                    ""meta"": null,
                    ""narration"": ""lolololo"",
                    ""approver"": null,
                    ""complete_message"": ""Successful"",
                    ""requires_approval"": 0,
                    ""is_approved"": 1
                }
            }";

            // when
            WebhookEvent<TransferCompletedWebhookEventData> actualEvent =
                JsonConvert.DeserializeObject<WebhookEvent<TransferCompletedWebhookEventData>>(json);

            // then
            actualEvent.Event.Should().Be("transfer.completed");
            actualEvent.EventType.Should().Be("Transfer");
            actualEvent.Data.Status.Should().Be("SUCCESSFUL");
            actualEvent.Data.Amount.Should().Be("30020");
            actualEvent.Data.Reference.Should().Be("a0a827b1eca65311_PMCKDU_5");
        }

        [Fact]
        public void ShouldDeserializeSubscriptionCancelledWebhookEvent()
        {
            // given
            string json = @"{
                ""event"": ""subscription.cancelled"",
                ""data"": {
                    ""status"": ""deactivated"",
                    ""currency"": ""NGN"",
                    ""amount"": 200,
                    ""customer"": {
                        ""email"": ""adeoyesamuel14@gmail.com"",
                        ""full_name"": ""Anonymous customer""
                    },
                    ""plan"": {
                        ""id"": 10944,
                        ""name"": ""month"",
                        ""amount"": 200,
                        ""currency"": ""NGN"",
                        ""interval"": ""monthly"",
                        ""duration"": 1,
                        ""status"": ""cancel"",
                        ""date_created"": ""2021-04-19T10:52:06.000Z""
                    }
                }
            }";

            // when
            WebhookEvent<SubscriptionCancelledWebhookEventData> actualEvent =
                JsonConvert.DeserializeObject<WebhookEvent<SubscriptionCancelledWebhookEventData>>(json);

            // then
            actualEvent.Event.Should().Be("subscription.cancelled");
            actualEvent.Data.Status.Should().Be("deactivated");
            actualEvent.Data.Customer.Email.Should().Be("adeoyesamuel14@gmail.com");
            actualEvent.Data.Plan.Name.Should().Be("month");
            actualEvent.Data.Plan.Interval.Should().Be("monthly");
        }

        [Fact]
        public void ShouldDeserializeVirtualCardDebitWebhookEvent()
        {
            // given
            string json = @"{
                ""TransactionId"": ""9998d447-9159-4591-9661-aa7f1458d91b"",
                ""MerchantName"": ""Flutterwave"",
                ""Description"": ""CHARGE"",
                ""Status"": ""Successful"",
                ""Balance"": 4.7925,
                ""Amount"": 0.2075,
                ""Type"": ""Debit"",
                ""CardId"": ""ccb40595-eaad-4a8f-bb9a-74ae245b12bb"",
                ""MaskedPan"": ""428803******4329""
            }";

            // when
            VirtualCardDebitWebhookEvent actualEvent =
                JsonConvert.DeserializeObject<VirtualCardDebitWebhookEvent>(json);

            // then
            actualEvent.TransactionId.Should().Be("9998d447-9159-4591-9661-aa7f1458d91b");
            actualEvent.Status.Should().Be("Successful");
            actualEvent.Amount.Should().Be(0.2075m);
            actualEvent.MaskedPan.Should().Be("428803******4329");
        }

        [Fact]
        public void ShouldDeserializeVirtualCardOtpWebhookEvent()
        {
            // given
            string json = @"{
                ""TransactionId"": null,
                ""MerchantName"": null,
                ""Description"": ""OTP"",
                ""Status"": ""Pending Auth"",
                ""Balance"": 0,
                ""Amount"": 0,
                ""Type"": ""Notification"",
                ""CardId"": ""731a7d58-9293-4b50-b1f4-f2e0d56f3f4e"",
                ""MaskedPan"": ""536898*******9526"",
                ""Otp"": ""383290""
            }";

            // when
            VirtualCardOtpWebhookEvent actualEvent =
                JsonConvert.DeserializeObject<VirtualCardOtpWebhookEvent>(json);

            // then
            actualEvent.Description.Should().Be("OTP");
            actualEvent.Status.Should().Be("Pending Auth");
            actualEvent.Otp.Should().Be("383290");
        }

        [Fact]
        public void ShouldDeserializeRefundWebhookEvent()
        {
            // given
            string json = @"{
                ""id"": 99025,
                ""AmountRefunded"": 100,
                ""status"": ""completed"",
                ""FlwRef"": ""4687213286"",
                ""destination"": ""payment_source"",
                ""comments"": null,
                ""settlement_id"": ""142228"",
                ""meta"": ""{\""source\"":\""ledgerbalance\""}"",
                ""createdAt"": ""2026-01-30T08:35:45.000Z"",
                ""updatedAt"": ""2026-01-30T08:35:46.000Z"",
                ""deletedAt"": null,
                ""walletId"": 684098,
                ""AccountId"": 169295,
                ""TransactionId"": 9231836
            }";

            // when
            RefundWebhookEvent actualEvent =
                JsonConvert.DeserializeObject<RefundWebhookEvent>(json);

            // then
            actualEvent.Id.Should().Be(99025);
            actualEvent.AmountRefunded.Should().Be(100);
            actualEvent.Status.Should().Be("completed");
            actualEvent.FlwRef.Should().Be("4687213286");
            actualEvent.TransactionId.Should().Be(9231836);
        }

        [Fact]
        public void ShouldDeserializeBvnCompletedWebhookEvent()
        {
            // given
            string json = @"{
                ""event"": ""bvn.completed"",
                ""event.type"": ""BVN"",
                ""data"": {
                    ""id"": 18,
                    ""reference"": ""FLW441BD872AEBB28BD53B239"",
                    ""status"": ""COMPLETED"",
                    ""firstname"": ""LYRA"",
                    ""lastname"": ""Balacqua"",
                    ""callback_url"": ""https://webhook.site/939e641f-e477-4b1d-af3a-1ee9bbbd1181"",
                    ""AccountId"": 35308,
                    ""bvn_data"": {
                        ""dateOfBirth"": ""199x-05-xxT23:00:00Z"",
                        ""email"": ""test-user@example.com"",
                        ""gender"": ""Male"",
                        ""surname"": ""Balacqua""
                    },
                    ""createdAt"": ""2023-04-13T23:02:23.000Z"",
                    ""updatedAt"": ""2023-04-13T23:06:18.000Z"",
                    ""deletedAt"": null
                }
            }";

            // when
            WebhookEvent<BvnCompletedWebhookEventData> actualEvent =
                JsonConvert.DeserializeObject<WebhookEvent<BvnCompletedWebhookEventData>>(json);

            // then
            actualEvent.Event.Should().Be("bvn.completed");
            actualEvent.Data.Status.Should().Be("COMPLETED");
            actualEvent.Data.BvnData.Gender.Should().Be("Male");
            actualEvent.Data.BvnData.Surname.Should().Be("Balacqua");
        }

        [Fact]
        public void ShouldDeserializeSingleBillPaymentStatusWebhookEvent()
        {
            // given
            string json = @"{
                ""event"": ""singlebillpayment.status"",
                ""event.type"": ""SingleBillPayment"",
                ""data"": {
                    ""customer"": ""+2347065657658"",
                    ""amount"": 200,
                    ""network"": ""MTN"",
                    ""tx_ref"": ""CF-FLYAPI-20240604022555817834333"",
                    ""flw_ref"": ""BPUSSD17175111565077679855"",
                    ""batch_reference"": null,
                    ""customer_reference"": ""test-ref-kuf-01"",
                    ""status"": ""success"",
                    ""message"": ""Bill Payment was completed successfully"",
                    ""reference"": null
                }
            }";

            // when
            WebhookEvent<SingleBillPaymentStatusWebhookEventData> actualEvent =
                JsonConvert.DeserializeObject<WebhookEvent<SingleBillPaymentStatusWebhookEventData>>(json);

            // then
            actualEvent.Event.Should().Be("singlebillpayment.status");
            actualEvent.EventType.Should().Be("SingleBillPayment");
            actualEvent.Data.Status.Should().Be("success");
            actualEvent.Data.Network.Should().Be("MTN");
            actualEvent.Data.Customer.Should().Be("+2347065657658");
        }
    }
}
