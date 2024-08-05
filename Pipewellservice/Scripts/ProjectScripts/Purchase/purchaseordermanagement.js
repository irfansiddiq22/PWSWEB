var Items = [];
var OrderManagement = { ID: 0 };
var PurchaseRequestItems = [];
var Supervisors = [];
var Approvals = [];

function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtPreparedBy", User.Name);
    $("#dvEditRequest").addClass("d-none");
    $("#dvRequestList").removeClass("d-none");
    ResetNav();
    SetPagePermission(PAGES.PurchaseOrderManagement, function () {
        $("#ddRequestDataRange").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))
        //FillList("ddRequestType", resp, "Name", "Value", "Select Type")
        //  FillList("ddFilterRequestType", resp, "Name", "Value", "Select Type")
        $.post("/DataList/Supervisors", {}).done(function (Response) {
            Supervisors = []
            Supervisors.push({ id: 0, text: 'Select Supervisor' });
            $.each(Response, function (i, emp) {
                Supervisors.push({ id: emp.ID, text: emp.Name, DivisionID:emp.DivisionID });
            })
        });

        BindUsers();
        BindItemSearch();
        BindSuppliers();
        Post("/SettingAPI/DivisionList", {}).done(function (Response) {
            FillList("ddDepartment", Response, "Name", "ID", "Select Division")
        });
        // })

    });
    

}
function BindSuppliers() {

    $.post("/DataList/SupplierList", {}, function (Response) {
        $("#ddSuppliers").empty();
        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select Supplier' });
        $.each(Response, function (i, s) {
            data.push({ id: s.Code, text: s.Code + " - " + s.Name });
        })
        $("#ddSuppliers,#ddSuppliers1").select2({
            tags: "true",
            placeholder: "Select Supplier",
            allowClear: true,
            data: data,
            width: "100%"
        })
        BindOrderManagmentList();
    })

}
function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select requested by' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name, DivisionID: emp.DivisionID });
        })
        $("#ddEmployeeCode,#ddEmployeeCode1").select2({
            tags: "true",
            placeholder: "Select requested by",
            allowClear: true,
            data: data,
            width: "100%"
        })




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

function BindOrderManagmentList(PageNumber = 1) {

    pageNumber = PageNumber;
    $("#tblOrderManagementList").empty();

    var StartDate = "", EndDate = "";
    if (valOf("ddRequestDataRange") != "") {
        StartDate = $.trim(valOf("ddRequestDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddRequestDataRange").split("-")[1]);
    }

    OrderManagement = { ID: 0 };
    PurchaseRequestItems = [];
    ResetChangeLog(PAGES.PurchaseOrderManagement);

    $('#dvOrderManagementPaging').pagination({
        dataSource: "/PurchaseOrderAPI/GetPurchaseOrderRequestList",
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

                StartDate: StartDate,
                EndDate: EndDate,
                SupplierID: valOf("ddSuppliers1"),
                ID: valOf("txtPurchaseOrderNumber"),
                RequestedBy: valOf("ddEmployeeCode1")

            },
            beforeSend: function () {
                ShowSpinner();
            }
        },
        callback: function (data, pagination) {
            HideSpinner();

            $("#tblOrderManagementList").empty();
            $.each(data, function (i, r) {
                var tr = $('<tr>')
                tr.append($('<td>').text(r.ID))
                tr.append($('<td>').append(moment(r.RequestDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.InternalPurchaseOrderNumber))
                tr.append($('<td>').append(r.SupplierName))
                tr.append($('<td>').append(r.Attn))


                tr.append($('<td>').append(r.RequestedByName))
                tr.append($('<td>').append(r.RecordCreatedByName))
                tr.append($('<td>').append(r.ApprovedByName))


                tr.append($('<td>').append(r.ApprovalStatusName))
                tr.append($('<td>').append(r.Remarks))
                tr.append($('<td>').append(r.InternalPurchaseOrderNumber))






                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="writeble" onclick="EditOrderManagement(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="deleteble" onclick="DeleteOrderManagement(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="" onclick="PrintOrderManagement(' + r.ID + ')"><i class="fa fa-print"></i></a>'));
                tr.append($('<td>').append($(Icons)));

                $("#tblOrderManagementList").append(tr);

            });


        }
    })

}

