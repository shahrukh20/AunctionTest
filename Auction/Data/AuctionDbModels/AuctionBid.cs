using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Auction.Helpers.Enumeration;

namespace Auction.Data.AuctionDbModels
{
    public class AuctionBid
    {
        public int Id { get; set; }
        public int BidderId { get; set; }
        public int AuctionItemId { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int AuctionId { get; set; }
        public virtual Auction Auction { get; set; }
        public virtual Bidder Bidder { get; set; }
        public virtual AuctionItem AuctionItem { get; set; }
    }
}
