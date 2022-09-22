namespace AuctionAPI.Models
{
    public class Bid
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidDate { get; set; }

        public long AuctionId { get; set; }
        public Auction Auction { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
    }
}
