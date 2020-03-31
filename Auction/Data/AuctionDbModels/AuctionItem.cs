using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Auction.Helpers.Enumeration;

namespace Auction.Data.AuctionDbModels
{
    public class AuctionItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
    
   
}
