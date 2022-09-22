namespace AuctionAPI.Models
{
    public class Session
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public bool IsExpired
        {
            get => DateTime.Now > Expiration;
        }

        public bool IsValid
        {
            get => !IsExpired && !string.IsNullOrEmpty(Token);
        }

        public void ExtendSession()
        {
            Expiration = DateTime.Now.AddDays(1).ToUniversalTime();
        }

        public void Invalidate()
        {
            Expiration = DateTime.Now.ToUniversalTime();
        }

        public static Session Create(User user)
        {
            return new Session
            {
                Token = Guid.NewGuid().ToString(),
                Expiration = DateTime.Now.AddDays(1).ToUniversalTime(),
                UserId = user.Id,
                User = user
            };
        }
    }
}
