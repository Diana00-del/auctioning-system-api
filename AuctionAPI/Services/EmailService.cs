using AuctionAPI.Models;

namespace AuctionAPI.Services
{
    public interface IEmailService
    {
        void SendVerificationEmail(User user, string token);
        void SendPasswordResetEmail(User user, string resetToken);
    }

    public class EmailService : IEmailService
    {
        private readonly ILogger _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public void SendVerificationEmail(User user, string token)
        {
            string emailBody = $"<h1>Welcome to Auction!</h1>";
            emailBody += $"<p>Please click the following link to verify your account:</p>";
            emailBody += $"<a href='http://localhost:5000/api/auth/verify?token={token}'>Verify Account</a>";

            SendEmail(user.Email, "Verify your account", emailBody);
        }

        public void SendPasswordResetEmail(User user, string resetToken)
        {
            string emailBody = $"<h1>Reset your password</h1>";
            emailBody += $"<p>Please click the following link to reset your password:</p>";
            emailBody += $"<a href='http://localhost:5000/api/auth/reset?token={resetToken}'>Reset Password</a>";

            SendEmail(user.Email, "Reset your password", emailBody);
        }

        // TODO - implement this method properly
        private void SendEmail(string email, string subject, string body)
        {
            _logger.LogInformation($"Sending email to {email}");
            _logger.LogInformation($"Subject: {subject}");
            _logger.LogInformation($"Body: {body}");
        }
    }
}    
