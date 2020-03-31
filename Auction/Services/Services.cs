using Auction.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.Services
{
    public class Services
    {
        protected AuctionDbContext _context;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public Services(AuctionDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

    }
}
