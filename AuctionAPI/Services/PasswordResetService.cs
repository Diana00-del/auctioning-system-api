using AuctionAPI.Models;
using AuctionAPI.Repositories;

namespace AuctionAPI.Services
{
    public interface IPasswordResetService
    {
        PasswordReset CreatePasswordResetToken(User user);
        bool IsPasswordResetTokenValid(string token);
        void InvalidatePasswordResetToken(string token);
    }

    public class PasswordResetService : IPasswordResetService
    {
        private readonly IPasswordResetRepository _passwordResetRepository;

        public PasswordResetService(IPasswordResetRepository passwordResetRepository)
        {
            _passwordResetRepository = passwordResetRepository;
        }

        public PasswordReset CreatePasswordResetToken(User user)
        {
            var passwordReset = PasswordReset.Create(user);

            return _passwordResetRepository.Create(passwordReset);
        }

        public bool IsPasswordResetTokenValid(string token)
        {
            var passwordReset = _passwordResetRepository.GetByToken(token);
            return passwordReset != null && passwordReset.IsValid();
        }

        public void InvalidatePasswordResetToken(string token)
        {
            var passwordReset = _passwordResetRepository.GetByToken(token);
            if (passwordReset != null)
            {
                passwordReset.Invalidate();
                _passwordResetRepository.Update(passwordReset);
            }
        }
    }
}
