using AuctionAPI.Models;
using AuctionAPI.Repositories;

namespace AuctionAPI.Services
{
    public interface ISessionService
    {
        Session CreateSession(User user);
        User GetUserFromSession(string session);
    }

    public class SessionService : ISessionService
    {
        private readonly IUserService _userService;
        private readonly ISessionRepository _sessionRepository;

        public SessionService(IUserService userService, ISessionRepository sessionRepository)
        {
            _userService = userService;
            _sessionRepository = sessionRepository;
        }

        public Session CreateSession(User user)
        {
            var session = Session.Create(user);
            return session;
        }

        public User GetUserFromSession(string token)
        {
            var user = _sessionRepository.GetByToken(token).User;
            return user;
        }
    }
}
