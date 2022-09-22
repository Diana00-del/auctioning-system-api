using AuctionAPI.Models;
using AuctionAPI.Repositories;

namespace AuctionAPI.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user);
        User Update(User user);
        void Delete(int id);
        
        User GetUserByEmail(string email);
    }
    
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationService _emailVerificationService;
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IEmailVerificationService emailVerificationService, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailVerificationService = emailVerificationService;
            _emailService = emailService;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public User Create(User user)
        {
            user.Verified = false;
            user = _userRepository.Create(user);
            var emailVerification = _emailVerificationService.CreateEmailVerificationToken(user);
            _emailService.SendVerificationEmail(user, emailVerification.Token);
            return user;
        }
        
        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }
    }
}
