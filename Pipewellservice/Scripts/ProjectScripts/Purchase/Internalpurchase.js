
var Items = [];
var PurchaseRequest = { ID: 0 };
var PurchaseRequestItems = [];

function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtPreparedBy", User.Name);
    $("#dvEditRequest").addClass("d-none");
    $("#dvRequestList").removeClass("d-none");
    ResetNav();
    SetPagePermission(PAGES.InternalPurchaseRequest, function () {
        $.post("/DataList/ProcurementRequestType", {}, function (resp) {
            FillList("ddRequestType", resp, "Name", "Value", "Select Type")
            FillList("ddFilterRequestType", resp, "Name", "Value", "Select Type")
            BindUsers();
            BindItemSearch();
            BindSuppliers();
            BindPurchaseRequestList();
        })


    });
    $("#ddlPurchaseRequestDataRange").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))


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

    })

}
function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select requested by' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name, DivisionID: emp.DivisionID });
        })
        $("#ddEmployeeCode").select2({
            tags: "true",
            placeholder: "Select requested by",
            allowClear: true,
            data: data,
            width: "100%"
        })



        BindPurchaseRequestList();
    })
    /* $.post("/EmployeeAPI/Supervisors", {}).done(function (Response) {
         var data = []
         data.push({ id: 0, text: 'Select Supervisor' });
         $.each(Response, function (i, emp) {
             data.push({ id: emp.DivisionID, text: emp.Name });
         })
 
         $(".supervisor").select2({
             placeholder: "Select Supervisor",
             data: data,
             width: "100%"
         })
     });
     */
    /* $('#ddEmployeeCode').on('select2:select', function (e) {
         var data = e.params.data;
        // $("#ddSupervisor").val(data.DivisionID).trigger("change")
     });
    $('#ddEmployeeCode').val(User.ID).trigger("change")*/

}

function BindPurchaseRequestList(PageNumber = 1) {

    pageNumber = PageNumber;
    $("#tblPurchaseRequestList").empty();

    var StartDate = "", EndDate = "";
    if (valOf("ddlPurchaseRequestDataRange") != "") {
        StartDate = $.trim(valOf("ddlPurchaseRequestDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddlPurchaseRequestDataRange").split("-")[1]);
    }

    PurchaseRequest = { ID: 0 };
    PurchaseRequestItems = [];
    ResetChangeLog(PAGES.InternalPurchaseRequest);

    $('#dvPurchaseRequestPaging').pagination({
        dataSource: "/PurchaseAPI/GetPurchaseRequestList",
        pageSize: pageSize,
        pageNumber: pageNumber,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            return 'Data';
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
                RequestType: $("#ddFilterRequestType").val()

            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();

            $("#tblPurchaseRequestList").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').append(moment(r.RequestDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.QuotationNumber))
                tr.append($('<td>').append(r.SupplierName))
                tr.append($('<td>').append(r.MaintRequestNumber))
                

                tr.append($('<td>').append(r.RequestedByName))
                tr.append($('<td>').append(r.RecordCreatedByName))
                tr.append($('<td>').append(r.ApprovedByName))


                tr.append($('<td>').append(r.ApprovalStatusName))
                tr.append($('<td>').append(r.Remarks))
                tr.append($('<td>').append(r.FileName))






                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="writeble" onclick="EditPurchaseRequest(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="deleteble" onclick="DeletePurchaseRequest(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="" onclick="PrintPurchaseRequest(' + r.ID + ')"><i class="fa fa-print"></i></a>'));
                tr.append($('<td>').append($(Icons)));

                $("#tblPurchaseRequestList").append(tr);

            });


        }
    })

}

