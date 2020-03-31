using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Data;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Controllers
{
    public class RootController : Controller
    {
        protected readonly AuctionDbContext _context;
        protected Services.Services Services;
        public RootController()
        {
        }

    }
}