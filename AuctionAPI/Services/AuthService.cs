using AuctionAPI.Dto;

namespace AuctionAPI.Services
{
    public interface IAuthService
    {
        LoginStatus Login(LoginData request);
        ForgotPasswordStatus ForgotPassword(ForgotPasswordData request);
        ResetPasswordStatus ResetPassword(ResetPasswordData request);
        ChangePasswordStatus ChangePassword(ChangePasswordData request);
        VerifyEmailStatus VerifyEmail(VerifyEmailData request);
        ResendVerificationEmailStatus ResendVerificationEmail(ResendVerificationEmailData request);
    }
    
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly ISessionService _sessionService;
        private readonly IPasswordResetService _passwordResetService;
        private readonly IEmailVerificationService _emailVerificationService;

        public AuthService(IUserService userService, IEmailService emailService, ISessionService sessionService, IPasswordResetService passwordResetService, IEmailVerificationService emailVerificationService)
        {
            _userService = userService;
            _emailService = emailService;
            _sessionService = sessionService;
            _passwordResetService = passwordResetService;
            _emailVerificationService = emailVerificationService;
        }

        public LoginStatus Login(LoginData request)
        {
            var user = _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return LoginStatus.UserNotFound();
            }

            if (!user.Verified)
            {
                return LoginStatus.NotVerified();
            }

            if (user.Deleted)
            {
                return LoginStatus.Inactive();
            }

            if (!user.IsPasswordValid(request.Password))
            {
                return LoginStatus.WrongPassword();
            }

            var token = _sessionService.CreateSession(user);
            return LoginStatus.Successful(token.Token);
        }

        public ForgotPasswordStatus ForgotPassword(ForgotPasswordData request)
        {
            var user = _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return ForgotPasswordStatus.UserNotFound();
            }

            if (!user.Verified)
            {
                return ForgotPasswordStatus.NotVerified();
            }

            if (user.Deleted)
            {
                return ForgotPasswordStatus.Inactive();
            }

            var resetToken = _passwordResetService.CreatePasswordResetToken(user);
            _emailService.SendPasswordResetEmail(user, resetToken.Token);
            return ForgotPasswordStatus.Successful();
        }

        public ResetPasswordStatus ResetPassword(ResetPasswordData request)
        {
            var user = _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return ResetPasswordStatus.UserNotFound();
            }

            if (!user.Verified)
            {
                return ResetPasswordStatus.NotVerified();
            }

            if (user.Deleted)
            {
                return ResetPasswordStatus.Inactive();
            }

            if (!_passwordResetService.IsPasswordResetTokenValid(request.Token))
            {
                return ResetPasswordStatus.InvalidToken();
            }

            user.SetPassword(request.Password);

            _userService.Update(user);
            _passwordResetService.InvalidatePasswordResetToken(request.Token);
            return ResetPasswordStatus.Successful();
        }

        public ChangePasswordStatus ChangePassword(ChangePasswordData request)
        {
            var user = _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return ChangePasswordStatus.UserNotFound();
            }

            if (!user.Verified)
            {
                return ChangePasswordStatus.NotVerified();
            }

            if (user.Deleted)
            {
                return ChangePasswordStatus.Inactive();
            }

            if (!user.IsPasswordValid(request.OldPassword))
            {
                return ChangePasswordStatus.InvalidPassword();
            }

            user.SetPassword(request.NewPassword);

            _userService.Update(user);
            return ChangePasswordStatus.Successful();
        }

        public VerifyEmailStatus VerifyEmail(VerifyEmailData request)
        {
            var user = _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return VerifyEmailStatus.UserNotFound();
            }

            if (user.Deleted)
            {
                return VerifyEmailStatus.Inactive();
            }

            if (!_emailVerificationService.IsEmailVerificationTokenValid(request.Token))
            {
                return VerifyEmailStatus.InvalidToken();
            }

            user.Verified = true;
            _userService.Update(user);
            _emailVerificationService.InvalidateEmailVerificationToken(request.Token);
            return VerifyEmailStatus.Successful();
        }

        public ResendVerificationEmailStatus ResendVerificationEmail(ResendVerificationEmailData request)
        {
            var user = _userService.GetUserByEmail(request.Email);
            if (user == null)
            {
                return ResendVerificationEmailStatus.UserNotFound();
            }

            if (user.Deleted)
            {
                return ResendVerificationEmailStatus.Inactive();
            }

            if (user.Verified)
            {
                return ResendVerificationEmailStatus.AlreadyVerified();
            }

            var token = _emailVerificationService.CreateEmailVerificationToken(user);
            _emailService.SendVerificationEmail(user, token.Token);
            return ResendVerificationEmailStatus.Successful();
        }
    }
}
