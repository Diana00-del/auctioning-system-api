using AuctionAPI.Models;
using AuctionAPI.Repositories;

namespace AuctionAPI.Services
{
    public interface IEmailVerificationService
    {
        EmailVerification CreateEmailVerificationToken(User user);
        bool IsEmailVerificationTokenValid(string token);
        void InvalidateEmailVerificationToken(string token);
    }

    public class EmailVerificationService : IEmailVerificationService
    {
        private readonly IEmailVerificationRepository _emailVerificationRepository;

        public EmailVerificationService(IEmailVerificationRepository emailVerificationRepository)
        {
            _emailVerificationRepository = emailVerificationRepository;
        }

        public EmailVerification CreateEmailVerificationToken(User user)
        {
            var emailVerification = EmailVerification.Create(user);

            return _emailVerificationRepository.Create(emailVerification);
        }

        public bool IsEmailVerificationTokenValid(string token)
        {
            var emailVerification = _emailVerificationRepository.GetByToken(token);

            return emailVerification != null && emailVerification.IsValid();
        }

        public void InvalidateEmailVerificationToken(string token)
        {
            var emailVerification = _emailVerificationRepository.GetByToken(token);

            if (emailVerification != null)
            {
                emailVerification.Invalidate();
                _emailVerificationRepository.Update(emailVerification);
            }
        }
    }
}
