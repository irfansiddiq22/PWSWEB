var Items = [];
var Item = { ID: 0 };
var MaxID = 0;
function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtPreparedBy", User.Name);

    SetPagePermission(PAGES.StoreReceiving, function () {
        BindSuppliers();
        BindPurchaseOrderSearch();

        SetvalOf("txtReceivingRecordNumber", (MaxID+1)); 
        
    });
    $("#ddlRecordDataRange").val(moment().subtract(30, 'days').format("DD/MM/YYYY") + ' - ' + moment().format("DD/MM/YYYY"))
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
}
function BindSuppliers() {

    $.post("/DataList/SupplierList", {}, function (Response) {
        $("#ddSuppliers").empty();
        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select Supplier' });
        $.each(Response, function (i, s) {
            data.push({ id: s.Code, text: s.Code + " - " + s.Name });
        })
        $("#ddSuppliers").select2({
            tags: "true",
            placeholder: "Select Supplier",
            allowClear: true,
            data: data,
            width: "100%"
        })
        BindStoreReceiving();

    })

}
function BindStoreReceiving() {
    
    $("#tblReceiving").empty();

    var StartDate = "", EndDate = "";
    if (valOf("ddlRecordDataRange") != "") {
        StartDate = $.trim(valOf("ddlRecordDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddlRecordDataRange").split("-")[1]);
    }

    $("#dvAddReceiving").addClass("d-none");
    $("#dvReceivingList").removeClass("d-none");

    $('#dvReceivingPaging').pagination({
        dataSource: "/ProcurementAPI/StoreReceivingList",
        pageSize: pageSize,
        pageNumber: 1,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            return 'Receivings';
        },
        totalNumberLocator: function (response) {
            return response.TotalRecords;
        },

        ajax: {
            type: "POST",
            dataType: "json",
            data: {
                
                StartDate: StartDate,
                EndDate: EndDate,
                SupplierID: valOf("ddSuppliers"),
                ReceivingNumber: valOf("txtRecordNumber") == "" ? 0 : valOf("txtRecordNumber"),
                PurchaseOrderNumber: valOf("txtPurchaseOrderNumber1") == "" ? 0 : valOf("txtPurchaseOrderNumber1")
            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination,response) {
            HideSpinner();
            MaxID = parseInt(response.ID) + 1;
            $("#txtReceivingRecordNumber").val(parseInt(response.ID)+1)
            $("#tblReceiving").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').text(moment(r.RecordDate).format("DD/MM/YYYY")))

                tr.append($('<td>').append(r.VendorInvoice))
                tr.append($('<td>').append(r.ReceivingNumber))
                tr.append($('<td>').append(r.IPRID))
                
                tr.append($('<td>').append(r.PurchaseOrderID))
                tr.append($('<td>').append(r.Notes))
                tr.append($('<td>').append(moment(r.NoteDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(moment(r.InvoiceDate).format("DD/MM/YYYY")))


                tr.append($('<td>').append(r.Remarks))

                
                var Icons = $('<div class="icons">');/*
                $(Icons).append($('<a href="javascript:void(0)" class="me-2 writeble" onclick="EditInquiry(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="deleteble" onclick="DeleteInquiry(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="" onclick="PrintInquiry(' + r.ID + ')"><i class="fa fa-print"></i></a>'));*/
                tr.append($('<td>').append($(Icons)));

                $("#tblReceiving").append(tr);

            });


        }
    })

}
function BindPurchaseOrderSearch() {
    $('#txtPurchaseOrderNumber').typeahead({
        minLength: 3,
        source: function (query, result) {
            $.ajax({
                url: "/PurchaseOrderAPI/FindPurchaseOrder",
                data: 'OrderID=' + query,
                dataType: "json",
                type: "POST",
                success: function (data) {
                    
                    result($.map(data, function (item) {
                        return item.ID.toString();
                    }));
                }
            });
        }
    });
}
function FindPurchaseOrderDetail() {
    var PO = valOf("txtPurchaseOrderNumber");
    if (!isNaN(PO)) {

        $.post("/PurchaseOrderAPI/GetPurchaseOrderRequestItems", { ID: PO }, function (resp) {
            var Order = resp.Order;
            var Items = resp.Items;
            if (Order != null && Order.ApprovalStatus == 1) {
                SetvalOf("txtInernalPurchaseOrderNumber", Order.InternalPurchaseOrderNumber);
                FillItems(Items);
            }
            
            else {
                valOf("txtPurchaseOrderNumber", "")
                if (Items.length > 0)
                    swal("The purchase order is alreay processed and stock is received!", { icon: "error" })
                else
                    swal("The purchase order is not approved, so this stock cannot be received!", {icon:"error"})
            }
        });
    }
}
function FillItems(PurchaseRequestItems) {
    $("#itemsTable").empty();
    $.each(PurchaseRequestItems, function (i, itm) {
        var tr = $('<tr>')

        tr.attr("data-id", itm == null ? 0 : itm.ItemID);
        tr.attr("data-cost", itm == null ? 0 : itm.UnitCost);
        tr.append($('<td>').text($("#itemsTable tr").length + 1));
        tr.append($('<td>').text(itm.ItemCode));
        tr.append($('<td>').text(itm.ItemName));
        tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.PartNumber)));
        tr.append($('<td>').append($('<input type="text" readonly  class="form-control form-control-sm">').val(itm.Unit)));
        tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm">').val(itm.Quantity)));
        tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(itm.Notes)));
        tr.append($('<td>').append($('<input type="number"  class="form-control form-control-sm">').val(itm.Quantity)));
        tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm datepicker">').val(itm.ExpiryDate == undefined ? moment().format("DD/MM/YYYY") : moment(itm.ExpiryDate).format("DD/MM/YYYY"))));
        
        $("#itemsTable").append(tr);

    })


    $(".datepicker").datepicker({
        autoclose: true,
        todayHighlight: false,
        format: 'dd/mm/yyyy'
    })
}


