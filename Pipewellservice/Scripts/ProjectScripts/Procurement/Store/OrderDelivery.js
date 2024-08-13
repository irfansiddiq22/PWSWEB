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
        BindMaterialRequestSearch();

        SetvalOf("txtDeliveryNumber", (MaxID + 1));
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

function ShowPendingMaterialRequest() {





    $('#dvMaterialRequestPaging').pagination({
        dataSource: "/ProcurementAPI/PendingDeliveyMatrialRequest",
        pageSize: pageSize,
        pageNumber: pageNumber,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            return 'Data';
        },
        totalNumberLocator: function (response) {
            return response.TotalRecord;
        },

        ajax: {
            type: "POST",
            dataType: "json",
            data: {

            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();

            $("#tblMaterialRequestList").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').append(moment(r.RequestDate).format("DD/MM/YYYY")))

                tr.append($('<td>').append(r.RequestedByName))
                tr.append($('<td>').append(r.RecordCreatedByName))
                tr.append($('<td>').append(r.ApprovedByName))


                tr.append($('<td>').append(r.ApprovalStatusName))
                tr.append($('<td>').append(r.Remarks))







                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="writeble" onclick="CreateDelivery(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));

                tr.append($('<td>').append($(Icons)));

                $("#tblMaterialRequestList").append(tr);

            });


        }
    })

}
function BindStoreDelivery() {
    ShowPendingMaterialRequest();
    $("#tblDelivery").empty();

    var StartDate = "", EndDate = "";
    if (valOf("ddlRecordDataRange") != "") {
        StartDate = $.trim(valOf("ddlRecordDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddlRecordDataRange").split("-")[1]);
    }

    $("#dvAddDelivery").addClass("d-none");
    $("#dvDeliveryList").removeClass("d-none");

    $('#dvDeliveryPaging').pagination({
        dataSource: "/ProcurementAPI/StoreDeliveryList",
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
                ReceivedBy: valOf("ddEmployeeCode1"),
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
            $("#txtDeliveryNumber").val(parseInt(response.ID) + 1)
            $("#tblDelivery").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').text(moment(r.DeliveryDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.DeliveryNumber))
                tr.append($('<td>').append(r.WorkOrderID))
                tr.append($('<td>').append(r.Customer))
                tr.append($('<td>').append(r.MRID))
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
function BindMaterialRequestSearch() {
    $('#txtMatrialRequestNumber').typeahead({
        minLength: 3,
        source: function (query, result) {
            $.ajax({
                url: "/ProcurementAPI/FindMatrialRequestNumber",
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


    
        $('#txtRequestItemCode').typeahead({
            minLength: 3,
            source: function (query, result) {
                $.ajax({
                    url: "/ProcurementAPI/FindStoreItem",
                    data: 'name=' + query,
                    dataType: "json",
                    type: "POST",
                    success: function (data) {
                        Items = data;
                        result($.map(data, function (item) {
                            return item.ItemNameCode;
                        }));
                    }
                });
            }
        });


    $("#txtRequestItemCode").blur(function () {
        var itm = Items.find(x => x.ItemNameCode == valOf("txtRequestItemCode"));
        if (itm != null) {
            SetvalOf("txtRequestItemUnit", itm.Unit)
            $("#txtRequestItemQuantity").attr("StockQuantity", itm.StockQuantity);
            $("#spStockQuantity").html(`<span class="badge bg-primary">${itm.StockQuantity}</span> items in store`);
        }
    })

}
function AddItem() {
    var newItem = {
        Name: valOf("txtRequestItemCode"),
        Unit: valOf("txtRequestItemUnit"),
        Quantity: valOf("txtRequestItemQuantity"),
        Notes: valOf("txtRequestItemNotes"),
        StockQuantity:parseInt( $("#txtRequestItemQuantity").attr("StockQuantity"))

    }
    if (newItem.Name == "") {
        swal("Please enter item to request")
        return false;
    }
    if (newItem.Unit == "") {
        swal("Please enter unit to request")
        return false;
    } if (newItem.Quantity == "") {
        swal("Please enter quantity to request")
        return false;
    }
    
    var tr = $('<tr>')
    var itm = Items.find(x => x.ItemNameCode == newItem.Name);
    if (itm.StockQuantity < parseInt(newItem.Quantity)) {
        swal(`Delivery quantity exceeds available stock. (Current stock: ${itm.StockQuantity})"`)
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
    tr.append($('<td>').text(itm.Name));
    tr.append($('<td>').text(itm.Unit));
    tr.append($('<td>').append($(`<input type="number" min="1" class="form-control form-control-sm" onblur="ValidateMaxQty(this)" max='${ itm.StockQuantity }'>`).val(newItem.Quantity)).append(`<span class="badge bg-primary">${itm.StockQuantity}</span> items in store`));


    tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(newItem.Notes)));

    tr.append($('<td>').text(parseFloat(itm.Price).toFixed(2)));
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
                FillItems(resp);
            
        });
    }
}
function ValidateMaxQty(sender) {
    var val = $(sender).val();
    if (!isNaN(val)) {
        var stock = parseInt($(sender).attr("max"));
        val = parseInt(val);
        if (stock < val) {

            swal(`You cannot deliver ${val} items, as there are currently only ${stock} items in stock.`, { icon: "error" });
            $(sender).val(stock);
            return false;
        } else {
            $(sender).removeClass("bg-danger").removeClass("text-white")
        }

    }
}
function FillItems(MaterialRequestItems) {
    $("#itemsTable").empty();
    $.each(MaterialRequestItems, function (i, itm) {
        var tr = $('<tr>')

        tr.attr("data-id", itm == null ? 0 : itm.ItemID);
        tr.attr("data-cost", itm == null ? 0 : itm.UnitCost);
        tr.append($('<td>').text($("#itemsTable tr").length + 1));
        tr.append($('<td>').text(itm.ItemCode));
        tr.append($('<td>').text(itm.ItemName));
        tr.append($('<td>').text(itm.Unit));
        tr.append($('<td>').append($(`<input type="number" min="1" class="form-control form-control-sm" onblur="ValidateMaxQty(this)" max='${itm.StockQuantity }'>`).val(itm.Quantity)).append(`<span class="badge bg-primary">${itm.StockQuantity}</span> items in store`));

        
        tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(itm.Notes)));

        tr.append($('<td>').text(parseFloat(itm.UnitCost).toFixed(2)));
        $("#itemsTable").append(tr);

    })

    
}


$('form').on('reset', function (e) {
    setTimeout(function () { SetvalOf("txtDeliveryNumber", MaxID); }, 1000);
    
    SetvalOf("txtPreparedBy", User.Name);
});
function NewStoreDelivery() {
    $("#itemsTable").empty();
    document.getElementById("frmData").reset();
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    $("#dvAddDelivery").removeClass("d-none");
    $("#dvDeliveryList").addClass("d-none");
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
        UnitCost: parseFloat($(row).attr("data-cost")),
        Notes: $(row.cells[5]).find("textarea").val(),
        Max: parseInt($(row.cells[4]).find(":input").attr("max")),
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
        swal("Please check item quantity in stock before processing the delivery", { icon: "error" });
        return false;
    }
    
    var Delivery = {
        ID: 0,
        DeliveryNumber: parseInt(valOf("txtDeliveryNumber")),
        MRID: parseInt(valOf("txtMatrialRequestNumber")),
        DeliveryDate: valOf("txtRecordDate"),
        WorkOrderID: valOf("txtWordOrderNumber"),
        Customer: valOf("txtCustomer"),
        Remarks: valOf("txtRemarks"),
        ReceivedBy: valOf("ddEmployeeCode"),
        
    }

    //var fileData = new FormData();
    //if (QuoteFile.files.length>0)
    //    fileData.append("QuoteFile", QuoteFile.files[0]);
    //if (InvoiceFile.files.length>0)
    //    fileData.append("InvoiceFile", InvoiceFile.files[0]);
    Post("/ProcurementAPI/AddStoreDelivery", { dto: Delivery, Items: Items }).done(function (Response) {
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