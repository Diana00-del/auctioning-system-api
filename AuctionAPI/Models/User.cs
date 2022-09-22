using AuctionAPI.Utils;

namespace AuctionAPI.Models
{
    public class User
    {
        public long Id { get; set; }
        public bool Deleted { get; set; }
        public bool Verified { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }

        public ICollection<Session> Sessions { get; set; }
        public ICollection<Bid> Bids { get; set; }
        public ICollection<Auction> Auctions { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<PasswordReset> PasswordResets { get; set; }
        public ICollection<EmailVerification> EmailVerifications { get; set; }

        public bool IsPasswordValid(string password)
        {
            return PasswordHasher.ValidatePassword(password, Password);
        }

        public void SetPassword(string password)
        {
            Password = PasswordHasher.HashPassword(password);
        }
    }
}