$('form').on('reset', function (e) {
    setTimeout(function () { SetvalOf("txtReceivingRecordNumber", MaxID); }, 1000);
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
    SetvalOf("txtPreparedBy", User.Name);
});
function NewStoreReceiving() {
    $("#itemsTable").empty();
    document.getElementById("frmData").reset();
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    $("#dvAddReceiving").removeClass ("d-none");
    $("#dvReceivingList").addClass("d-none");
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
    SetvalOf("txtPreparedBy", User.Name);
}
function SaveOrderReceiving() {
    

    //var InvoiceFile = $('#flInvoice').get(0);
    //var InvoiceFileName = '';
    //var files = InvoiceFile.files;
    //if (files.length > 0) {
    //    InvoiceFileName = files[0].FileName;
    //}

    //var QuoteFile = $('#flQuote').get(0);
    //var QuoteFileName = '';
    //files = QuoteFile.files;
    //if (files.length > 0) {
    //    QuoteFileName = files[0].FileName;
    //}
    var Items = [];

    Items = Array.from(document.getElementById('itemsTable').rows).map(row => ({
        ID: parseInt($(row).attr("data-id")),
        UnitCost:parseFloat($(row).attr("data-cost")),
        PartNumber: $(row.cells[3]).find(":input").val(),
        Unit: $(row.cells[4]).find(":input").val(),
        Quantity: parseInt($(row.cells[5]).find(":input").val()),

        Notes: $(row.cells[6]).find("textarea").val(),
        ReceivingQuantity: parseInt($(row.cells[7]).find(":input").val()) == null ? 0 : parseInt($(row.cells[7]).find(":input").val()),
        ExpiryDate: $(row.cells[8]).find(":input").val(),

    }));
    var valid = true;
    $.each(Items, function (i, t) {
        if (t.ReceivingQuantity == 0 || isNaN(t.ReceivingQuantity)) {
            swal("Please enter receiving quantity", { icon: "error" });
            valid = false;
            return false;
        } else if (t.ExpiryDate == "Invalid date") {
            swal("Please enter expiry date", { icon: "error" });
            valid = false;
            return false;
        }
    });
    
    if (!valid)
        return false;

    var Receiving = {
        ID: 0,
        PurchaseOrderID: parseInt(valOf("txtPurchaseOrderNumber")),
        ReceivingNumber: parseInt(valOf("txtReceivingRecordNumber")),
        IPRID: parseInt(valOf("txtInernalPurchaseOrderNumber")),
        RecordDate:valOf("txtRecordDate"),
        Remarks: valOf("txtRemarks"),
        VendorInvoice: valOf("txtVendorInvoice"),
        InvoiceDate: valOf("txtInvoiceDate"),
        Notes: valOf("txtDeliveryNotes"),
        NoteDate: valOf("txtDeliveryDate"),
        ReceiveDate: valOf("txtReceiveDate")
    }
    
    //var fileData = new FormData();
    //if (QuoteFile.files.length>0)
    //    fileData.append("QuoteFile", QuoteFile.files[0]);
    //if (InvoiceFile.files.length>0)
    //    fileData.append("InvoiceFile", InvoiceFile.files[0]);
    Post("/ProcurementAPI/AddStoreReceiving", { dto: Receiving, Items: Items }).done(function (Response) {
        if (Response > 0) {
            swal("Date saved successfully", { icon: "success" });
            BindStoreReceiving();
            document.getElementById("frmData").reset();
        } else {
            swal({ text: "Failed to save data , please try again.", icon: "error" });
        }
        $("#spinner").hide();
    })
    /*
    fileData.append("dto", JSON.stringify(Receiving));
    fileData.append("items", JSON.stringify(Items));
    $.ajax({
        url: '/ProcurementAPI/AddStoreReceiving',
        type: "POST",
        contentType: false,
        processData: false,
        data: fileData,
        success: function (Response) {
            if (Response > 0) {
                swal("Date saved successfully", { icon: "success" });
                BindStoreReceiving();
                document.getElementById("frmData").reset();
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

*/

    
}
function ResetNav() {
    BindStoreReceiving();
    document.getElementById("frmData").reset();
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    
}