using Auction.Data.AuctionDbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions<AuctionDbContext> options)
          : base(options)
        {
        }
        public virtual DbSet<AuctionBid> AuctionBids { get; set; }
        public virtual DbSet<AuctionItem> AuctionItems { get; set; }
        public virtual DbSet<Bidder> Bidders { get; set; }
        public virtual DbSet<Auction.Data.AuctionDbModels.Auction> Auctions { get; set; }
    }
}
