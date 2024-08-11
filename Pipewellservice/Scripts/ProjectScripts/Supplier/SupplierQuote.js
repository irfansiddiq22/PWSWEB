var QuoteData = {
    Supplier: {},
    QuoteItems: [],
    PastQuotes: [],
    PastQuoteItems: [],
    Status: true
}
function _Init() {
    $("#spinner").hide();
    
    $("#tblProducts,#tblProductsTotal,#dvQuoteHistoryList").empty();
    var TotalQuantity = 0;
    $.each(QuoteData.QuoteItems, function (i, d) {
        $("#tblProducts").append(CreateRow(d, false, (i + 1)));
        TotalQuantity += d.Quantity
    })
    $("#tblProductsTotal").append(CreateRow({ ItemID: 0, Name: "", Quantity: TotalQuantity, Price: 0, Notes: "" }, true, ""))


    if (QuoteData.PastQuotes.length==0)
        $("#dvQuoteHistory").hide()
    $.each(QuoteData.PastQuotes, function (i, qt) {

        var PrevQuote = $('<div class="border">')
        $(PrevQuote).append(`<div class="blue p-1">${(i + 1)}.  Date:${moment(qt.RecordDate).format("MM/DD/YYYY hh:mm A")}</div><div class="m-2 p-2 bg-light border"> ${qt.Remarks}</div>`);
        var table = $('<table  class="table m-2 table-sm table-striped table-bordered"><thead><tr><th>#</th><th>Product</th><th>Quantity</th><th>Unit Price</th><th>Notes</th></tr></thead>')
        var tbody = $('<tbody>')
        var tfoot = $('<tfoot>')
        var TotalQuantity = 0;
        var TotalPrice = 0;
        $.each(QuoteData.PastQuoteItems.filter(x => x.QuoteID == qt.ID), function (i, d) {
            $(tbody).append(CreateRow(d, true, (i + 1)));
            TotalQuantity += d.Quantity
            TotalPrice += (d.Quantity * d.Price)
        })
        $(table).append(tbody)
        $(table).append($(tfoot).append(CreateRow({ ItemID: 0, Name: "", Quantity: TotalQuantity, Price: TotalPrice, Notes: "" }, true, "")))
        PrevQuote.append($(table));
        $("#dvQuoteHistoryList").append(PrevQuote);
    });
}
function CreateRow(Data, Readonly, Index) {
    var tr = $('<tr>')
    $(tr).attr("data-id", Data.ItemID)
    $(tr).append($('<td>').text(Index));
    $(tr).append($('<td>').text(Data.Name));
    $(tr).append($('<td ' + (Data.ItemID == 0 ?"class='bg-secondary text-white'" :"") +'> ').text(Data.Quantity));
    if (Readonly) {
        if (Data.ItemID == 0) {

            $(tr).append($('<td class="bg-secondary text-white">').text(parseFloat(Data.Price).toFixed(2)));
            $(tr).append($('<td>').text());
        } else {
            $(tr).append($('<td>').text(parseFloat(Data.Price).toFixed(2)));
            $(tr).append($('<td>').text(Data.Notes));
        }
    }
    else {
        $(tr).append($('<td>').append($('<input type="number" class="form-control form-control-sm" onchange="CalculateTotal()">')));
        $(tr).append($('<td>').append($('<textarea class="form-control form-control-sm">')));
    }
    return tr;
}
function CalculateTotal() {

    var Items = Array.from(document.getElementById('tblProducts').rows).map(row => ({
        Total: parseInt($(row.cells[2]).text()) * parseFloat($(row.cells[3]).find(":input").val())
    }));
    var Total = Items.reduce((a, b) => a.Total + b.Total).Total
    $("#tblProductsTotal tr:eq(0) >td:eq(3)").text(parseFloat(Total).toFixed(2))

}
function SubmitQuote() {

    var Items = Array.from(document.getElementById('tblProducts').rows).map(row => ({
        ItemID: parseInt($(row).attr("data-id")),
        Quantity: parseInt($(row.cells[2]).text()),
        Price: parseFloat($(row.cells[3]).find(":input").val()),
        Notes: $(row.cells[4]).find("textarea").val()
    }));
    var Quote = {
        Remarks: $("#txtRemarks").val(),
        Items: Items,
        FileName: ''
    }


    var fileData = new FormData();
    var QuoteFile = $('#flQuoteFiles').get(0);
    var files = QuoteFile.files;
    if (files.length > 0) {
        fileData.append("QuoteFile", QuoteFile.files[0]);

        if (QuoteFile.files[0].size > 2000000) {
            swal("Please upload file less than 2MB", { icon: "error" });
            return false;
        }
        if (!(/\.(docx|doc|pdf)$/i).test(QuoteFile.files[0].name)) {
            swal('Please select the file format for your quote. Only .pdf, .doc, and .docx formats are supported.', { icon: "error" });
            return false;
        }
        Quote.FileName = QuoteFile.files[0].name;
    }

    fileData.append("quote", JSON.stringify(Quote));
    fileData.append("ID", ID);
    fileData.append("IPO", QuoteData.IPO);
    $.ajax({
        url: '/Supplier/SubmitQuote',
        type: "POST",
        contentType: false,
        processData: false,
        data: fileData,
        success: function (Response) {
            if (Response > 0) {
                swal("Thank you for your quote,", { icon: "success" });
                _Init();

            } else {
                swal({ text: "Failed to save data , please try again.", icon: "error" });
            }
            $("#spinner").hide();

        },
        error: function (errormessage) {
            $("#spinner").hide();
            swal({ text: "Failed to save data , please try again.", icon: "error" });
        }
    });
}