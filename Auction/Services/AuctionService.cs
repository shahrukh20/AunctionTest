using Auction.Data;
using Auction.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static Auction.Helpers.Enumeration;

namespace Auction.Services
{
    public class AuctionService : Services
    {

        public AuctionService(AuctionDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
        public AuctionVM GetAuctionVM()
        {
            return new AuctionVM()
            {
                AuctionItems = new DataTableVM<AuctionItemsDT>()
                {
                    Rows = _context.AuctionItems
                                        .Select(x =>
                                        new AuctionItemsDT()
                                        {
                                            Id = x.Id,
                                            Name = x.Name,
                                            Price = x.Price
                                        }).ToList()
                },
                Bidders = new DataTableVM<BidderDT>()
                {
                    Rows = _context.Bidders
                                        .Select(x =>
                                        new BidderDT()
                                        {
                                            Id = x.Id,
                                            Name = x.Name
                                        }).ToList()
                }
            };
        }

        internal bool HandlePost(AuctionPostVM auctionVM)
        {
            try
            {
                //insert items 
                bool result = AddAuctionItems(auctionVM.AuctionItems);
                result = AddBidders(auctionVM.Bidders);
                result = AddAuction(auctionVM);
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool AddAuction(AuctionPostVM auctionVM)
        {
            try
            {
                var auction = new Data.AuctionDbModels.Auction()
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                _context.Auctions.Add(auction);
                _context.SaveChanges();
                foreach (var auctionModel in auctionVM.AunctionModel)
                {
                    _context.AuctionBids.Add(new Data.AuctionDbModels.AuctionBid()
                    {
                        AuctionId = auction.Id,
                        AuctionItemId = auctionModel.AunctionItemId,
                        BidderId = auctionModel.BidderId,
                        CreatedAt = DateTime.Now,
                        Status = (Status)Enum.Parse(typeof(Status), auctionModel.Status, true),
                        CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
                    });

                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool AddAuctionItems(List<AuctionItemsDT> AuctionItems)
        {
            try
            {
                foreach (var item in AuctionItems)
                {
                    var dbitem = _context.AuctionItems.Any(x => x.Id == item.Id);
                    if (!dbitem)
                    {
                        _context.AuctionItems.Add(new Data.AuctionDbModels.AuctionItem()
                        {
                            Name = item.Name,
                            Price = item.Price,
                            CreatedAt = DateTime.Now,
                            CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
                        });
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private bool AddBidders(List<BidderDT> Bidders)
        {
            try
            {
                foreach (var item in Bidders)
                {
                    var dbitem = _context.Bidders.Any(x => x.Id == item.Id);
                    if (!dbitem)
                    {
                        _context.Bidders.Add(new Data.AuctionDbModels.Bidder()
                        {
                            Name = item.Name,
                            CreatedAt = DateTime.Now,
                            CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)
                        });
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
