
var Items = [];
var MaterialRequest = { ID: 0 };
var MaterialRequestItems = [];

function _Init() {
    HideSpinner();
    pageNumber = 1
    SetvalOf("txtInquiryPreparedBy", User.Name);
    $("#dvEditMaterialRequest").addClass("d-none");
    $("#dvMaterialRequestList").removeClass("d-none");
    SetPagePermission(PAGES.ProcurementMaterial, function () {
        $.post("/DataList/MaterialRequestType", {}, function (resp) {
            FillList("ddRequestType", resp, "Name", "Value", "Select Type")
            FillList("ddFilterRequestType", resp, "Name", "Value", "Select Type")
            BindUsers();
            BindItemSearch();
            BindMaterialRequestList();
        })


    });
    $("#ddlMaterialDataRange").val(moment().subtract(3, 'month').startOf('month').format("DD/MM/YYYY") + ' - ' + moment().endOf('month').format("DD/MM/YYYY"))


}
function BindUsers() {
    $.post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        if (Response.length > 1) data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name, DivisionID: emp.DivisionID });
        })
        $("#ddEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        })



        BindMaterialRequestList();
    })
    $.post("/EmployeeAPI/Supervisors", {}).done(function (Response) {
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

    $('#ddEmployeeCode').on('select2:select', function (e) {
        var data = e.params.data;
        $("#ddSupervisor").val(data.DivisionID).trigger("change")
    });
    $('#ddEmployeeCode').val(User.ID).trigger("change")

}

function BindMaterialRequestList(PageNumber = 1) {
    pageNumber = PageNumber;
    $("#tblMaterialRequestList").empty();

    var StartDate = "", EndDate = "";
    if (valOf("ddlMaterialDataRange") != "") {
        StartDate = $.trim(valOf("ddlMaterialDataRange").split("-")[0]);
        EndDate = $.trim(valOf("ddlMaterialDataRange").split("-")[1]);
    }

    MaterialRequest = { ID: 0 };
    MaterialRequestItems = [];
    ResetChangeLog(PAGES.ProcurementMaterial);

    $('#dvMaterialRequestPaging').pagination({
        dataSource: "/ProcurementAPI/GetMatrialRequestList",
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
                tr.append($('<td>').append(r.FileName))






                var Icons = $('<div class="icons">');
                $(Icons).append($('<a href="javascript:void(0)" class="writeble" onclick="EditMaterialRequest(' + r.ID + ')"><i class="fa fa-edit"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="deleteble" onclick="DeleteInquiry(' + r.ID + ')"><i class="fa fa-trash"></i></a>'));
                $(Icons).append($('<a href="javascript:void(0)" class="" onclick="PrintInquiry(' + r.ID + ')"><i class="fa fa-print"></i></a>'));
                tr.append($('<td>').append($(Icons)));

                $("#tblMaterialRequestList").append(tr);

            });


        }
    })

}

function EditMaterialRequest(ID) {


    Post("/ProcurementAPI/GetMatrialRequestDetail", { ID: ID }).done(function (resp) {
        $("#dvEditMaterialRequest").removeClass("d-none");
        $("#dvMaterialRequestList").addClass("d-none");


        MaterialRequest = resp.Request;
        MaterialRequestItems = resp.Items;
        $.each(MaterialRequestItems, function (i, itm) {
            var tr = $('<tr>')

            tr.attr("data-id", itm == null ? 0 : itm.ItemID);
            tr.append($('<td>').text($("#tblMaterialRequestItemList tr").length + 1));
            tr.append($('<td>').text(itm.ItemCode));
            tr.append($('<td>').text(itm.ItemName));
            tr.append($('<td>').text(itm.Unit));
            tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm">').val(itm.Quantity)));
            tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(itm.Notes)));
            var a = $('<a>').attr("href", "javascript:void(0)")
            $(a).click(function () {
                $(this).closest('tr').remove()
            })
            $(a).append($('<i class="fa fa-trash text-danger"></i>'))
            tr.append($('<td>').append($(a)));
            $("#tblMaterialRequestItemList").append(tr);

        })



        SetvalOf("txtRequestDate", moment(MaterialRequest.RequestDate).format("DD/MM/YYYY"))
        SetvalOf("txtRequestPreparedby", MaterialRequest.RecordCreatedByName)
        SetvalOf("ddRequestType", MaterialRequest.RequestType);
        SetvalOf("ddEmployeeCode", MaterialRequest.RequestedBy).trigger("change");
        SetvalOf("ddSupervisor", MaterialRequest.ApprovedBy).trigger("change");
        SetvalOf("txtRequestRemarks", MaterialRequest.Remarks)

        $(".breadcrumb-item.active").wrapInner($('<a>').attr("href", "javascript:ResetNav()"));
    });
    ResetDatePicker();

}

function ResetNav() {


    SetvalOf("ddSupervisor", 0).trigger("change");

    SetvalOf("ddEmployeeName", 0).trigger("change");
    SetvalOf("txtRequestDate", moment().format("DD/MM/YYYY"))

    SetvalOf("ddRequestType", 0);

    SetvalOf("txtRequestRemarks", "")
    $("#dvEditMaterialRequest").addClass("d-none")
    $("#dvMaterialRequestList").removeClass("d-none")
    $(".breadcrumb-item.active").find("a").contents().unwrap();
    SetvalOf("txtRequestPreparedby", User.Name);
    $("#tblMaterialRequestItemList").empty();
    ResetDatePicker();

}


