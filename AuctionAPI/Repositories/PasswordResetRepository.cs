using AuctionAPI.Contexts;
using AuctionAPI.Models;

namespace AuctionAPI.Repositories
{
    public interface IPasswordResetRepository : IRepository<PasswordReset>
    {
        PasswordReset GetByToken(string token);
    }

    public class PasswordResetRepository : IPasswordResetRepository
    {
        private readonly AuctionContext _context;

        public PasswordResetRepository(AuctionContext context)
        {
            _context = context;
        }

        public IEnumerable<PasswordReset> GetAll()
        {
            return _context.PasswordResets;
        }

        public PasswordReset GetById(long id)
        {
            return _context.PasswordResets.Find(id);
        }

        public PasswordReset Create(PasswordReset entity)
        {
            _context.PasswordResets.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public PasswordReset Update(PasswordReset entity)
        {
            _context.PasswordResets.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(PasswordReset entity)
        {
            _context.PasswordResets.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.PasswordResets.Find(id);
            _context.PasswordResets.Remove(entity);
            _context.SaveChanges();
        }

        public PasswordReset GetByToken(string token)
        {
            return _context.PasswordResets.FirstOrDefault(x => x.Token == token);
        }
    }
}
