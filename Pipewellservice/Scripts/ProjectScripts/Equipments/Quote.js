var Items = []
var QuoteToEdit = {};
var MaxID = 0;
function _Init() {
    HideSpinner();
    $("#txtRecordCreatedBy").val(User.Name);
    $('.datepicker').val(moment().format("DD/MM/YYYY"));
    BindSparePartRequestSearch();
    SetPagePermission(PAGES.EquipmentQuotation, function () {
        BindLists();
        
        $("#txtQuoteDateFilter").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))
        $("#frmSpartPartItems").validate()

        
        ListQuotes();

    });
}
function BindLists() {

    $.post("/DataList/SupplierList", {}, function (Response) {
        $("#ddSuppliers,#ddSupplierFilter").empty();
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
    ResetChangeLog(PAGES.SparePartItems);
    $("#dvEdit").hide();

    
    var StartDate = "", EndDate = "";
    if (valOf("txtQuoteDateFilter") != "") {
        StartDate = $.trim(valOf("txtQuoteDateFilter").split("-")[0]);
        EndDate = $.trim(valOf("txtQuoteDateFilter").split("-")[1]);
    }
    document.getElementById("quotationForm").reset();
    $("#dvList").show();
    $('#dvPaging').pagination({
        dataSource: "/EquipmentsAPI/EquipmentQuote/List",
        pageSize: pageSize,
        pageNumber: 1,
        showGoInput: true,
        showGoButton: true,
        locator: function (response) {
            
            return 'List';
        },
        totalNumberLocator: function (response) {
            MaxID = response.ID;
            $("#txtQuotationID").val(MaxID);
            return response.List.length == 0 ? 0 : response.List[0].Total;
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

                tr.append($('<td>').append($('<input type="checkbox">').prop("checked", r.Accepted)));

                tr.append($('<td>').append($('<input type="checkbox">').prop("checked", r.Delivered)));
                tr.append($('<td>').append(r.CustomerNotes))
                tr.append($('<td>').append(r.Remarks))
                tr.append($('<td>').append(r.RecordCreatedByName))


                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditQuote(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger me-2 deleteble" onclick="PrintQuote(' + r.ID + ')"><i class="fa fa-print"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteItem(' + i + ')"><i class="fa fa-trash"></i></a>'));
                tr.append($('<td>').append($(Icons)));


                $("#tblList").append(tr);

            });


        }
    })

}

function SaveQuote() {
    ResetChangeLog(PAGES.EquipmentQuotation);
    if ($("#quotationForm").valid()) {

        var Quote = {
            ID: QuoteToEdit.ID,
            SupplierID: valOf("ddSuppliers"),
            PaymentTerm: valOf("txtPaymentTerms"),
            Discount: valOf("txtcustomerDiscount"),
            QuoteDate: valOf("txtQuotationDate"),
            QuoteID: valOf("txtQuotationID"),
            RFQNumber: valOf("txtRfQNumber"),
            Accepted: GetChecked("chkaccepted"),
            Delivered: GetChecked("chkdelivered"),

            Remarks: valOf("txtRemarks"),

            CustomerNotes: valOf("txtcustomerNotes"),
            CreditAllowed: valOf("ddcreditAllowed")
        };
        var QuoteItems = [];
        var valid = true;
        Quote.Items = Array.from(document.getElementById('tblItems').rows).map(row => ({
            SparePartItemID: parseInt($(row).attr("data-id")),
            Description: $(row.cells[2]).find(":input").val(),
            Quantity: parseInt($(row.cells[3]).find(":input").val()),
            UnitPrice: parseFloat($(row.cells[4]).find(":input").val()),
            Availability: $(row.cells[6]).find(":input").val(),
            Notes: $(row.cells[7]).find("textarea").val(),

        }));


        if (Quote.ID == 0) {
            DataChangeLog.DataUpdated.push({ Field: "SupplierID", Data: { OLD: "", New: textOf("SupplierID") } });
            DataChangeLog.DataUpdated.push({ Field: "RFQNumber", Data: { OLD: "", New: textOf("txtRfQNumber") } });
            DataChangeLog.DataUpdated.push({ Field: "QuoteID", Data: { OLD: "", New: textOf("txtQuotationID") } });
        }
        else {
            DataChangeLog.DataUpdated = [];
            /*
            if (QuoteToEdit.PartNumber != SparePartItem.PartNumber) {
                DataChangeLog.DataUpdated.push({ Field: "Part Number", Data: { OLD: QuoteToEdit.PartNumber, New: SparePartItem.PartNumber } });
            }

            if (QuoteToEdit.PartName != SparePartItem.PartName) {
                DataChangeLog.DataUpdated.push({ Field: "Part Name", Data: { OLD: QuoteToEdit.PartName, New: SparePartItem.PartName } });
            }

            if (QuoteToEdit.Application != SparePartItem.Application) {
                DataChangeLog.DataUpdated.push({ Field: "Application", Data: { OLD: QuoteToEdit.Application, New: SparePartItem.Application } });
            }

            if (QuoteToEdit.Alternatives != SparePartItem.Alternatives) {
                DataChangeLog.DataUpdated.push({ Field: "Alternatives", Data: { OLD: QuoteToEdit.Alternatives, New: SparePartItem.Alternatives } });
            }

            if (QuoteToEdit.PurchasePrice != SparePartItem.PurchasePrice) {
                DataChangeLog.DataUpdated.push({ Field: "PurchasePrice", Data: { OLD: QuoteToEdit.PurchasePrice, New: SparePartItem.PurchasePrice } });
            }
            if (QuoteToEdit.SalesPrice != SparePartItem.SalesPrice) {
                DataChangeLog.DataUpdated.push({ Field: "SalesPrice", Data: { OLD: QuoteToEdit.SalesPrice, New: SparePartItem.SalesPrice } });
            }
            if (QuoteToEdit.ReOrderLimit != SparePartItem.ReOrderLimit) {
                DataChangeLog.DataUpdated.push({ Field: "ReOrderLimit", Data: { OLD: QuoteToEdit.ReOrderLimit, New: SparePartItem.ReOrderLimit } });
            }
            if (QuoteToEdit.Notes != SparePartItem.Notes) {
                DataChangeLog.DataUpdated.push({ Field: "Notes", Data: { OLD: QuoteToEdit.Notes, New: SparePartItem.Notes } });
            }   

            if (QuoteToEdit.InventoryPart != SparePartItem.InventoryPart) {
                DataChangeLog.DataUpdated.push({ Field: "InventoryPart", Data: { OLD: QuoteToEdit.InventoryPart, New: SparePartItem.InventoryPart } });
            }
            if (QuoteToEdit.PartGroup != SparePartItem.PartGroup) {
                DataChangeLog.DataUpdated.push({ Field: "PartGroup", Data: { OLD: QuoteToEdit.PartGroup, New: SparePartItem.PartGroup } });
            }
            if (QuoteToEdit.Notes != SparePartItem.Location) {
                DataChangeLog.DataUpdated.push({ Field: "Location", Data: { OLD: QuoteToEdit.Location, New: SparePartItem.Location } });
            }
            */

        }



        Post("/EquipmentsAPI/EquipmentQuote/SaveQuote", { quote: Quote }).done(function (resp) {
            if (resp.ID > 0) {
                document.getElementById("quotationForm").reset();
                SaveLog(resp.ID);
                $("#tblItems").empty();
                swal("quote saved successfully", { icon: "success" });
                NewQuote();
                ListQuotes();
            } else {
                swal("failed to save quote ", { icon: "error" });
            }
        })
        return false;
    }
}

function EditQuote(ID) {
    NewQuote();
    Post("/EquipmentsAPI/EquipmentQuote/Detail", { ID: ID }).done(function (resp) {
        QuoteToEdit = resp;


        SetvalOf("ddSuppliers", QuoteToEdit.SupplierID).trigger("change");
        SetvalOf("txtPaymentTerms", QuoteToEdit.PaymentTerm);
        SetvalOf("txtcustomerDiscount", QuoteToEdit.Discount);
        SetvalOf("txtQuotationDate", moment(QuoteToEdit.QuoteDate).format("DD/MM/YYYY"));
        SetvalOf("txtQuotationID", QuoteToEdit.QuoteID);
        SetvalOf("txtRfQNumber", QuoteToEdit.RFQNumber);
        SetChecked("chkaccepted", QuoteToEdit.Accepted);
        SetChecked("chkdelivered", QuoteToEdit.Delivered);

        SetvalOf("txtRemarks", QuoteToEdit.Remarks);

        SetvalOf("txtcustomerNotes", QuoteToEdit.CustomerNotes);
        SetvalOf("ddcreditAllowed", QuoteToEdit.CreditAllowed.toString());
        SetvalOf("txtRecordCreatedBy", QuoteToEdit.RecordCreatedByName);
        $("#tblItems").empty();
        $.each(resp.Items, function (i, itm) {
            var tr = $('<tr>')


            var tr = $('<tr>')

            tr.attr("data-id", itm == null ? 0 : itm.ID);


            tr.append($('<td>').text(itm.PartNumber));
            tr.append($('<td>').text(itm.PartName));
            tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.Description)));
            tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,1)" onblur="CalculateTotal(this,1)" class="form-control form-control-sm">').val(itm.Quantity)));
            tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,2)" onblur="CalculateTotal(this,2)"  class="form-control form-control-sm">').val(itm.UnitPrice)));
            tr.append($('<td>').append($('<input type="number" readonly  class="form-control form-control-sm total">').val(itm.Quantity * itm.UnitPrice)));

            tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(itm.Availability)));
            tr.append($('<td>').append($('<textarea rows="4"  class="form-control form-control-sm">').val(itm.Notes)));

            var a = $('<a>').attr("href", "javascript:void(0)")
            $(a).click(function () {
                $(this).closest('tr').remove()
            })
            $(a).append($('<i class="fa fa-trash text-danger"></i>'))
            tr.append($('<td>').append($(a)));
            $("#tblItems").append(tr);

        });

    });
}
function PrintQuote(ID) {
    
    window.open("/Equipments/PrintReport?ID=" + ID, "ReportPreview", "toolbar=no,status=yes,scrollbars=yes;width:850;height:950");

}
function NewQuote() {
    QuoteToEdit = { ID: 0 };
    $("#txtQuotationID").val(MaxID);
    SetvalOf("txtRecordCreatedBy", User.Name);
    $("#dvEdit").show();
    $("#dvList").hide();
    $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
}
function ResetNav() {
    QuoteToEdit = { ID: 0 };
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

}

