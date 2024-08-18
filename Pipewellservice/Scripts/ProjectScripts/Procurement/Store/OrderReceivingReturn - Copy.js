var Items = [];
var Item = { ID: 0 };

function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtPreparedBy", User.Name);

    SetPagePermission(PAGES.StoreReceivingReturn, function () {
        BindSuppliers();
        BindReceivingSearch();

        Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

            var data = []
            if (Response.length > 1) data.push({ id: 0, text: 'Select Returned by' });
            $.each(Response, function (i, emp) {
                data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
            })
            $("#ddEmployeeCode").select2({
                tags: "true",
                placeholder: "Select returned by",
                allowClear: true,
                data: data,
                width: "100%"
            })
        });
        
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
        dataSource: "/ProcurementAPI/StoreReceivingReturnList",
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
            $("#tblReceiving").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').append(r.ReceivingNumber))
                tr.append($('<td>').text(moment(r.ReceivingDate).format("DD/MM/YYYY")))
                tr.append($('<td>').text(moment(r.ReturnDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.RecordCreatedByName))
                
                
                
                tr.append($('<td>').append(r.IPRID))
                
                tr.append($('<td>').append(r.PurchaseOrderID))
                tr.append($('<td>').append(r.VendorInvoice))
                
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
function BindReceivingSearch() {
    $('#txtPurchaseOrderNumber').typeahead({
        minLength: 3,
        source: function (query, result) {
            $.ajax({
                url: "/ProcurementAPI/FindPurchaseOrder",
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
function FindReceivingDetail() {
    var RecordNumber = valOf("txtReceivingRecordNumber");
    if (!isNaN(RecordNumber)) {

        $.post("/ProcurementAPI/FindStoreReceivingDetail", { ReceivingNumber: RecordNumber }, function (resp) {
            var Order = resp.Detail;
            var Items = resp.Items;
            if (Order != null ) {
                SetvalOf("txtReceivingRecordNumber", Order.ReceivingNumber);
                SetvalOf("txtPurchaseOrderNumber", Order.PurchaseOrderID);
                SetvalOf("txtInernalPurchaseOrderNumber", Order.IPRID);
                SetvalOf("txtVendorInvoice", Order.VendorInvoice);
                SetvalOf("txtInvoiceDate", moment(Order.InvoiceDate).format("DD/MM/YYYY"));
                SetvalOf("txtDeliveryNotes", Order.Notes);
                SetvalOf("txtDeliveryDate", moment(Order.NoteDate).format("DD/MM/YYYY"));
                FillItems(Items);
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
        tr.attr("avg-cost", itm == null ? 0 : itm.ItemAvgUnitCost);
        tr.append($('<td>').text($("#itemsTable tr").length + 1));
        tr.append($('<td>').text(itm.ItemCode));
        tr.append($('<td>').text(itm.ItemName));
        
        tr.append($('<td>').append(itm.Unit));
        
        tr.append($('<td>').append($('<input type="text" class="form-control form-control-sm">').val(itm.Notes)));
        tr.append($('<td>').append(itm.Quantity));
        tr.append($('<td>').append($('<input type="number" min="1" max="' + itm.Quantity +'" class="form-control form-control-sm">').val(itm.Quantity)));
        tr.append($('<td>').append(moment(itm.ExpiryDate).format("DD/MM/YYYY")));
        
        $("#itemsTable").append(tr);

    })
}


$('form').on('reset', function (e) {
    
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
        
        
        
        Quantity: parseInt($(row.cells[5]).text()),
        ReturnQuantity: parseInt($(row.cells[6]).find(":input").val()),

        Notes: $(row.cells[4]).find(":input").val(),
        
        ExpiryDate: $(row.cells[7]).text()

    }));
    var valid = true;
    $.each(Items, function (i, t) {
        if (t.ReturnQuantity == 0 || isNaN(t.ReturnQuantity || t.ReturnQuantity > t.Quantity)) {
            swal("Please enter valid return quantity", { icon: "error" });
            valid = false;
            return false;
        }
    });
    
    if (!valid)
        return false;

    var Receiving = {
        ID: 0,
        ReceivingNumber: parseInt(valOf("txtReceivingRecordNumber")),
        RecordDate:valOf("txtRecordDate"),
        Remarks: valOf("txtRemarks"),
        ReturnDate: valOf("txtReturnedDate"),
        ReturnedBy: valOf("ddEmployeeCode")
    }
    
    //var fileData = new FormData();
    //if (QuoteFile.files.length>0)
    //    fileData.append("QuoteFile", QuoteFile.files[0]);
    //if (InvoiceFile.files.length>0)
    //    fileData.append("InvoiceFile", InvoiceFile.files[0]);
    Post("/ProcurementAPI/AddStoreReceivingReturn", { dto: Receiving, Items: Items }).done(function (Response) {
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