function DeleteOrderManagement(ID) {
    swal("{To DO}", { icon: "error" });
} function PrintOrderManagement(ID) {
    window.open("/Procurement/PrintPurchaseOrderRequest?ID=" + ID, "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950")
}
function EditOrderManagement(ID) {


    Post("/PurchaseOrderAPI/GetPurchaseOrderRequestDetail", { ID: ID }).done(function (resp) {
        $("#dvEditRequest").removeClass("d-none");
        $("#dvRequestList").addClass("d-none");


        OrderManagement = resp.Order;
        PurchaseRequestItems = resp.Items;
        Approvals = resp.Approvals;
        FillItems(PurchaseRequestItems);
        $("#ApprovalList").empty();
        $.each(Approvals, function (i, ap) {
            if (i > 0) {
                AddApproval(ap.DivisionID, ap.ID)
            }

        })
        SetvalOf("txtRecordDate", moment(OrderManagement.RecordDate).format("DD/MM/YYYY"))
        SetvalOf("txtInternalPurchaseOrderNumber", OrderManagement.InternalPurchaseOrderNumber)
        SetvalOf("txtAttn", OrderManagement.Attn);
        SetvalOf("txtRequiredDate", moment(OrderManagement.RequiredDate).format("DD/MM/YYYY"));
        SetvalOf("txtContractPeriodFrom", moment(OrderManagement.ContractPeriodFrom).format("DD/MM/YYYY"))
        SetvalOf("txtContractPeriodTo", moment(OrderManagement.ContractPeriodTo).format("DD/MM/YYYY"))

        SetvalOf("ddSuppliers", OrderManagement.SupplierID).trigger("change");

        SetvalOf("ddRequestDeliveryType", OrderManagement.DeliveryType);
        SetvalOf("ddRequestPaymentType", OrderManagement.PaymentType);
        SetvalOf("txtWarrantyPeriod", OrderManagement.WarrantyPeriod);
        SetChecked("chklongTermContract", OrderManagement.LongTermContract);
        SetChecked("rdcalibrationNeededYes", OrderManagement.Calibration);
        SetChecked("rdcertificationNeededYes", OrderManagement.Certification);

        SetChecked("rdcalibrationNeededNo", !OrderManagement.Calibration);
        SetChecked("rdcertificationNeededNo", !OrderManagement.Certification);
        SetvalOf("txtRequestRemarks", OrderManagement.Remarks);
        SetvalOf("ddCurrency", OrderManagement.Currency)
        SetvalOf("txtFreight", OrderManagement.Freight);
        SetvalOf("txtDiscount", OrderManagement.Discount)
        SetvalOf("txtVat", OrderManagement.VAT)
        SetvalOf("txtTotal", OrderManagement.Total)
        SetChecked("chkShowVatOnInvoice", OrderManagement.ShowVatOnInvoice);

        SetvalOf("txtRequestPrepDate", moment(OrderManagement.RequestPerpDate).format("DD/MM/YYYY"));
        SetvalOf("ddEmployeeCode", OrderManagement.RequestedBy).trigger("change");
        SetvalOf("txtRequestDate", moment(OrderManagement.RequestDate).format("DD/MM/YYYY"));
        SetvalOf("ddDepartment", OrderManagement.DepartmentID);


        $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    });
    ResetDatePicker();

}
function FillItems(PurchaseRequestItems) {
    $("#itemsTable").empty();
    $.each(PurchaseRequestItems, function (i, itm) {
        var tr = $('<tr>')

        tr.attr("data-id", itm == null ? 0 : itm.ItemID);
        tr.append($('<td>').text($("#itemsTable tr").length + 1));
        tr.append($('<td>').text(itm.ItemCode));
        tr.append($('<td>').text(itm.ItemName));
        tr.append($('<td>').text(itm.Unit));
        tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm" onblur="CalculateAmount(this)" onchange="CalculateAmount(this)">').val(itm.Quantity)));
        tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm" onblur="CalculateAmount(this)" onchange="CalculateAmount(this)">').val(itm.UnitCost)));
        tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm" readonly>').val(itm.Amount)));

        tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.PartNumber)));
        tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.Notes)));
        tr.append($('<td>').append($('<input type="checkbox"  class="">').prop("checked", itm.MSDS)));

        var a = $('<a>').attr("href", "javascript:void(0)")
        $(a).click(function () {
            $(this).closest('tr').remove()
        })
        $(a).append($('<i class="fa fa-trash text-danger"></i>'))
        tr.append($('<td>').append($(a)));
        $("#itemsTable").append(tr);

    })
}

