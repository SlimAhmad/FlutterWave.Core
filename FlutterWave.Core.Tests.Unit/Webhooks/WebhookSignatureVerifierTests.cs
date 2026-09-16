using FluentAssertions;
using FlutterWave.Core.Webhooks;

namespace FlutterWave.Core.Tests.Unit.Webhooks
{
    public class WebhookSignatureVerifierTests
    {
        [Fact]
        public void ShouldReturnTrueWhenSecretHashMatchesHeaderValue()
        {
            // given
            string secretHash = "my-super-secret-hash";
            string verifHashHeaderValue = "my-super-secret-hash";

            // when
            bool actualResult = WebhookSignatureVerifier.IsValid(secretHash, verifHashHeaderValue);

            // then
            actualResult.Should().BeTrue();
        }

        [Theory]
        [InlineData("my-super-secret-hash", "a-different-hash")]
        [InlineData("my-super-secret-hash", "my-super-secret-has")]
        [InlineData("my-super-secret-hash", "MY-SUPER-SECRET-HASH")]
        public void ShouldReturnFalseWhenSecretHashDoesNotMatchHeaderValue(
            string secretHash, string verifHashHeaderValue)
        {
            // when
            bool actualResult = WebhookSignatureVerifier.IsValid(secretHash, verifHashHeaderValue);

            // then
            actualResult.Should().BeFalse();
        }

        [Theory]
        [InlineData(null, "some-hash")]
        [InlineData("", "some-hash")]
        [InlineData("some-hash", null)]
        [InlineData("some-hash", "")]
        [InlineData(null, null)]
        [InlineData("", "")]
        public void ShouldReturnFalseWhenEitherValueIsNullOrEmpty(
            string secretHash, string verifHashHeaderValue)
        {
            // when
            bool actualResult = WebhookSignatureVerifier.IsValid(secretHash, verifHashHeaderValue);

            // then
            actualResult.Should().BeFalse();
        }
    }
}
