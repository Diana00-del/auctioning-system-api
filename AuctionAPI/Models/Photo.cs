namespace AuctionAPI.Models
{
    public class Photo
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }

        public long AuctionId { get; set; }
        public Auction Auction { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
