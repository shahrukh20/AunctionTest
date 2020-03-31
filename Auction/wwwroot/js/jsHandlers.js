
$(document).ready(function () {



    var tableBidders = initailizeDatatable('dtBidders');
    var tableItems = initailizeDatatable('dtItems');
    var tableAuction = initailizeDatatable('dtAuction');
    //tableAuction.row.add([ddAuctionItems.attr('amount'), ddBidders.text(), tbBid.val(), parseFloat(tbBid.val()) - parseFloat(ddAuctionItems.attr('amount')), 'Won', ddAuctionItems.val(), ddBidders.val()]).draw(false);


    var divs = $('.div');
    var now = 0; // currently shown div
    divs.hide().first().show(); // hide all divs except first
    $("button[name=btnNextStep]").click(function () {

        divs.eq(now).hide();
        now = (now + 1 < divs.length) ? now + 1 : 0;
        divs.eq(now).show(); // show next
        bindAuctionData();
    });
    $("button[name=btnPriviousStep]").click(function () {
        divs.eq(now).hide();
        now = (now > 0) ? now - 1 : divs.length - 1;
        divs.eq(now).show(); // show previous
    });

    $("button[name=btnAddBidder]").click(function (btn) {
        if (validateControl('tbParticipant')) {
            var tbParticipant = $('[name=tbParticipant]');
            tbParticipant.html('');
            tableBidders.row.add([parseInt(tableBidders.row(':last').data()[0]) + 1, tbParticipant.val()]).draw(false);
            tbParticipant.html('');
        }
    });

    $("button[name=btnAddItem]").click(function (btn) {
        if (validateControl('tbItemName')) {
            debugger
            if (validateControl('tbPrice')) {
                var tbItemName = $('[name=tbItemName]');
                var tbPrice = $('[name=tbPrice]');
                tableItems.row.add([parseInt(tableItems.row(':last').data()[0]) + 1, tbItemName.val(), tbPrice.val()]).draw(false);
                tbPrice.val('');
                tbItemName.val('');
            }
        }
    });


    $("button[name=btnAddBid]").click(function (btn) {
        if (validateControl('ddAuctionItems')) {
            if (validateControl('ddBidders')) {
                if (validateControl('tbBid')) {
                    debugger
                    var ddAuctionItems = $('[name=ddAuctionItems] option:selected');
                    var ddBidders = $('[name=ddBidders] option:selected');
                    var tbBid = $('[name=tbBid]');
                    tableAuction.rows().every(function (rowIdx, tableLoop, rowLoop) {
                        var data = this.data();
                        data[4] = 'Loss'
                        this.data(data);
                    })
                    tableAuction.row.add([ddAuctionItems.attr('amount') + ' USD', ddBidders.text(), tbBid.val(), parseFloat(tbBid.val()) - parseFloat(ddAuctionItems.attr('amount')) + ' USD', 'Won', ddAuctionItems.val(), ddBidders.val()]).draw(false);

                    $('#spWinnerName').html(ddBidders.text());
                    $('#spPrice').html(tbBid.val());
                    tbBid.val('');
                    //ddAuctionItems.val('');
                    //ddBidders.val('');

                }
            }
        }
    });


    $("button[name=btnSaveAuction]").click(function (btn) {
        var AuctionItems = [];
        var Bidders = [];
        var AunctionModel = [];
        $('#dtItems').find('tr').each(function (element) {
            debugger
            if (element > 0) {
                AuctionItems.push({ Id: this.cells[0].textContent, Name: this.cells[1].textContent, Price: this.cells[2].textContent });
            }
        });
        $('#dtBidders').find('tr').each(function (element) {
            debugger
            if (element > 0) {
                Bidders.push({ Id: this.cells[0].textContent, Name: this.cells[1].textContent });
            }
        });

        $('#dtAuction').find('tr').each(function (element) {
            debugger
            if (element > 0) {
                AunctionModel.push({
                    StartingPrice: this.cells[0].textContent,
                    BidderId: this.cells[6].textContent,
                    BidAmount: this.cells[2].textContent,
                    AunctionItemId: this.cells[5].textContent,
                    Status: this.cells[4].textContent
                });
            }
        });

        var auctionVM = {
            AuctionItems: AuctionItems,
            Bidders: Bidders,
            AunctionModel: AunctionModel
        };
        debugger;
        $.ajax({
            type: "POST",
            data: auctionVM,
            dataType: "JSON",
            url: "/Auction/AddAuction"
        }).done(function (res) {
            alert("Auction is saved and all items are added to database for future use.");
            window.location.href = "/Auction/AuctionProcess";
        });


    });
});