function DeletePurchaseRequest(ID) {
    swal("{To DO}", { icon: "error" });
} function PrintPurchaseRequests(ID) {
    swal("{To DO}", { icon: "error" });
}
function EditPurchaseRequest(ID) {


    Post("/PurchaseAPI/GetPurchaseRequestDetail", { ID: ID }).done(function (resp) {
        $("#dvEditRequest").removeClass("d-none");
        $("#dvRequestList").addClass("d-none");


        PurchaseRequest = resp.Request;
        PurchaseRequestItems = resp.Items;
        $.each(PurchaseRequestItems, function (i, itm) {
            var tr = $('<tr>')

            tr.attr("data-id", itm == null ? 0 : itm.ItemID);
            tr.append($('<td>').text($("#tblPurchaseRequestItems tr").length + 1));
            tr.append($('<td>').text(itm.ItemCode));
            tr.append($('<td>').text(itm.ItemName));
            tr.append($('<td>').text(itm.Unit));
            tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm">').val(itm.Quantity)));
            tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.PartNumber)));
            tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.Notes)));
            tr.append($('<td>').append($('<input type="checkbox"  class="">').prop("checked", newItem.MSDS)));

            var a = $('<a>').attr("href", "javascript:void(0)")
            $(a).click(function () {
                $(this).closest('tr').remove()
            })
            $(a).append($('<i class="fa fa-trash text-danger"></i>'))
            tr.append($('<td>').append($(a)));
            $("#tblPurchaseRequestItems").append(tr);

        })


        SetvalOf("txtRecordDate", moment(PurchaseRequest.RecordDate).format("DD/MM/YYYY"))
        SetvalOf("txtRequestQuotationNumber", PurchaseRequest.QuotationNumber);
        SetvalOf("ddSuppliers", PurchaseRequest.SupplierID).trigger("change");
        SetvalOf("txtMaintRequestNumber", PurchaseRequest.MaintRequestNumber);
        SetvalOf("ddRequestDeliveryType", PurchaseRequest.DeliveryType)
        SetvalOf("ddRequestPaymentType", PurchaseRequest.PaymentType)
        SetvalOf("ddRequestType", PurchaseRequest.RequestType);
        SetvalOf("txtRequestSignDate", moment(PurchaseRequest.RequestSignDate).format("DD/MM/YYYY"))
        SetvalOf("txtPreparedBy", PurchaseRequest.RecordCreatedByName)
        SetvalOf("ddEmployeeCode", PurchaseRequest.RequestedBy).trigger("change");
        SetvalOf("txtRequestDate", moment(PurchaseRequest.RequestDate).format("DD/MM/YYYY"))
        SetvalOf("txtRequestRemarks", PurchaseRequest.Remarks)

        $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    });
    ResetDatePicker();

}

function ResetNav() {


    //SetvalOf("ddSupervisor", 0).trigger("change");

    SetvalOf("ddEmployeeCode", 0).trigger("change");
    SetvalOf("ddSuppliers", 0).trigger("change");
    SetvalOf("txtRecordDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtRequestSignDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtRequestDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtMaintRequestNumber", "");
    SetvalOf("PurchaseRequestFile", "")
    SetvalOf("txtRequestQuotationNumber", "")
    SetvalOf("ddRequestType", 0);
    SetvalOf("ddRequestPaymentType", 0);
    SetvalOf("ddRequestDeliveryType", 0);

    SetvalOf("txtRequestRemarks", "")
    $("#dvEditRequest").addClass("d-none")
    $("#dvRequestList").removeClass("d-none")
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    SetvalOf("txtRequestPreparedby", User.Name);
    $("#tblPurchaseRequestItems").empty();
    ResetDatePicker();

}


function NewPurchaseRequest() {
    ResetNav();
    SetvalOf("txtRequestDate", moment().format("DD/MM/YYYY"))
    $("#dvEditRequest").removeClass("d-none")
    $("#dvRequestList").addClass("d-none")
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}