function AddItem() {
    var itm = Items.find(x => `${x.PartNumber} - ${x.PartName} - ${x.Application} - ${x.Alternatives}` == valOf("txtItemCode"));

    var newItem = {
        PartNumber: itm.PartNumber,
        PartName: itm.PartName,
        UnitPrice: parseFloat(valOf("txtItemUnitPrice")),
        Quantity: parseInt(valOf("txtItemQuantity")),
        Availability: valOf("txtItemPartAvailability"),
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

    tr.attr("data-id", itm == null ? 0 : itm.ID);


    tr.append($('<td>').text(itm.PartNumber));
    tr.append($('<td>').text(itm.PartName));
    tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.Description)));
    tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,1)" onblur="CalculateTotal(this,1)" class="form-control form-control-sm">').val(newItem.Quantity)));
    tr.append($('<td>').append($('<input type="number" onchange="CalculateTotal(this,2)" onblur="CalculateTotal(this,2)"  class="form-control form-control-sm">').val(newItem.UnitPrice)));
    tr.append($('<td>').append($('<input type="number" readonly  class="form-control form-control-sm total">').val(newItem.Quantity * newItem.UnitPrice)));

    tr.append($('<td>').append($('<input type="text "  class="form-control form-control-sm">').val(newItem.Availability)));
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
}