function CreateMaterialRequest() {
    ResetNav();
    SetvalOf("txtRequestDate", moment().format("DD/MM/YYYY"))
    $("#dvEditMaterialRequest").removeClass("d-none")
    $("#dvMaterialRequestList").addClass("d-none")
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
        Notes: valOf("txtRequestItemNotes")

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
    tr.attr("data-id", itm == null ? 0 : itm.ID);
    tr.append($('<td>').text($("#tblMaterialRequestItemList tr").length + 1));
    tr.append($('<td>').text(itm == null ? "0" : itm.ItemCode));
    tr.append($('<td>').text(itm == null ? newItem.Name : itm.Name));
    tr.append($('<td>').text(newItem.Unit));
    tr.append($('<td>').append($('<input type="number" min="1" class="form-control form-control-sm">').val(newItem.Quantity)));
    tr.append($('<td>').append($('<input type="text"  class="form-control form-control-sm">').val(newItem.Notes)));
    var a = $('<a>').attr("href", "javascript:void(0)")
    $(a).click(function () {
        $(this).closest('tr').remove()
    })
    $(a).append($('<i class="fa fa-trash text-danger"></i>'))
    tr.append($('<td>').append($(a)));
    $("#tblMaterialRequestItemList").append(tr);

    SetvalOf("txtRequestItemCode", "")
    SetvalOf("txtRequestItemUnit", "")
    SetvalOf("txtRequestItemQuantity", "")
    SetvalOf("txtRequestItemNotes", "")

}
function SaveMaterialRequest() {
    var Request = {
        ID: MaterialRequest.ID,
        RequestDate: valOf("txtRequestDate"),
        RequestType: valOf("ddRequestType"),
        RequestedBy: valOf("ddEmployeeCode"),
        ApprovedBy: valOf("ddSupervisor"),
        Remarks: valOf("txtRequestRemarks")
    }
    var RequestItems = [];
    if (Request.RequestType == 0) {
        swal("Please select request type", { icon: "error" });
        return false;
    }
    if (Request.RequestedBy == 0) {
        swal("Please select requested by", { icon: "error" });
        return false;
    }
    if (Request.ApprovedBy == 0) {
        swal("Please select approval by", { icon: "error" });
        return false;
    }

    $.each($("#tblMaterialRequestItemList tr"), function (i, tr) {
        var Item = {
            ID: $(this).attr("data-id"),
            ItemName: $(this).find("td:eq(2)").text(),
            Unit: $(this).find("td:eq(3)").text(),
            Quantity: $($(this).find("td:eq(4)")[0]).find("input").val(),
            Notes: $($(this).find("td:eq(5)")[0]).find("input").val(),
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

        if (moment(MaterialRequest.RequestDate).format("DD/MM/YYYY") != Request.RequestDate) {
            DataChangeLog.DataUpdated.push({ Field: "RequestDate", Data: { OLD: MaterialRequest.RequestDate, New: Request.RequestDate } });
        }

        if (MaterialRequest.RequestedBy != Request.RequestedBy) {
            DataChangeLog.DataUpdated.push({ Field: "Requested By", Data: { OLD: Inquiry.EmployeeID, New: textOf("ddEmployeeCode") } });
        }

        if (MaterialRequest.RequestType != Request.RequestType) {
            DataChangeLog.DataUpdated.push({ Field: "Request Type", Data: { OLD: MaterialRequest.RequestType, New: textOf("ddRequestType") } });
        }


        $.each(MaterialRequestItems, function (i, itm) {
            if (RequestItems.find(x => x.ID == itm.ID) == null) {
                DataChangeLog.DataUpdated.push({ Field: "Item Removed", Data: { OLD: itm.ItemName , New: ""} });
            }
        });
        $.each(RequestItems, function (i, itm) {
            var oldITem = MaterialRequestItems.find(x => x.ID == itm.ID);
            if (oldITem == null)
                DataChangeLog.DataUpdated.push({ Field: "New Request Item", Data: { OLD: "", New: itm.ItemName } });
            else {
                if (itm.Unit != oldITem.Unit)
                    DataChangeLog.DataUpdated.push({ Field: itm.ItemName + " Unit ", Data: { OLD: oldITem.Unit, New: itm.Unit } });
                if (itm.Quantity != oldITem.Quantity)
                    DataChangeLog.DataUpdated.push({ Field: itm.ItemName + " Quantity ", Data: { OLD: oldITem.Quantity, New: itm.Quantity } });
                if (itm.Notes != oldITem.Notes)
                    DataChangeLog.DataUpdated.push({ Field: itm.ItemName + " Quantity ", Data: { OLD: oldITem.Quantity, New: itm.Quantity } });
            }
        })

    }

    Post("/ProcurementAPI/AddMaterialRequest", { request: Request, Items: RequestItems }).done(function (resp) {
        SaveLog(resp.Data);
        if (resp.Data > 0) {
            if (Request.ID == 0)
                swal("New Request added", { icon: "success" });
            else
                swal("Request updated", { icon: "success" });
            BindMaterialRequestList();
            ResetNav()
        }
    })
}