using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auction.ViewModels
{
    public class AuctionVM
    {
        public AuctionVM()
        {
            AuctionItems = new DataTableVM<AuctionItemsDT>();
            Bidders = new DataTableVM<BidderDT>();
            AunctionModel = new AunctionModel();
        }
        public DataTableVM<AuctionItemsDT> AuctionItems { get; set; }
        public DataTableVM<BidderDT> Bidders { get; set; }
        public AunctionModel AunctionModel { get; set; }
    }
    public class AuctionPostVM
    {
        public AuctionPostVM()
        {
            AuctionItems = new List<AuctionItemsDT>();
            Bidders = new List<BidderDT>();
            AunctionModel = new List<AunctionModel>();
        }
        public List<AuctionItemsDT> AuctionItems { get; set; }
        public List<BidderDT> Bidders { get; set; }
        public List<AunctionModel> AunctionModel { get; set; }
    }
    public class DataTableVM<T>
    {
        public DataTableVM()
        { Rows = new List<T>(); }
        public List<T> Rows { get; set; }
    }

    public class Row
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class BidderDT : Row
    {
    }
    public class AuctionItemsDT : Row
    {
        public double Price { get; set; }
    }


    public class AunctionModel
    {
        public string StartingPrice { get; set; }
        public int BidderId { get; set; }
        public decimal BidAmount { get; set; }
        public string Status { get; set; }
        public int AunctionItemId { get; set; }
    }

}
