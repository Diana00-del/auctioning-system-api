using AuctionAPI.Contexts;
using AuctionAPI.Models;

namespace AuctionAPI.Repositories
{
    public interface IEmailVerificationRepository : IRepository<EmailVerification>
    {
        EmailVerification GetByToken(string token);
    }

    public class EmailVerificationRepository : IEmailVerificationRepository
    {
        private readonly AuctionContext _context;

        public EmailVerificationRepository(AuctionContext context)
        {
            _context = context;
        }


        public IEnumerable<EmailVerification> GetAll()
        {
            return _context.EmailVerifications;
        }
        
        public EmailVerification GetById(long id)
        {
            return _context.EmailVerifications.Find(id);
        }

        public EmailVerification Create(EmailVerification entity)
        {
            _context.EmailVerifications.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public EmailVerification Update(EmailVerification entity)
        {
            _context.EmailVerifications.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(EmailVerification entity)
        {
            _context.EmailVerifications.Remove(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.EmailVerifications.Find(id);
            _context.EmailVerifications.Remove(entity);
            _context.SaveChanges();
        }

        public EmailVerification GetByToken(string token)
        {
            return _context.EmailVerifications.FirstOrDefault(x => x.Token == token);
        }
    }
}
