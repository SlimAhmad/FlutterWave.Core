﻿using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Preauthorization;

namespace FlutterWave.Core.Tests.Integration.API.Preauthorization
{
    public partial class PreauthorizationApiTests
    {
        [Fact(Skip = "This test is only for releases")]
        public async Task ShouldPostVoidPayPalChargeAsync()
        {

            // given
            var flwRef = "qwer";

            // . when
            VoidPayPalCharge responseAIModels =
                await this.flutterWaveClient.Preauthorization.VoidPayPalChargeAsync(flwRef);

            // then
            Assert.NotNull(responseAIModels);
        }
    }
}
