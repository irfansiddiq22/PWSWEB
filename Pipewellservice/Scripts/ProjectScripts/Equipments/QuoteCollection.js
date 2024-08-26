var Items = []
var QuoteIDList = [];
var QuoteToEdit = { ID: 0 };
var QuoteData = { ID: 0 };


function _Init() {
    HideSpinner();
    $("#txtRecordCreatedBy").val(User.Name);
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
    BindSparePartRequestSearch();
    SetPagePermission(PAGES.EquipmentCollection, function () {
        BindLists();

        $("#txtQuoteDateFilter").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))
        $("#frmSpartPartItems").validate()


        ListQuotes();

    });
}
function BindLists() {

    $.post("/DataList/SupplierList", {}, function (Response) {
        $("#ddSupplierFilter").empty();
        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select Supplier' });
        $.each(Response, function (i, s) {
            data.push({ id: s.Code, text: s.Code + " - " + s.Name });
        })
        $("#ddSuppliers,#ddSupplierFilter").select2({
            placeholder: "Select Supplier",
            allowClear: true,
            data: data,
            width: "100%"
        })

    })
    /*
    $.post("/DataList/EquipmentPaymentTypes", {}, function (Response) {
        $("#ddPaymentTypes").empty();
        var types = []
        types.push({ id: 0, text: 'Select Payment Type' });

        $.each(Response, function (i, s) {

            types.push({ id: s.Value, text: s.Name });
        })
        $("#ddPaymentTypes").select2({

            placeholder: "Select Payment Type",
            allowClear: true,
            data: types,
            width: "100%"
        })


    })*/


}
function ListQuotes() {
    ResetChangeLog(PAGES.EquipmentCollection);
    $("#dvEdit").hide();


    var StartDate = "", EndDate = "";
    if (valOf("txtQuoteDateFilter") != "") {
        StartDate = $.trim(valOf("txtQuoteDateFilter").split("-")[0]);
        EndDate = $.trim(valOf("txtQuoteDateFilter").split("-")[1]);
    }
    document.getElementById("quotationForm").reset();
    $("#dvList").show();
    $('#dvPaging').pagination({
        dataSource: "/EquipmentsAPI/EquipmentQuote/QuoteCollectionList",
        pageSize: pageSize,
        pageNumber: 1,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {

            return 'List';
        },
        totalNumberLocator: function (response) {
            return response.length == 0 ? 0 : response[0].TotalRecord;
        },

        ajax: {
            type: "POST",
            dataType: "json",
            data: {
                StartDate: StartDate,
                EndDate: EndDate,
                SupplierID: valOf("ddSupplierFilter"),
                QuoteID: valOf("txtQuoteIDFilter"),
                RFQNumber: valOf("txtRfQNumberFilter")
            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();
            $("#tblList").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').text(r.SupplierName))
                tr.append($('<td>').append(r.QuoteID))
                tr.append($('<td>').append(moment(r.QuoteDate).format("DD/MM/YYYY")));
                tr.append($('<td>').append(r.RFQNumber))
                tr.append($('<td>').append(r.DocumentCode))
                tr.append($('<td>').append(r.Remarks))
                tr.append($('<td>').append(r.RecordCreatedByName))


                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditQuote(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteItem(' + i + ')"><i class="fa fa-trash"></i></a>'));
                tr.append($('<td>').append($(Icons)));


                $("#tblList").append(tr);

            });


        }
    })

}

function SaveQuote() {
    ResetChangeLog(PAGES.EquipmentCollection);
    if ($("#quotationForm").valid()) {

        var Quote = {
            RecordDate: valOf("txtRecordDate"),
            ID: QuoteToEdit.ID,
            QuoteID: valOf("txtQuotationID"),
            DocumentCode: valOf("txtDocumentCode"),
            Remarks: valOf("txtRemarks"),
            Freight: valOf("txtFreight"),
            Discount: valOf("txtDiscount"),
            Vat: valOf("txtVat"),
            Total: valOf("txtTotal")
        };
        var QuoteItems = [];
        var valid = true;
        Quote.Items = Array.from(document.getElementById('tblItems').rows).map(row => ({
            SparePartItemID: parseInt($(row).attr("data-id")),
            Description: $(row.cells[2]).find(":input").val(),
            Quantity: parseInt($(row.cells[3]).find(":input").val()),
            UnitPrice: parseFloat($(row.cells[4]).find(":input").val()),

            Notes: $(row.cells[6]).find("textarea").val(),

        }));


        if (Quote.ID == 0) {
            DataChangeLog.DataUpdated.push({ Field: "RFQNumber", Data: { OLD: "", New: textOf("txtRfQNumber") } });
            DataChangeLog.DataUpdated.push({ Field: "QuoteID", Data: { OLD: "", New: textOf("txtQuotationID") } });
        }
        else {
            DataChangeLog.DataUpdated = [];
        }



        Post("/EquipmentsAPI/EquipmentQuote/SaveCollectQuote", { quote: Quote }).done(function (resp) {
            if (resp.ID > 0) {
                document.getElementById("quotationForm").reset();
                SaveLog(resp.ID);
                $("#tblItems").empty();
                swal("quote order saved successfully", { icon: "success" });
                NewQuote();
                ListQuotes();
            } else {
                swal("failed to save quote order", { icon: "error" });
            }
        })
        return false;
    }
}

