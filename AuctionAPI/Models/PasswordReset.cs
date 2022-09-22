namespace AuctionAPI.Models
{
    public class PasswordReset
    {
        public long Id { get; set; }
        public bool Invaildated { get; set; }
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
            return !Invaildated && !IsExpired();
        }

        public void Invalidate()
        {
            Invaildated = true;
        }

        public static PasswordReset Create(User user)
        {
            return new PasswordReset
            {
                Invaildated = false,
                Token = Guid.NewGuid().ToString(),
                Expiration = DateTime.Now.AddDays(1).ToUniversalTime(),
                UserId = user.Id,
                User = user
            };
        }
    }
}