function ResetNav() {

    SetvalOf("txtRecordDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtInternalPurchaseOrderNumber", "")
    SetvalOf("txtAttn", "");
    SetvalOf("txtRequiredDate", moment().format("DD/MM/YYYY"));
    SetvalOf("txtContractPeriodFrom", moment().format("DD/MM/YYYY"))
    SetvalOf("txtContractPeriodTo", moment().format("DD/MM/YYYY"))




    SetvalOf("txtWarrantyPeriod", "");
    SetChecked("chklongTermContract", false);
    SetChecked("rdcalibrationNeededYes", false);
    SetChecked("rdcertificationNeededYes", false);

    SetChecked("rdcalibrationNeededNo", true);
    SetChecked("rdcertificationNeededNo", true);
    SetvalOf("txtRequestRemarks", '');
    SetvalOf("ddCurrency", 'SR')
    SetvalOf("txtFreight", "");
    SetvalOf("txtDiscount", "")
    SetvalOf("txtVat", "")
    SetvalOf("txtTotal", "")
    SetChecked("chkShowVatOnInvoice", false);

    SetvalOf("txtRequestPrepDate", moment().format("DD/MM/YYYY"));
    SetvalOf("ddEmployeeCode", 0).trigger("change");
    SetvalOf("txtRequestDate", moment().format("DD/MM/YYYY"));
    SetvalOf("ddDepartment", 0).trigger("change");



    $("#dvEditRequest").addClass("d-none")
    $("#dvRequestList").removeClass("d-none")
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    SetvalOf("txtRequestPreparedby", User.Name);
    $("#itemsTable").empty();
    ResetDatePicker();

}


