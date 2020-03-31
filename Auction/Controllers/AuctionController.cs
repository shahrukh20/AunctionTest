using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auction.Data;
using Auction.Services;
using Auction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Auction.Controllers
{
    public class AuctionController : RootController
    {
        public AuctionController(Auction.Services.AuctionService AuctionService)
        {
            Services = AuctionService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AuctionProcess()
        {

            return View(((AuctionService)Services).GetAuctionVM());
        }
        [HttpPost]
        public JsonResult AddAuction(AuctionPostVM auctionVM)
        {
            var output = ((AuctionService)Services).HandlePost(auctionVM);
            return Json("");
        }
    }
}