function BindItemSearch() {
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
    $.post("/ProcurementAPI/GetStoreItemUnit", {}, function (resp) {
        var data = $.map(resp, function (item) {
            return item.Unit;
        });

        $('#txtRequestItemUnit').typeahead(
            { minLength: 1, source: data }
        );

    })
    $("#txtRequestItemCode").blur(function () {
        var itm = Items.find(x => x.ItemNameCode == valOf("txtRequestItemCode"));
        if (itm != null)
            SetvalOf("txtRequestItemUnit", itm.Unit)
    })
}
function AddItem() {
    var newItem = {
        Name: valOf("txtRequestItemCode"),
        Unit: valOf("txtRequestItemUnit"),
        Quantity: valOf("txtRequestItemQuantity"),
        PartNumber: valOf("txtRequestItemPartNo"),
        Notes: valOf("txtRequestItemNotes"),
        MSDS: GetChecked("txtRequestItemMSDS")

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
    if (newItem.PartNumber == "") {
        swal("Please enter item part number")
        return false;
    }
    var tr = $('<tr>')
    var itm = Items.find(x => x.ItemNameCode == newItem.Name);
    tr.attr("data-id", itm == null ? 0 : itm.ID);
    tr.append($('<td>').text($("#tblPurchaseRequestItems tr").length + 1));
    tr.append($('<td>').text(itm == null ? "0" : itm.ItemCode));
    tr.append($('<td>').text(itm == null ? newItem.Name : itm.Name));
    tr.append($('<td>').text(newItem.Unit));
    tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm">').val(newItem.Quantity)));
    tr.append($('<td>').append($('<input type="text" min="1" class="form-control form-control-sm">').val(newItem.PartNumber)));
    tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.Notes)));
    tr.append($('<td>').append($('<input type="checkbox"  class="">').prop("checked", newItem.MSDS)));
    var a = $('<a>').attr("href", "javascript:void(0)")
    $(a).click(function () {
        $(this).closest('tr').remove()
    })
    $(a).append($('<i class="fa fa-trash text-danger"></i>'))
    tr.append($('<td>').append($(a)));
    $("#tblPurchaseRequestItems").append(tr);

    SetvalOf("txtRequestItemCode", "")
    SetvalOf("txtRequestItemUnit", "")
    SetvalOf("txtRequestItemQuantity", "")
    SetvalOf("txtRequestItemNotes", "")
    SetvalOf("txtRequestItemPartNo", "")
    SetChecked("txtRequestItemMSDS", false)


}
function SavePurchaseRequest() {
    var Request = {
        ID: PurchaseRequest.ID,
        RecordDate: valOf("txtRecordDate"),
        QuotationNumber: valOf("txtRequestQuotationNumber"),
        SupplierID: valOf("ddSuppliers"),
        MaintRequestNumber: valOf("txtMaintRequestNumber"),
        DeliveryType: valOf("ddRequestDeliveryType"),
        PaymentType: valOf("ddRequestPaymentType"),
        RequestType: valOf("ddRequestType"),
        RequestSignDate: valOf("txtRequestSignDate"),
        RequestedBy: valOf("ddEmployeeCode"),
        RequestDate: valOf("txtRequestDate"),
        //ApprovedBy: valOf("ddSupervisor"),
        Remarks: valOf("txtRequestRemarks"),
        FileName: ''
    }

    
    var RequestItems = [];
    if (Request.QuotationNumber == "") {
        swal("Please enter quotation number", { icon: "error" });
        return false;
    }
    if (Request.SupplierID == 0) {
        swal("Please select supplier", { icon: "error" });
        return false;
    }
    if (Request.MaintRequestNumber == "") {
        swal("Please enter maint. request no", { icon: "error" });
        return false;
    }
    if (Request.DeliveryType == 0) {
        swal("Please select delivery type", { icon: "error" });
        return false;
    }
    if (Request.PaymentType == 0) {
        swal("Please select payment type", { icon: "error" });
        return false;
    }
    if (Request.RequestType == 0) {
        swal("Please select request type", { icon: "error" });
        return false;
    }
    if (Request.RequestedBy == 0) {
        swal("Please select requested by", { icon: "error" });
        return false;
    }
    $.each($("#tblPurchaseRequestItems tr"), function (i, tr) {
        var Item = {
            ID: $(this).attr("data-id"),
            ItemName: $(this).find("td:eq(2)").text(),
            Unit: $(this).find("td:eq(3)").text(),
            Quantity: $($(this).find("td:eq(4)")[0]).find("input").val(),
            PartNumber: $($(this).find("td:eq(5)")[0]).find("input").val(),
            Notes: $($(this).find("td:eq(6)")[0]).find("input").val(),
            MSDS: $($(this).find("td:eq(7)")[0]).find("input").prop("checked"),
        }
        RequestItems.push(Item)
    })
    if (RequestItems.length == 0) {
        swal("Enter items to request", { icon: "error" });
        return false;
    }


    if (Request.ID == 0) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeCode") } });
    } else {
        DataChangeLog.DataUpdated = [];

        if (moment(PurchaseRequest.RecordDate).format("DD/MM/YYYY") != Request.RecordDate) {
            DataChangeLog.DataUpdated.push({ Field: "RecordDate", Data: { OLD: PurchaseRequest.RecordDate, New: Request.RecordDate } });
        }

        if (PurchaseRequest.QuotationNumber != Request.QuotationNumber) {
            DataChangeLog.DataUpdated.push({ Field: "Quotation Number", Data: { OLD: PurchaseRequest.QuotationNumber, New: Request.QuotationNumber } });
        }
        if (PurchaseRequest.SupplierID != Request.SupplierID) {
            DataChangeLog.DataUpdated.push({ Field: "Supplier ", Data: { OLD: PurchaseRequest.SupplierID, New: Request.SupplierID } });
        }
        if (PurchaseRequest.MaintRequestNumber != Request.MaintRequestNumber) {
            DataChangeLog.DataUpdated.push({ Field: "Maint Request Number ", Data: { OLD: PurchaseRequest.MaintRequestNumber, New: Request.MaintRequestNumber } });
        }
        if (PurchaseRequest.DeliveryType != Request.DeliveryType) {
            DataChangeLog.DataUpdated.push({ Field: "Delivery Type", Data: { OLD: PurchaseRequest.DeliveryType, New: Request.DeliveryType } });
        }
        if (PurchaseRequest.PaymentType != Request.PaymentType) {
            DataChangeLog.DataUpdated.push({ Field: "Payment Type", Data: { OLD: PurchaseRequest.PaymentType, New: Request.PaymentType } });
        } if (PurchaseRequest.RequestType != Request.RequestType) {
            DataChangeLog.DataUpdated.push({ Field: "Request Type", Data: { OLD: PurchaseRequest.RequestType, New: Request.RequestType } });
        }
        if (moment(PurchaseRequest.RequestSignDate).format("DD/MM/YYYY") != Request.RequestSignDate) {
            DataChangeLog.DataUpdated.push({ Field: "RequestSignDate", Data: { OLD: PurchaseRequest.RequestSignDate, New: Request.RequestRequestSignDateDate } });
        }

        if (PurchaseRequest.RequestedBy != Request.RequestedBy) {
            DataChangeLog.DataUpdated.push({ Field: "Requested By", Data: { OLD: PurchaseRequest.RequestedBy, New: textOf("ddEmployeeCode") } });
        }
        


        $.each(PurchaseRequestItems, function (i, itm) {
            if (RequestItems.find(x => x.ID == itm.ID) == null) {
                DataChangeLog.DataUpdated.push({ Field: "Item Removed", Data: { OLD: itm.ItemName, New: "" } });
            }
        });
        $.each(RequestItems, function (i, itm) {
            var oldITem = PurchaseRequestItems.find(x => x.ID == itm.ID);
            if (oldITem == null)
                DataChangeLog.DataUpdated.push({ Field: "New Request Item", Data: { OLD: "", New: itm.ItemName } });
            else {
                if (itm.Unit != oldITem.Unit)
                    DataChangeLog.DataUpdated.push({ Field: itm.ItemName + " Unit ", Data: { OLD: oldITem.Unit, New: itm.Unit } });
                if (itm.Quantity != oldITem.Quantity)
                    DataChangeLog.DataUpdated.push({ Field: itm.ItemName + " Quantity ", Data: { OLD: oldITem.Quantity, New: itm.Quantity } });
                if (itm.PartNumber != oldITem.PartNumber)
                    DataChangeLog.DataUpdated.push({ Field: itm.ItemName + " Part Number ", Data: { OLD: oldITem.PartNumber, New: itm.PartNumber } });
                if (itm.Notes != oldITem.Notes)
                    DataChangeLog.DataUpdated.push({ Field: itm.ItemName + " Notes ", Data: { OLD: oldITem.Quantity, New: itm.Quantity } });
            }
        })

    }


    var fileUpload = $('#PurchaseRequestFile').get(0);
    var files = fileUpload.files;
    if (files.length > 0) {
        Request.FileName = files[0].FileName;
    }

    Post("/PurchaseAPI/AddPurchaseRequest", { request: Request, Items: RequestItems }).done(function (resp) {
        SaveLog(resp);
        if (resp > 0) {


            if (files.length > 0) {

                UploadFile("/PurchaseAPI/UpdatePurchaseRequestFile", files[0], { ID: resp }, function (Status, Response) {


                    if (Status == 1) {
                        if (Request.ID == 0)
                            swal("New Request added", { icon: "success" });
                        else
                            swal("Request updated", { icon: "success" });
                        BindPurchaseRequestList();
                        ResetNav()

                    } else {

                        swal("Failed to upload request file.", { icon: "error" })
                    }
                });
            }
            else {

                if (Request.ID == 0)
                    swal("New Request added", { icon: "success" });
                else
                    swal("Request updated", { icon: "success" });
                BindPurchaseRequestList();
                ResetNav();
            }



        }
    })
}