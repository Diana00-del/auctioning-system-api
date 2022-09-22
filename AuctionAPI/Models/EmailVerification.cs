namespace AuctionAPI.Models
{
    public class EmailVerification
    {
        public int Id { get; set; }
        public bool Invalidated { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        
        public long UserId { get; set; }
        public User User { get; set; }

        public bool IsExpired()
        {
            return DateTime.Now > Expiration;
        }

        public bool IsValid()
        {
            return !Invalidated && !IsExpired();
        }

        public void Invalidate()
        {
            Invalidated = true;
        }

        public static EmailVerification Create(User user)
        {
            return new EmailVerification
            {
                Invalidated = false,
                Token = Guid.NewGuid().ToString(),
                Expiration =  DateTime.Now.AddDays(1).ToUniversalTime(),
                User = user,
                UserId = user.Id
            };
        }
    }
}