function NewOrderManagment() {
    ResetNav();
    SetvalOf("txtRequestDate", moment().format("DD/MM/YYYY"))
    $("#dvEditRequest").removeClass("d-none")
    $("#dvRequestList").addClass("d-none")
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    $("#ApprovalList").empty();
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
    $('#txtInternalPurchaseOrderNumber').typeahead({
        minLength: 1,
        source: function (query, result) {
            $.ajax({
                url: "/PurchaseOrderAPI/GetInterPurchaseOrderNumber",
                data: 'IPO=' + query,
                dataType: "json",
                type: "POST",
                success: function (data) {
                    Items = data;
                    result($.map(data, function (item) {
                        return item.ID;
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
        if (itm != null) {
            SetvalOf("txtRequestItemUnit", itm.Unit)
            SetvalOf("txtRequestItemUnitCost", itm.Price)
        }
    })
}
$('#txtInternalPurchaseOrderNumber').blur(function () {
    if (OrderManagement.ID == 0 && $('#txtInternalPurchaseOrderNumber').val() != "") {
        ShowSpinner();
        $.post("/InternalPurchaseAPI/GetPurchaseRequestDetail", { ID: $('#txtInternalPurchaseOrderNumber').val() }, function (resp) {
            HideSpinner();
            if (resp.Request != null) {
                $("#ddSuppliers").val(resp.Request.SupplierID).trigger("change")
                FillItems(resp.Items);
                CalculateTotal();
            }
        })
    }
})
$("#txtRequestItemQuantity,#txtRequestItemUnitCost").blur(function () {
    SetvalOf("txtRequestItemAmount", parseFloat(valOf("txtRequestItemUnitCost")) * parseInt(valOf("txtRequestItemQuantity")))
})

function AddItem() {
    var newItem = {
        Name: valOf("txtRequestItemCode"),
        Unit: valOf("txtRequestItemUnit"),
        Quantity: valOf("txtRequestItemQuantity"),
        UnitCost: valOf("txtRequestItemUnitCost"),
        Amount: valOf("txtRequestItemAmount"),
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
    if (isNaN(newItem.UnitCost) || newItem.UnitCost == "") {
        swal("Please enter item unit cost")
        return false;
    }
    if (newItem.PartNumber == "") {
        swal("Please enter item part number")
        return false;
    }

    var tr = $('<tr>')
    var itm = Items.find(x => x.ItemNameCode == newItem.Name);
    tr.attr("data-id", itm == null ? 0 : itm.ID);
    tr.append($('<td>').text($("#itemsTable tr").length + 1));
    tr.append($('<td>').text(itm == null ? "0" : itm.ItemCode));
    tr.append($('<td>').text(itm == null ? newItem.Name : itm.Name));
    tr.append($('<td>').text(newItem.Unit));
    tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm" onblur="CalculateAmount(this)" onchange="CalculateAmount(this)">').val(newItem.Quantity)));
    tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm"  onblur="CalculateAmount(this)" onchange="CalculateAmount(this)">').val(newItem.UnitCost)));
    tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm" readonly >').val(newItem.Amount)));
    tr.append($('<td>').append($('<input type="text" min="1" class="form-control form-control-sm" >').val(newItem.PartNumber)));
    tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.Notes)));
    tr.append($('<td>').append($('<input type="checkbox"  class="">').prop("checked", newItem.MSDS)));
    var a = $('<a>').attr("href", "javascript:void(0)")
    $(a).click(function () {
        $(this).closest('tr').remove()
    })
    $(a).append($('<i class="fa fa-trash text-danger"></i>'))
    tr.append($('<td>').append($(a)));
    $("#itemsTable").append(tr);

    SetvalOf("txtRequestItemCode", "")
    SetvalOf("txtRequestItemUnit", "")
    SetvalOf("txtRequestItemQuantity", "")
    SetvalOf("txtRequestItemUnitCost", "")
    SetvalOf("txtRequestItemAmount", "")

    SetvalOf("txtRequestItemNotes", "")
    SetvalOf("txtRequestItemPartNo", "")
    SetChecked("txtRequestItemMSDS", false)
    CalculateTotal()

}
function CalculateAmount(sender) {
    var Row = $(sender).closest("tr")[0]

    var Quantity = parseInt($(Row.cells[4]).find(":input").val());
    var Unit = parseFloat($(Row.cells[5]).find(":input").val());

    $(Row.cells[6]).find(":input").val((isNaN(Quantity) ? 0 : Quantity) * (isNaN(Unit) ? 0 : Unit));
    CalculateTotal();
}
function SaveOrderManagement() {
    var Request = {
        ID: OrderManagement.ID,
        RecordDate: valOf("txtRecordDate"),
        InternalPurchaseOrderNumber: valOf("txtInternalPurchaseOrderNumber"),
        Attn: valOf("txtAttn"),
        RequiredDate: valOf("txtRequiredDate"),
        ContractPeriodFrom: valOf("txtContractPeriodFrom"),
        ContractPeriodTo: valOf("txtContractPeriodTo"),
        SupplierID: valOf("ddSuppliers"),
        DeliveryType: valOf("ddRequestDeliveryType"),
        PaymentType: valOf("ddRequestPaymentType"),
        WarrantyPeriod: valOf("txtWarrantyPeriod"),
        LongTermContract: GetChecked("chklongTermContract"),
        Calibration: GetChecked("rdcalibrationNeededYes"),
        Certification: GetChecked("rdcertificationNeededYes"),
        Remarks: valOf("txtRequestRemarks"),
        Currency: valOf("ddCurrency"),
        Freight: valOf("txtFreight"),
        Discount: valOf("txtDiscount"),
        Vat: valOf("txtVat"),
        Total: valOf("txtTotal"),
        ShowVatOnInvoice: GetChecked("chkShowVatOnInvoice"),
        RequestPerpDate: valOf("txtRequestPrepDate"),
        RequestedBy: valOf("ddEmployeeCode"),
        RequestDate: valOf("txtRequestDate"),
        DepartmentID: valOf("ddDepartment"),
        //ApprovedBy: valOf("ddSupervisor"),
    }
    var RequestItems = [];
    var Approvals = [];
    if (Request.InternalPurchaseOrderNumber == "") {
        swal("Please enter IPO number", { icon: "error" });
        return false;
    }
    if (Request.RequiredDate == "") {
        swal("Please enter required date", { icon: "error" });
        return false;
    }
    if (Request.ContractPeriodFrom == "") {
        swal("Please enter contract start date", { icon: "error" });
        return false;
    }
    if (Request.ContractPeriodTo == "") {
        swal("Please enter contract end date", { icon: "error" });
        return false;
    }
    if (Request.SupplierID == "0") {
        swal("Please enter supplier date", { icon: "error" });
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
    if (Request.WarrantyPeriod=="") {
        swal("Please enter Warranty Period", { icon: "error" });
        return false;
    }
    if (Request.Currency == 0) {
        swal("Please select currency", { icon: "error" });
        return false;
    }
    if (Request.RequestedBy == 0) {
        swal("Please select requested by", { icon: "error" });
        return false;
    } if (Request.DepartmentID == 0) {
        swal("Please select department", { icon: "error" });
        return false;
    }
    Approvals = $('.supervisor').map(function () {
        return {
            DivisionID: parseInt($(this).val()),
            SupervisorID: parseInt($(this).find('option:selected').attr("dataid")),
            ID: parseInt($(this).find('option:selected').attr("approvalid")), 
        };
    }).get();
    
    RequestItems = Array.from(document.getElementById('itemsTable').rows).map(row => ({
        ID: parseInt($(row).attr("data-id")),
        ItemName: $(row.cells[2]).text(),
        Unit: $(row.cells[3]).text(),
        Quantity: parseInt($(row.cells[4]).find(":input").val()),
        UnitCost: parseFloat($(row.cells[5]).find(":input").val()),
        Amount: parseFloat($(row.cells[6]).find(":input").val()),
        PartNumber: $(row.cells[7]).find(":input").val(),
        Notes: $(row.cells[8]).find(":input").val(),
        MSDS: $(row.cells[9]).find(":checkbox").prop("checked")
    }));

    if (RequestItems.length == 0) {
        swal("Enter items to request", { icon: "error" });
        return false;
    }


    if (Request.ID == 0) {
        DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeCode") } });
    }
    else {
        DataChangeLog.DataUpdated = [];
        if (moment(OrderManagement.RecordDate).format("DD/MM/YYYY") != Request.RecordDate) {
            DataChangeLog.DataUpdated.push({ Field: "RecordDate", Data: { OLD: OrderManagement.RecordDate, New: Request.RecordDate } });
        }
        if (OrderManagement.InternalPurchaseOrderNumber != Request.InternalPurchaseOrderNumber) {
            DataChangeLog.DataUpdated.push({ Field: "Internal Purchase OrderNumber", Data: { OLD: OrderManagement.InternalPurchaseOrderNumber, New: Request.InternalPurchaseOrderNumber } });
        }
        if (OrderManagement.Attn != Request.Attn) {
            DataChangeLog.DataUpdated.push({ Field: "Attn", Data: { OLD: OrderManagement.Attn, New: Request.Attn } });
        }
        if (moment(OrderManagement.RequiredDate).format("DD/MM/YYYY") != Request.RequiredDate) {
            DataChangeLog.DataUpdated.push({ Field: "RequiredDate", Data: { OLD: OrderManagement.RequiredDate, New: Request.RequiredDate } });
        }
        if (moment(OrderManagement.ContractPeriodFrom).format("DD/MM/YYYY") != Request.ContractPeriodFrom) {
            DataChangeLog.DataUpdated.push({ Field: "ContractPeriodFrom", Data: { OLD: OrderManagement.ContractPeriodFrom, New: Request.ContractPeriodFrom } });
        }
        if (moment(OrderManagement.ContractPeriodTo).format("DD/MM/YYYY") != Request.ContractPeriodTo) {
            DataChangeLog.DataUpdated.push({ Field: "ContractPeriodTo", Data: { OLD: OrderManagement.ContractPeriodTo, New: Request.ContractPeriodTo } });
        }
        if (OrderManagement.SupplierID != Request.SupplierID) {
            DataChangeLog.DataUpdated.push({ Field: "Supplier ", Data: { OLD: OrderManagement.SupplierID, New: Request.SupplierID } });
        }
        if (OrderManagement.DeliveryType != Request.DeliveryType) {
            DataChangeLog.DataUpdated.push({ Field: "Delivery Type", Data: { OLD: OrderManagement.DeliveryType, New: Request.DeliveryType } });
        }
        if (OrderManagement.PaymentType != Request.PaymentType) {
            DataChangeLog.DataUpdated.push({ Field: "Payment Type", Data: { OLD: OrderManagement.PaymentType, New: Request.PaymentType } });
        }
        if (OrderManagement.WarrantyPeriod != Request.WarrantyPeriod) {
            DataChangeLog.DataUpdated.push({ Field: "Warranty Period", Data: { OLD: OrderManagement.WarrantyPeriod, New: Request.WarrantyPeriod } });
        }
        if (OrderManagement.Currency != Request.Currency) {
            DataChangeLog.DataUpdated.push({ Field: "Currency", Data: { OLD: OrderManagement.Currency, New: Request.Currency } });
        }
        if (OrderManagement.Freight != Request.Freight) {
            DataChangeLog.DataUpdated.push({ Field: "Freight", Data: { OLD: OrderManagement.Freight, New: Request.Freight } });
        }
        if (OrderManagement.Discount != Request.Discount) {
            DataChangeLog.DataUpdated.push({ Field: "Discount", Data: { OLD: OrderManagement.Discount, New: Request.Discount } })
        }
        if (OrderManagement.Vat != Request.Vat) {
            DataChangeLog.DataUpdated.push({ Field: "Vat", Data: { OLD: OrderManagement.Vat, New: Request.Vat } });
        }

        if (moment(OrderManagement.RequestPerpDate).format("DD/MM/YYYY") != Request.RequestPerpDate) {
            DataChangeLog.DataUpdated.push({ Field: "RequestPerpDate", Data: { OLD: OrderManagement.RequestPerpDate, New: Request.RequestPerpDate } });
        }
        if (OrderManagement.RequestedBy != Request.RequestedBy) {
            DataChangeLog.DataUpdated.push({ Field: "Requested By", Data: { OLD: PurchaseRequest.RequestedBy, New: textOf("ddEmployeeCode") } });
        }
        if (moment(OrderManagement.RequestDate).format("DD/MM/YYYY") != Request.RequestDate) {
            DataChangeLog.DataUpdated.push({ Field: "RequestDate", Data: { OLD: OrderManagement.RequestDate, New: Request.RequestDate } });
        }
        if (OrderManagement.DepartmentID != Request.DepartmentID) {
            DataChangeLog.DataUpdated.push({ Field: "DepartmentID", Data: { OLD: OrderManagement.DepartmentID, New: Request.DepartmentID } });
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

     

    Post("/PurchaseOrderAPI/AddPurchaseOrderManagmentData", { request: Request, Items: RequestItems, Approvals: Approvals }).done(function (resp) {
        SaveLog(resp);
        if (resp > 0) {

            

                if (Request.ID == 0)
                    swal("New Request added", { icon: "success" });
                else
                    swal("Request updated", { icon: "success" });
                BindOrderManagmentList();
                ResetNav();
            



        }
    })
}
function CalculateTotal() {
    var items = Array.from(document.getElementById('itemsTable').rows).map(row => ({
        qty: parseInt($(row.cells[4]).find(":input").val()),
        unitCost: parseFloat($(row.cells[5]).find(":input").val()),
        amount: parseFloat($(row.cells[6]).find(":input").val())
    }));
    var TotalAmount = items.reduce((s, a) => s + a.amount, 0);
    var Freight = (isNaN(valOf("txtFreight")) || valOf("txtFreight") == "" ? 0 : parseFloat(valOf("txtFreight")))

    var Vat = parseFloat(TotalAmount * 15 / 100).toFixed(2);// (isNaN(valOf("txtVat")) || valOf("txtVat") == "" ? 0 : parseFloat(valOf("txtVat")))
    SetvalOf("txtVat",Vat)
    var Discount = (isNaN(valOf("txtDiscount")) || valOf("txtDiscount") == "" ? 0 : parseFloat(valOf("txtDiscount")))
    TotalAmount += Freight + Vat - Discount;
    SetvalOf("txtTotal", parseFloat(TotalAmount).toFixed(2))    
}
function FindPastSupplierRate() {
    if (valOf("ddSuppliers") == 0) {
        swal("Select Supplier", { icon: "error" });
        return false;
    }
    var itm = Items.find(x => x.ItemNameCode == valOf("txtRequestItemCode"));
    if (itm != null) {

        $.post("/PurchaseOrderAPI/GetSupplierItemRate", {
            ID: valOf("ddSuppliers"), ItemID: itm.ID
        }).done(function (resp) {
            $("#tblSuppierRate").empty();
            $.each(resp, function (i, item) {
                var tr = $('<tr>');
                tr.append($('<td>').text(item.ItemName))
                tr.append($('<td>').text(item.UnitCost))
                tr.append($('<td>').text(moment(item.RequestDate).format("DD/MM/YYYY")))
                $("#tblSuppierRate").append(tr);  
            })
            $("#dlgSuppierRate").modal("show")
        });
    }
}
function AddApproval(DivisionID,ID) {
    if ($("#ApprovalList .supervisor").length == 5) {
        swal("Maximum 5 approval are required.", { icon: "warning" });
        return false;
    }

    var ap = $('<div>').addClass("form-group")
    ap.append($('<label>').text("Approval from"));
    var select = $('<select>').addClass("form-select supervisor");
    $.each(Supervisors, function (i, d) {
        $(select).append($('<option>', {
            text: d.text,
            value: d.DivisionID,
            dataid: d.id,
            approvalid:ID
        }))
    })
    $(select).val(DivisionID == 0 ? -1 : DivisionID)


    $(ap).append($(select));
    $("#ApprovalList").append($(ap));

    $(select).select2({
        tags: "true",
        placeholder: "Select Supervisor",
        allowClear: true,
        width: "100%"
    })

}
/*
document.getElementById('addItem').addEventListener('click', function () {
    const itemName = document.getElementById('itemName').value;
    const code = document.getElementById('code').value;
    const unit = document.getElementById('unit').value;
    const qty = document.getElementById('qty').value;
    const unitCost = document.getElementById('unitCost').value;
    const amount = document.getElementById('amount').value;
    const msds = document.getElementById('msds').checked ? 'Yes' : 'No';

    const table = document.getElementById('itemsTable');
    const row = table.insertRow();
    row.innerHTML = `<td>${itemName}</td>
                             <td>${code}</td>
                             <td>${unit}</td>
                             <td>${qty}</td>
                             <td>${unitCost}</td>
                             <td>${amount}</td>
                             <td>${msds}</td>`;
});

document.getElementById('purchaseOrderForm').addEventListener('submit', function (e) {
    e.preventDefault();

    const formData = {
        date: document.getElementById('date').value,
        iprNo: document.getElementById('iprNo').value,
        poNo: document.getElementById('poNo').value,
        attn: document.getElementById('attn').value,
        requiredDate: document.getElementById('requiredDate').value,
        contractPeriodFrom: document.getElementById('contractPeriodFrom').value,
        contractPeriodTo: document.getElementById('contractPeriodTo').value,
        note: document.getElementById('note').value,
        partyName: document.getElementById('partyName').value,
        items: Array.from(document.getElementById('itemsTable').rows).map(row => ({
            itemName: row.cells[0].innerText,
            code: row.cells[1].innerText,
            unit: row.cells[2].innerText,
            qty: row.cells[3].innerText,
            unitCost: row.cells[4].innerText,
            amount: row.cells[5].innerText,
            msds: row.cells[6].innerText
        })),
        paymentType: document.getElementById('paymentType').value,
        warrantyPeriod: document.getElementById('warrantyPeriod').value,
        deliveryType: document.getElementById('deliveryType').value,
        longTermContract: document.getElementById('longTermContract').checked,
        calibrationNeeded: document.querySelector('input[name="calibrationNeeded"]:checked').value,
        certificationNeeded: document.querySelector('input[name="certificationNeeded"]:checked').value,
        currency: document.getElementById('currency').value,
        freight: document.getElementById('freight').value,
        discount: document.getElementById('discount').value,
        vat: document.getElementById('vat').value,
        total: document.getElementById('total').value,
        showVatOnInvoice: document.getElementById('showVatOnInvoice').checked,
        remarks: document.getElementById('remarks').value,
        preparedBy: document.getElementById('preparedBy').value,
        preparedDate: document.getElementById('preparedDate').value,
        requestedBy: document.getElementById('requestedBy').value,
        requestedDate: document.getElementById('requestedDate').value,
        department: document.getElementById('department').value,
        departmentCode: document.getElementById('departmentCode').value,
        approvalFrom1: document.getElementById('approvalFrom1').value,
        approvalFrom2: document.getElementById('approvalFrom2').value,
        approvalFrom3: document.getElementById('approvalFrom3').value,
        approvalFrom4: document.getElementById('approvalFrom4').value
    };

    fetch('your-api-endpoint-url', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    }).then(response => {
        if (response.ok) {
            alert('Form submitted successfully');
        } else {
            alert('Failed to submit form');
        }
    }).catch(error => {
        alert('An error occurred: ' + error.message);
    });
});
*/