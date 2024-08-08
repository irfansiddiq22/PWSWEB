var IPO = 0;

function _Init() {
    HideSpinner();
    pageNumber = 1
    SetPagePermission(PAGES.RequestforQuote, function () {
        BindPendingIPO();
        BindSuppliers();
        $("#dvEditRequest").addClass ("d-none");
        $("#DvPendingRFQList").removeClass("d-none");

    })


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

function BindPendingIPO() {
    
    
    $("#tblPendingIPO").empty();
    
    
    ResetChangeLog(PAGES.RequestforQuote);

    $('#dvPendingIPOPaging').pagination({
        dataSource: "/InternalPurchaseAPI/GetPedingRequestList",
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

            $("#tblPendingIPO").empty();
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


                tr.append($('<td>').append(moment(r.ApprovalDate).format("DD/MM/YYYY")))
                tr.append($('<td>').append(r.Remarks))
                tr.append($('<td>').append(r.FileName))

                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="writeble" onclick="ProcessPurchaseRequest(' + r.ID + ')"><i class="fa fa-arrow-circle-right"></i></a>'));
                
                tr.append($('<td>').append($(Icons)));

                $("#tblPendingIPO").append(tr);

            });


        }
    })

}



function ProcessPurchaseRequest(ID) {
    Post("/InternalPurchaseAPI/GetPurchaseRequestDetail", { ID: ID }).done(function (resp) {
        $("#dvEditRequest").removeClass("d-none");
        $("#DvPendingRFQList").addClass("d-none");
        IPO = ID;

       var PurchaseRequest = resp.Request;
       var PurchaseRequestItems = resp.Items;
        $.each(PurchaseRequestItems, function (i, itm) {
            var tr = $('<tr>')

            tr.attr("data-id", itm == null ? 0 : itm.ItemID);
            tr.append($('<td>').text($("#tblPurchaseRequestItems tr").length + 1));
            tr.append($('<td>').text(itm.ItemCode));
            tr.append($('<td>').text(itm.ItemName));
            tr.append($('<td>').text(itm.Unit));
            tr.append($('<td>').append(itm.Quantity));
            tr.append($('<td>').append(itm.PartNumber));
            tr.append($('<td>').append(itm.Notes));
            tr.append($('<td>').append($('<input type="checkbox"  class="">').prop("checked", itm.MSDS)));
            
            $("#tblPurchaseRequestItems").append(tr);

        })

        SetvalOf("txtMaterialRequestID", PurchaseRequest.MaterialRequestID)
        
        SetvalOf("txtRequestQuotationNumber", PurchaseRequest.QuotationNumber);
        
        SetvalOf("txtMaintRequestNumber", PurchaseRequest.MaintRequestNumber);
        /*SetvalOf("ddRequestDeliveryType", PurchaseRequest.DeliveryType)
        SetvalOf("ddRequestPaymentType", PurchaseRequest.PaymentType)
        SetvalOf("ddRequestType", PurchaseRequest.RequestType);*/
        SetvalOf("txtRequestSignDate", moment(PurchaseRequest.RequestSignDate).format("DD/MM/YYYY"))
      //  SetvalOf("txtPreparedBy", PurchaseRequest.RecordCreatedByName)
        //SetvalOf("ddEmployeeCode", PurchaseRequest.RequestedBy).trigger("change");
       // SetvalOf("txtRequestDate", moment(PurchaseRequest.RequestDate).format("DD/MM/YYYY"))
      //  SetvalOf("txtRequestRemarks", PurchaseRequest.Remarks)

        $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    });
    ResetDatePicker();

}
function AddSupplier() {

}
function ResetNav() {

    
    $("#dvEditRequest").addClass("d-none");
    $("#DvPendingRFQList").removeClass("d-none");
    $("#tblSuppliers,#tblPurchaseRequestItems").empty()

    $(".breadcrumb-item.active").find("a").contents().unwrap();
    ResetDatePicker();

}


function CreateMaterialRequest() {
    ResetNav();
    SetvalOf("txtRequestDate", moment().format("DD/MM/YYYY"))
    $("#dvEditMaterialRequest").removeClass("d-none")
    $("#dvMaterialRequestList").addClass("d-none")
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}



function AddSupplier() {
    var Supplier = {
        Name: textOf("ddSuppliers"),
        ID: valOf("ddSuppliers")
        

    }
    if (Supplier.ID == "0") {
        swal("Please select supplier to request for quote")
        return false;
    }

    var ExistingSuppliers = Array.from(document.getElementById('tblSuppliers').rows).map(row => ({
                ID: parseInt( $(row.cells[0]).text())
    }));
    if (ExistingSuppliers.length>0 &&  ExistingSuppliers.find(x=>x.ID==Supplier.ID)) return false;

    var tr = $('<tr>')
    tr.append($('<td>').text(Supplier.ID));

    tr.append($('<td>').text(Supplier.Name));
    var a = $('<a>').attr("href", "javascript:void(0)")
    $(a).click(function () {
        $(this).closest('tr').remove()
    })
    $(a).append($('<i class="fa fa-trash text-danger"></i>'))
    tr.append($('<td>').append($(a)));
    $("#tblSuppliers").append(tr);
}
function Save() {

    var Suppliers = Array.from(document.getElementById('tblSuppliers').rows).map(row => ({
        ID: parseInt($(row.cells[0]).text())
    }));


    var Items = Array.from(document.getElementById('tblPurchaseRequestItems').rows).map(row => ({
        ID: parseInt($(row).attr("data-id")),
        ItemName: $(row.cells[2]).text(),
        Quantity: $(row.cells[4]).text()
    }));

    if (Suppliers.length == 0) {
        swal("please select suppliers to request for quote.", { icon: "error" });
        return false;
    }
    if (Items.length == 0) {
        swal("please select items to request for quote.", { icon: "error" });
        return false;
    }
    var SupplierID = Suppliers.map(x => x.ID);
    Post("/InternalPurchaseAPI/SaveRequestForQuote", { IPO: IPO, Suppliers: SupplierID.join(","), Items: Items }).done(function () {
        swal("Request sent to suppliers for quote", { icon: "success" });
        BindPendingIPO();
        ResetNav();
    })
}