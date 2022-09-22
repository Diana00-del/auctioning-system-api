using AuctionAPI.Contexts;
using AuctionAPI.Models;

namespace AuctionAPI.Repositories
{
    public interface ISessionRepository : IRepository<Session>
    {
        Session GetByToken(string token);
    }

    public class SessionRepository : ISessionRepository
    {
        private readonly AuctionContext _context;

        public SessionRepository(AuctionContext context)
        {
            _context = context;
        }

        public Session GetById(long id)
        {
            return _context.Sessions.Find(id);
        }
        
        public IEnumerable<Session> GetAll()
        {
            return _context.Sessions.ToList();
        }

        public Session Create(Session entity)
        {
            _context.Sessions.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Session Update(Session entity)
        {
            _context.Sessions.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Session entity)
        {
            _context.Sessions.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.Sessions.Find(id);
            _context.Sessions.Remove(entity);
            _context.SaveChanges();
        }

        public Session GetByToken(string token)
        {
            return _context.Sessions.FirstOrDefault(s => s.Token == token);
        }
    }
}
