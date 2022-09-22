namespace AuctionAPI.Models
{
    public class Auction
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartPrice { get; set; }
        public decimal BuyNowPrice { get; set; }
        public decimal ReservePrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Bid> Bids { get; set; }
    }
}
