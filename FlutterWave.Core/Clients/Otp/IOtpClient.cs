using FlutterWave.Core.Models.Services.Foundations.FlutterWave.Otp;
using System.Threading.Tasks;

namespace FlutterWave.Core.Clients.OTP
{
    public interface IOtpClient
    {
        /// <exception cref="OtpClientValidationException" />
        /// <exception cref="OtpClientDependencyException" />
        /// <exception cref="OtpClientServiceException" />
        ValueTask<CreateOtp> CreateOtpAsync(
        CreateOtp otp);


        ValueTask<ValidateOtp> ValidateOtpAsync(
          string otpReference, ValidateOtp otp);

    }
}