function FetchQuoteDetail() {
    var ID = $("#txtQuotationID").val();
    if ($.inArray(ID, QuoteIDList) > -1 && QuoteToEdit.ID == 0) {
        NewQuote();

        Post("/EquipmentsAPI/EquipmentQuote/Detail", { ID: ID }).done(function (resp) {
            QuoteData = resp;

            SetvalOf("txtPaymentTerms", QuoteData.PaymentTerm);
            SetvalOf("txtQuotationDate", moment(QuoteData.QuoteDate).format("DD/MM/YYYY"));
            SetvalOf("txtRfQNumber", QuoteData.RFQNumber);


            SetvalOf("txtcustomerNotes", QuoteData.CustomerNotes);
            SetvalOf("ddcreditAllowed", QuoteData.CreditAllowed.toString());
            SetvalOf("txtRecordCreatedBy", QuoteData.RecordCreatedByName);
            $("#tblItems").empty();
            $.each(resp.Items, function (i, itm) {
                var tr = $('<tr>')


                var tr = $('<tr>')

                tr.attr("data-id", itm == null ? 0 : itm.SparePartItemID);


                tr.append($('<td>').text(itm.PartNumber));
                tr.append($('<td>').text(itm.PartName));
                tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.Description)));
                tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,1)" onblur="CalculateTotal(this,1)" class="form-control form-control-sm">').val(itm.Quantity)));
                tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,2)" onblur="CalculateTotal(this,2)"  class="form-control form-control-sm">').val(itm.UnitPrice)));
                tr.append($('<td>').append($('<input type="number" readonly  class="form-control form-control-sm total">').val(itm.Quantity * itm.UnitPrice)));


                tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(itm.Notes)));

                var a = $('<a>').attr("href", "javascript:void(0)")
                $(a).click(function () {
                    $(this).closest('tr').remove()
                })
                $(a).append($('<i class="fa fa-trash text-danger"></i>'))
                tr.append($('<td>').append($(a)));
                $("#tblItems").append(tr);

            });
            CalculateQuoteTotal();
        });
    }


}
function EditQuote(ID) {



    NewQuote();

    Post("/EquipmentsAPI/EquipmentQuote/QuoteCollectionDetail", { ID: ID }).done(function (resp) {
        QuoteToEdit = resp;
        SetvalOf("txtDocumentCode", QuoteToEdit.DocumentCode);
        SetvalOf("txtPaymentTerms", QuoteToEdit.PaymentTerm);
        SetvalOf("txtQuotationDate", moment(QuoteToEdit.QuoteDate).format("DD/MM/YYYY"));
        SetvalOf("txtRecordDate", moment(QuoteToEdit.RecordDate).format("DD/MM/YYYY"));
        SetvalOf("txtQuotationID", QuoteToEdit.QuoteID);
        SetvalOf("txtRfQNumber", QuoteToEdit.RFQNumber);


        SetvalOf("txtcustomerNotes", QuoteToEdit.CustomerNotes);
        
        SetvalOf("txtRecordCreatedBy", QuoteToEdit.RecordCreatedByName);
        SetvalOf("txtRemarks", QuoteToEdit.Remarks);

        
        $("#tblItems").empty();
        $.each(resp.Items, function (i, itm) {
            var tr = $('<tr>')


            var tr = $('<tr>')

            tr.attr("data-id", itm == null ? 0 : itm.SparePartItemID);


            tr.append($('<td>').text(itm.PartNumber));
            tr.append($('<td>').text(itm.PartName));
            tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.Description)));
            tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,1)" onblur="CalculateTotal(this,1)" class="form-control form-control-sm">').val(itm.Quantity)));
            tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,2)" onblur="CalculateTotal(this,2)"  class="form-control form-control-sm">').val(itm.UnitPrice)));
            tr.append($('<td>').append($('<input type="number" readonly  class="form-control form-control-sm total">').val(itm.Quantity * itm.UnitPrice)));


            tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(itm.Notes)));

            var a = $('<a>').attr("href", "javascript:void(0)")
            $(a).click(function () {
                $(this).closest('tr').remove()
            })
            $(a).append($('<i class="fa fa-trash text-danger"></i>'))
            tr.append($('<td>').append($(a)));
            $("#tblItems").append(tr);

        });
        CalculateQuoteTotal();
    });



}
function NewQuote() {
    QuoteToEdit = { ID: 0 };
    QuoteData = { ID: 0 };

    SetvalOf("txtRecordCreatedBy", User.Name);
    $("#dvEdit").show();
    $("#dvList").hide();
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}
function ResetNav() {
    QuoteToEdit = { ID: 0 };
    QuoteData = { ID: 0 };
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    ListQuotes();
}
function BindSparePartRequestSearch() {
    $('#txtItemCode').typeahead({
        minLength: 3,
        items: 500,

        source: function (query, result) {
            $.ajax({
                url: "/EquipmentsAPI/SpacePartItem/FindByName",
                data: 'Name=' + query,
                dataType: "json",
                type: "POST",
                success: function (data) {
                    Items = data;
                    result($.map(data, function (item) {
                        return `${item.PartNumber} - ${item.PartName} - ${item.Application} - ${item.Alternatives}`;
                    }));
                }
            });
        }
    });
    $('#txtQuotationID').typeahead({
        minLength: 1,
        items: 500,

        source: function (query, result) {
            $.ajax({
                url: "/EquipmentsAPI/EquipmentQuote/QuoteIDList",
                data: 'QuoteID=' + query,
                dataType: "json",
                type: "POST",
                success: function (data) {
                    QuoteIDList = data;
                    result(data);
                }
            });
        }
    });

}

