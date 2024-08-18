var Items = [];
var Item = { ID: 0 };
var MaxID = 0;
function _Init() {
    HideSpinner();

    pageNumber = 1
    SetvalOf("txtPreparedBy", User.Name);

    SetPagePermission(PAGES.StoreDelivery, function () {
        $("#ddlRecordDataRange").val(moment().subtract(30, 'days').format("DD/MM/YYYY") + ' - ' + moment().format("DD/MM/YYYY"))
        $('.datepicker').val(moment().format("DD/MM/YYYY"));
        FindDeliveryDetail();

        
        Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

            var data = []
            if (Response.length > 1) data.push({ id: 0, text: 'Select Requested by' });
            $.each(Response, function (i, emp) {
                data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
            })
            $("#ddEmployeeCode,#ddEmployeeCode1").select2({
                tags: "true",
                placeholder: "Select requested by",
                allowClear: true,
                data: data,
                width: "100%"
            })
        });
        
        BindStoreDelivery();
    });
    
}


function BindStoreDelivery() {
    
    $("#tblDelivery").empty();

    var StartDate = "", EndDate = "";
    if (valOf("ddlRecordDataRange") != "") {
        StartDate = $.trim(valOf("ddlRecordDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddlRecordDataRange").split("-")[1]);
    }

    $("#dvAddDelivery").addClass("d-none");
    $("#dvList").removeClass("d-none");

    $('#dvDeliveryPaging').pagination({
        dataSource: "/ProcurementAPI/StoreDeliveryReturnList",
        pageSize: pageSize,
        pageNumber: 1,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            return 'Delivery';
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
                ReturnedBy: valOf("ddEmployeeCode1"),
                DeliveryNumber: valOf("txtDeliveryNumber1") == "" ? 0 : valOf("txtDeliveryNumber1"),
                WorkOrderNumber: valOf("txtDeliverWordOrderNumber1")
            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination, response) {
            HideSpinner();
            MaxID = parseInt(response.ID) + 1;
            
            $("#tblDelivery").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').text(moment(r.ReturnDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.DeliveryNumber))
                tr.append($('<td>').append(r.WorkOrderID))
                tr.append($('<td>').append(r.Customer))
                tr.append($('<td>').append(r.MRID))
                tr.append($('<td>').append(r.ReturnedByName))
                tr.append($('<td>').append(r.Remarks))


                var Icons = $('<div class="icons">');/*
                $(Icons).append($('<a href="javascript:void(0)" class="me-2 writeble" onclick="EditInquiry(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="deleteble" onclick="DeleteInquiry(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="" onclick="PrintInquiry(' + r.ID + ')"><i class="fa fa-print"></i></a>'));*/
                tr.append($('<td>').append($(Icons)));

                $("#tblDelivery").append(tr);

            });


        }
    })

}
function FindDeliveryDetail() {
    $('#txtDeliveryNumber').typeahead({
        minLength: 3,
        source: function (query, result) {
            $.ajax({
                url: "/ProcurementAPI/FindDeliveryNumber",
                data: 'ID=' + query,
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


    
    


    $("#txtRequestItemCode").blur(function () {
        var itm = DeliveredItems.find(x => x.ItemID == valOf("txtRequestItemCode"));
        if (itm != null) {
            SetvalOf("txtRequestItemUnit", itm.Unit)
            $("#txtRequestItemQuantity").attr("max", itm.Quantity);
            $("#txtRequestItemQuantity").val(itm.Quantity);
            
        }
    })

}
var DeliveredItems = [];
function GetDeliveryItems() {
    var DeliveryNumber = $('#txtDeliveryNumber').val()
    if (!isNaN(DeliveryNumber)) {
        $.post("/ProcurementAPI/FindStoreDeliveryDetail", { DeliveryNumber: DeliveryNumber }, function (resp) {
            $("#txtWordOrderNumber").val(resp.Detail.WorkOrderID)
            $("#txtCustomer").val(resp.Detail.Customer)
            DeliveredItems = resp.Items
            $("#txtRequestItemCode").empty();
            $("#txtRequestItemCode").append(AppendListItem("select item to return", 0))
            $.each(DeliveredItems, function (i, d) {
                $("#txtRequestItemCode").append(AppendListItem(d.ItemName,d.ItemID))
            })
        })
    }
}
function AddItem() {
    if (parseInt(valOf("txtRequestItemCode")) == 0) return false;
    var itm = DeliveredItems.find(x => x.ItemID == valOf("txtRequestItemCode"));

    var newItem = {
        Name: itm.Name,
        Unit: itm.Unit,
        Quantity: valOf("txtRequestItemQuantity"),
        c: itm.Quantity,
        Notes: valOf("txtRequestItemNotes"),

    }
    if (newItem.Name == "") {
        swal("Please enter item to request", { icon: "error" })
        return false;
    }
    if (newItem.Unit == "") {
        swal("Please enter unit to request", { icon: "error" })
        return false;
    } if (newItem.Quantity == "") {
        swal("Please enter quantity to request", { icon: "error" })
        return false;
    }

    if (newItem.Quantity > itm.Quantity) {
        swal("Please enter valid quantity, you have entered more quanity then delivered.", {icon:"error"})
    return false;
}
    
    /*  
    tr.attr("data-id", itm == null ? 0 : itm.ID);
    tr.append($('<td>').text($("#tblMaterialRequestItemList tr").length + 1));
    tr.append($('<td>').text(itm == null ? "0" : itm.ItemCode));
    tr.append($('<td>').text(itm == null ? newItem.Name : itm.Name));
    tr.append($('<td>').text(newItem.Unit));
    var qtyTd = $('<td>');

    $(qtyTd).append($('<input type="number" min="1" class="form-control form-control-sm">').val(newItem.Quantity));
    if (parseInt(newItem.StockQuantity) < parseInt(newItem.Quantity))
        $(qtyTd).append(`<span class="badge bg-danger mt-1">${parseInt(newItem.StockQuantity)} items are in Store, IPS will be genereted for rest of items`)
    tr.append($(qtyTd));

    tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.Notes)));
    var a = $('<a>').attr("href", "javascript:void(0)")
    $(a).click(function () {
        $(this).closest('tr').remove()
    })
    $(a).append($('<i class="fa fa-trash text-danger"></i>'))
    tr.append($('<td>').append($(a)));
    $("#tblMaterialRequestItemList").append(tr);

    */
    var tr = $('<tr>')

    tr.attr("data-id", itm == null ? 0 : itm.ItemID);
    tr.attr("data-cost", itm == null ? 0 : itm.Price);
    tr.append($('<td>').text($("#itemsTable tr").length + 1));
    tr.append($('<td>').text(itm.ItemCode));
    tr.append($('<td>').text(itm.ItemName));    
    tr.append($('<td>').text(itm.Unit));
    tr.append($('<td>').append($(`<input type="number" min="1" class="form-control form-control-sm" onblur="ValidateMaxQty(this)" max='${itm.Quantity}'>`).val(newItem.Quantity)));


    tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(newItem.Notes)));

    
    $("#itemsTable").append(tr);


    SetvalOf("txtRequestItemCode", "")
    SetvalOf("txtRequestItemUnit", "")
    SetvalOf("txtRequestItemQuantity", "")
    SetvalOf("txtRequestItemNotes", "")

}

function FindMaterialRequestDetail() {
    var MO = valOf("txtMatrialRequestNumber");
    if (!isNaN(MO)) {

        $.post("/ProcurementAPI/GetMatrialRequestDeliveryItems", { ID: MO }, function (resp) {
            FillItems(resp.Items);
            $("#ddEmployeeCode").val(resp.Request.RecordCreatedBy).trigger("change");
            
        });
    }
}
function ValidateMaxQty(sender) {
    var val = $(sender).val();
    if (!isNaN(val)) {
        var max = parseInt($(sender).attr("max"));
        max = parseInt(max);
        if (max < val) {

            swal(`You cannot return ${val} items, as there were only ${max} items delivered from stock for this work order.`, { icon: "error" });
            $(sender).val(max);
            return false;
        } else {
            $(sender).removeClass("bg-danger").removeClass("text-white")
        }

    }
}



$('form').on('reset', function (e) {
    
    
    SetvalOf("txtPreparedBy", User.Name);
});
function NewStoreDelivery() {
    $("#itemsTable").empty();
    document.getElementById("frmData").reset();
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    $("#dvAddDelivery").removeClass("d-none");
    $("#dvList").addClass("d-none");
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
    SetvalOf("txtPreparedBy", User.Name);
}
function CreateDelivery(ID) {
    NewStoreDelivery();
    SetvalOf("txtMatrialRequestNumber", ID).trigger("blur")
}
function SaveOrderDelivery() {


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
    var valid = true;
    Items = Array.from(document.getElementById('itemsTable').rows).map(row => ({
        ID: parseInt($(row).attr("data-id")),
        Quantity: parseInt($(row.cells[4]).find(":input").val()),
                Notes: $(row.cells[5]).find("textarea").val(),
        DeliveredQuantity: parseInt($(row.cells[4]).find(":input").attr("max")),
    }));
    $.each($("#itemsTable tr"), function (i, tr) {
        var qty = parseInt($(tr.cells[4]).find(":input").val());
        var max= parseInt($(tr.cells[4]).find(":input").attr("max"));
        if (qty > max) {
            $(tr.cells[4]).find(":input").addClass("bg-danger").addClass("text-white")
        } else
            $(tr.cells[4]).find(":input").removeClass("bg-danger").removeClass("text-white");
    })
    
    $.each(Items, function (i, itm) {
        if (itm.Quantity > itm.Max) {
            valid = false;
        }
    });
    
    if (!valid) {
        swal("Please check item quantity in before processing the return.", { icon: "error" });
        return false;
    }
    
    var Delivery = {
        ID: 0,
        DeliveryNumber: parseInt(valOf("txtDeliveryNumber")),
        
        ReturnDate: valOf("txtRecordDate"),
        WorkOrderID: valOf("txtWordOrderNumber"),
        Customer: valOf("txtCustomer"),
        Remarks: valOf("txtRemarks"),
        ReturnedBy: valOf("ddEmployeeCode"),
        
    }

    //var fileData = new FormData();
    //if (QuoteFile.files.length>0)
    //    fileData.append("QuoteFile", QuoteFile.files[0]);
    //if (InvoiceFile.files.length>0)
    //    fileData.append("InvoiceFile", InvoiceFile.files[0]);
    Post("/ProcurementAPI/AddStoreDeliveryReturn", { dto: Delivery, Items: Items }).done(function (Response) {
        if (Response > 0) {
            swal("Date saved successfully", { icon: "success" });
            BindStoreDelivery();
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
    BindStoreDelivery();
    document.getElementById("frmData").reset();
    $(".breadcrumb-item.active").find("a").contents().unwrap();

}