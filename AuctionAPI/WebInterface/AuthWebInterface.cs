using AuctionAPI.Dto;

namespace AuctionAPI.WebInterface
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginData ToData()
        {
            return new LoginData
            {
                Email = Email,
                Password = Password
            };
        }
    }

    public class LoginResponse
    {
        public string Message { get; set; }
        public string Token { get; set; }
    }

    public static class LoginStatusExtensions
    {
        public static LoginResponse ToResponse(this LoginStatus status)
        {
            return new LoginResponse
            {
                Message = status.Message,
                Token = status.Token
            };
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }

        public ForgotPasswordData ToData()
        {
            return new ForgotPasswordData
            {
                Email = Email
            };
        }
    }

    public class ForgotPasswordResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public static class ForgotPasswordStatusExtensions
    {
        public static ForgotPasswordResponse ToResponse(this ForgotPasswordStatus status)
        {
            return new ForgotPasswordResponse
            {
                Success = status.Success,
                Message = status.Message
            };
        }
    }

    public class ResetPasswordRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }

        public ResetPasswordData ToData()
        {
            return new ResetPasswordData
            {
                Email = Email,
                Token = Token,
                Password = Password
            };
        }
    }

    public class ResetPasswordResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public static class ResetPasswordStatusExtensions
    {
        public static ResetPasswordResponse ToResponse(this ResetPasswordStatus status)
        {
            return new ResetPasswordResponse
            {
                Success = status.Success,
                Message = status.Message
            };
        }
    }

    public class ChangePasswordRequest
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public ChangePasswordData ToData()
        {
            return new ChangePasswordData
            {
                Email = Email,
                OldPassword = OldPassword,
                NewPassword = NewPassword
            };
        }
    }

    public class ChangePasswordResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public static class ChangePasswordStatusExtensions
    {
        public static ChangePasswordResponse ToResponse(this ChangePasswordStatus status)
        {
            return new ChangePasswordResponse
            {
                Success = status.Success,
                Message = status.Message
            };
        }
    }

    public class VerifyEmailRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public VerifyEmailData ToData()
        {
            return new VerifyEmailData
            {
                Email = Email,
                Token = Token
            };
        }
    }

    public class VerifyEmailResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public static class VerifyEmailStatusExtensions
    {
        public static VerifyEmailResponse ToResponse(this VerifyEmailStatus status)
        {
            return new VerifyEmailResponse
            {
                Success = status.Success,
                Message = status.Message
            };
        }
    }

    public class ResendVerificationEmailRequest
    {
        public string Email { get; set; }

        public ResendVerificationEmailData ToData()
        {
            return new ResendVerificationEmailData
            {
                Email = Email
            };
        }
    }

    public class ResendVerificationEmailResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public static class ResendVerificationEmailStatusExtensions
    {
        public static ResendVerificationEmailResponse ToResponse(this ResendVerificationEmailStatus status)
        {
            return new ResendVerificationEmailResponse
            {
                Success = status.Success,
                Message = status.Message
            };
        }
    }
}
