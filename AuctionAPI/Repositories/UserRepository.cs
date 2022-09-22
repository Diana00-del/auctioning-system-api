using AuctionAPI.Contexts;
using AuctionAPI.Models;

namespace AuctionAPI.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByEmail(string email);
    }

    public class UserRepository : IUserRepository
    {
        private readonly AuctionContext _context;

        public UserRepository(AuctionContext context)
        {
            _context = context;
        }
        
        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(long id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Update(User entity)
        {
            var user = _context.Users.Find(entity.Id);

            if (user == null) return null;

            user.Email = entity.Email;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Phone = entity.Phone;
            user.Address = entity.Address;
            user.City = entity.City;
            user.State = entity.State;
            user.Zip = entity.Zip;
            user.Country = entity.Country;

            _context.Users.Update(user);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(User entity)
        {
            entity.Deleted = true;
            _context.Users.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var entity = _context.Users.Find(id);
            entity.Deleted = true;
            _context.Users.Update(entity);
            _context.SaveChanges();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
