initailizeDatatable = function (name) {
    return $('#' + name).DataTable({
        "paging": false,
        "ordering": false,
        "info": false,
        "filter": false,
        "aaSorting": [[0, "desc"]]
    });
}
validateControl = function (name) {
    var control = $('[name=' + name + ']');
    if (control.val() === '') {
        $('#err_' + name + '').html('input is required');
        return false;
    }
    else {
        $('#err_' + name + '').html('');
        return true;

    }
};
bindAuctionData = function () {
    debugger
    var options = '';
    $('#dtBidders').find('tr').each(function (element) {
        debugger
        if (element > 0) {
            if ($("[name=ddBidders] option[value='" + this.cells[0].textContent + "']").val() === undefined) {
                options += '<option value="' + this.cells[0].textContent + '">' + this.cells[1].textContent + '</option>';
            }
        }
    });
    $('[name=ddBidders]').append(options);

    options = '';
    $('#dtItems').find('tr').each(function (element) {
        debugger
        if (element > 0) {
            if ($("[name=ddAuctionItems] option[value='" + this.cells[0].textContent + "']").val() === undefined) {
                options += '<option  amount= "' + this.cells[2].textContent + '" value="' + this.cells[0].textContent + '">' + this.cells[1].textContent + '      ' + this.cells[2].textContent + ' USD </option>';
            }
        }
    });
    $('[name=ddAuctionItems]').append(options);

};