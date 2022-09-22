using AuctionAPI.Services;
using AuctionAPI.WebInterface;
using Microsoft.AspNetCore.Mvc;

namespace AuctionAPI.Controllers
{
    [Route("api/v1/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public LoginResponse Login([FromBody] LoginRequest request)
        {
            var response = _authService.Login(request.ToData());
            return response.ToResponse();
        }

        [HttpPost("forgot-password")]
        public ForgotPasswordResponse ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var response = _authService.ForgotPassword(request.ToData());
            return response.ToResponse();
        }

        [HttpPost("reset-password")]
        public ResetPasswordResponse ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var response = _authService.ResetPassword(request.ToData());
            return response.ToResponse();
        }

        [HttpPost("change-password")]
        public ChangePasswordResponse ChangePassword([FromBody] ChangePasswordRequest request)
        {
            var response = _authService.ChangePassword(request.ToData());
            return response.ToResponse();
        }

        [HttpPost("verify-email")]
        public VerifyEmailResponse VerifyEmail([FromBody] VerifyEmailRequest request)
        {
            var response = _authService.VerifyEmail(request.ToData());
            return response.ToResponse();
        }

        [HttpPost("resend-verification-email")]
        public ResendVerificationEmailResponse ResendVerificationEmail([FromBody] ResendVerificationEmailRequest request)
        {
            var response = _authService.ResendVerificationEmail(request.ToData());
            return response.ToResponse();
        }
    }
}