function AddItem() {
    var itm = Items.find(x => `${x.PartNumber} - ${x.PartName} - ${x.Application} - ${x.Alternatives}` == valOf("txtItemCode"));

    var newItem = {
        PartNumber: itm.PartNumber,
        PartName: itm.PartName,
        UnitPrice: parseFloat(valOf("txtItemUnitPrice")),
        Quantity: parseInt(valOf("txtItemQuantity")),

        Notes: valOf("txtRequestItemNotes"),
        Description: valOf("txtItemDescription"),

    }
    if (newItem.PartNumber == "") {
        swal("Please enter item to quote")
        return false;
    }
    if (newItem.Quantity == "" || isNaN(newItem.Quantity)) {
        swal("Please enter quantity to request")
        return false;
    }

    var tr = $('<tr>')


    var tr = $('<tr>')

    tr.attr("data-id", itm == null ? 0 : itm.SparePartItemID);


    tr.append($('<td>').text(itm.PartNumber));
    tr.append($('<td>').text(itm.PartName));
    tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.Description)));
    tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,1)" onblur="CalculateTotal(this,1)" class="form-control form-control-sm">').val(newItem.Quantity)));
    tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,2)" onblur="CalculateTotal(this,2)"  class="form-control form-control-sm">').val(newItem.UnitPrice)));
    tr.append($('<td>').append($('<input type="number" readonly  class="form-control form-control-sm total">').val(newItem.Quantity * newItem.UnitPrice)));


    tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(newItem.Notes)));

    var a = $('<a>').attr("href", "javascript:void(0)")
    $(a).click(function () {
        $(this).closest('tr').remove()
    })
    $(a).append($('<i class="fa fa-trash text-danger"></i>'))
    tr.append($('<td>').append($(a)));
    $("#tblItems").append(tr);

    SetvalOf("txtItemUnitPrice", "");
    SetvalOf("txtItemQuantity", "");
    SetvalOf("txtItemPartAvailability", "")
    SetvalOf("txtRequestItemNotes", "")
    SetvalOf("txtItemDescription", "");

}

function CalculateTotal(sender, type) {
    var value1 = $(sender).val();
    var val2 = 0;
    if (type == 1) {
        val2 = $(sender).parent().next().find(":input").val()
    } else {
        val2 = $(sender).parent().prev().find(":input").val()
    }
    var total = parseFloat(value1) * parseFloat(val2);

    $(sender).closest("tr").find("input.total").val(total);
    CalculateQuoteTotal();
}
function CalculateQuoteTotal() {
    var items = Array.from(document.getElementById('tblItems').rows).map(row => ({
        qty: parseInt($(row.cells[3]).find(":input").val()),
        unitCost: parseFloat($(row.cells[4]).find(":input").val()),
    }));
    var TotalAmount = items.reduce((s, a) => s + (a.qty * a.unitCost), 0);
    var Freight = (isNaN(valOf("txtFreight")) || valOf("txtFreight") == "" ? 0 : parseFloat(valOf("txtFreight")))

    var Vat = parseFloat(TotalAmount * 15 / 100).toFixed(2);// (isNaN(valOf("txtVat")) || valOf("txtVat") == "" ? 0 : parseFloat(valOf("txtVat")))
    SetvalOf("txtVat", Vat)
    var Discount = (isNaN(valOf("txtDiscount")) || valOf("txtDiscount") == "" ? 0 : parseFloat(valOf("txtDiscount")))
    TotalAmount += Freight + parseFloat(Vat) - Discount;
    SetvalOf("txtTotal", parseFloat(TotalAmount).toFixed(2))
}