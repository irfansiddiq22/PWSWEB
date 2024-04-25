var ClearanceList = [];
var ApprovalList = [];
var AssetList = [];
var Clearance = { ID: 0, Approvals: [], Assets: [] };
function _Init() {
    HideSpinner();
    SetPagePermission(PAGES.EmployeeClearance, function () {

        SetvalOf("txtPreparedBy", User.Name);
        $("#dvEditClearance").hide();
        $("#dvClearanceList").show();
        BindUsers();
        BindClearance();
    });
    
}
function BindUsers() {
    Post("/EmployeeAPI/CodeName", {}).done(function (Response) {

        var data = []
        data.push({ id: 0, text: 'Select an employee' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.ID + " - " + emp.Name });
        })
        $("#ddEmployeeCode").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width: "100%"
        }).on('select2:select', function (e) {
            BindWarnings();
        });
        $("#ddEmployeeName").select2({
            tags: "true",
            placeholder: "Select an option",
            allowClear: true,
            data: data,
            width:"100%"
        }).on('select2:select', function (e) {
            BindEmployeePositionDivision();
            BindEmployeeAssets();
        });
    })
    Post("/SettingAPI/DivisionList", {}).done(function (Response) {
        FillList("ddEmployeeDivision", Response, "Name", "ID", "Select Division")

    });
    Post("/SettingAPI/PositionList", {}).done(function (Response) {
        FillList("ddEmployeePosition", Response, "Name", "ID", "Select Position")
    });
    Post("/SettingAPI/NationalityList", {}).done(function (Response) {
        FillList("ddEmployeeNationality", Response, "Name", "ID", "Select Nationality")
    });
    Post("/EmployeeAPI/WarningSupervisors", {}).done(function (Response) {
        var data = []
        data.push({ id: 0, text: 'Select Supervisor' });
        $.each(Response, function (i, emp) {
            data.push({ id: emp.ID, text: emp.Name });
        })
        FillList("ddSupervisorApproval1", Response, "Name", "ID", "Select Supervisor")
        FillList("ddSupervisorApproval3", Response, "Name", "ID", "Select Supervisor")
        FillList("ddSupervisorApproval3", Response, "Name", "ID", "Select Supervisor")
        FillList("ddSupervisorApproval4", Response, "Name", "ID", "Select Supervisor")
        FillList("ddSupervisorApproval5", Response, "Name", "ID", "Select Supervisor")
        FillList("ddSupervisorApproval6", Response, "Name", "ID", "Select Supervisor")
        FillList("ddSupervisorApproval7", Response, "Name", "ID", "Select Supervisor")
        FillList("ddSupervisorApproval8", Response, "Name", "ID", "Select Supervisor")

        $(".supervisor").select2({
            placeholder: "Select Supervisor",
            data: data,
            width: "100%"
        })
    });


}

function BindEmployeePositionDivision() {
    var EmployeeID = $("#ddEmployeeName").val();
    Post("/EmployeeAPI/EmployeeData", { EmployeeID: EmployeeID }).done(function (Response) {
        var DivisionID = Response[0].DivisionID;
        var PositionID = Response[0].PositionID;
        $("#NationalityList").val(Response[0].NationalityID)

        $("#ddEmployeeDivision").val(DivisionID)

        $("#ddEmployeePosition").val(PositionID)
    });
}

function BindEmployeeAssets() {
    var EmployeeID = $("#ddEmployeeName").val();
    Post("/EmployeeAPI/AssetList", { EmployeeID: EmployeeID }).done(function (Response) {

        $("#tblClearanceAssets").empty();
        $.each(Response, function (i, a) {
            var tr = $('<tr>')
            tr.append($('<td width="10px">').append($('<input type="checkbox" data-id="' + a.ID + '">').prop("checked", (a.ID > 0))))
            tr.append($('<td>').append(a.Name))
            $("#tblClearanceAssets").append(tr);
        });
    });
}

function BindClearance() {
    $("#tblEmployeeClearanceList").empty();
    Clearance = { ID: 0, Approvals: [], Assets: [] };
    ResetChangeLog(PAGES.EmployeeClearance);
    Post("/EmployeeAPI/EmployeeClearanceList", {
        EmployeeID: valOf("ddEmployeeCode") == null ? 0 : valOf("ddEmployeeCode")
    }).done(function (Response) {
        ClearanceList = Response.Clearance;
        ApprovalList = Response.Approvals;
        AssetList = Response.Assets;


        $.each(ClearanceList, function (i, r) {
            var tr = $('<tr>')
            tr.append($('<td>').text(r.ID))
            tr.append($('<td>').append(r.EmployeeID).append("<br>").append("Name:" + r.EmployeeName).append("<br>Division: " + r.Division).append("<br>Position: " + r.Position))
            tr.append($('<td>').text(r.ContactNumber))
            tr.append($('<td>').text(r.Handover))
            tr.append($('<td>').text(moment(r.LastWorkingDate).format("DD/MM/YYYY")))
            tr.append($('<td>').text(moment(r.ClearanceDate).format("DD/MM/YYYY")))
            tr.append($('<td>').append(r.PreparedBy))
            tr.append($('<td>').append(r.EmployeeName))

            tr.append($('<td>').append(r.Division))
            tr.append($('<td>').append(r.Position))
            tr.append($('<td>').append(r.Nationality))



            var Icons = $('<div class="icons">');
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-primary writeble me-2" onclick="EditClearance(' + i + ')"><i class="fa fa-edit"></i></a>'));
            $(Icons).append($('<a href="javascript:void(0)" class="btn btn-sm btn-danger deleteble" onclick="DeleteClearance(' + i + ')"><i class="fa fa-trash"></i></a>'));
            tr.append($('<td>').append($(Icons)));

            $("#tblEmployeeClearanceList").append(tr);
        });
    })
}
function EditClearance(index) {
    $("#dvEditClearance").show();
    $("#dvClearanceList").hide();

    Clearance = ClearanceList[index];
    var Approvals = ApprovalList.filter(x => x.RecordID === Clearance.ID)
    var Assets = AssetList.filter(x => x.EmployeeID === Clearance.EmployeeID)
    Clearance.Approvals = Approvals;
    Clearance.Assets = Assets;
    SetvalOf("ddEmployeeName", Clearance.EmployeeID).trigger("change");
    SetvalOf("ddEmployeeDivision", Clearance.DivisionID);
    SetvalOf("ddEmployeePosition", Clearance.PositionID);
    SetvalOf("ddEmployeeNationality", Clearance.NationalityID);
    SetvalOf("txtClearanceDate", moment(Clearance.ClearanceDate).format("DD/MM/YYYY"))
    SetvalOf("txtClearanceContact", Clearance.ContactNumber);
    SetvalOf("txtClearancehandover", Clearance.Handover);
    SetvalOf("txtPreparedBy", Clearance.Preparedby);
    SetvalOf("txtClearanceLastWorkingDate", moment(Clearance.LastWorkingDate).format("DD/MM/YYYY"))
    $.each(Approvals, function (i, a) {
        SetvalOf("ddSupervisorApproval" + (i + 1), a.ApprovalBy).trigger("change");
    });
    $("#tblClearanceAssets").empty();
    $.each(Assets, function (i, a) {
        var tr = $('<tr>')
        tr.append($('<td width="10px">').append($('<input type="checkbox" data-id="' + a.AssetID + '">').prop("checked", (a.ID > 0))))
        tr.append($('<td>').append(a.Name))
        $("#tblClearanceAssets").append(tr);
    });
}

function SaveEmployeeClearance() {
    $("#frmClearance").validate({
        errorClass: "text-danger",

        rules: {
            EmployeeCode: "required",
            ClearanceDate: "required",
            ClearanceContact: "required",
            ClearanceHandOver: "required",
            ClearanceLastWorkingDate: "required"
        },
        messages: {
            EmployeeCode: "Please select employee",
            ClearanceDate: "Please enter date",
            ClearanceContact: "Please enter contact number",
            ClearanceHandOver: "Please enter handover",
            ClearanceLastWorkingDate: "Please enter last working date"
        },
        submitHandler: function (form) {
            if (Clearance.ID == 0) {
                DataChangeLog.DataUpdated.push({ Field: "Name", Data: { OLD: "", New: textOf("ddEmployeeName") } });
            } else {
                DataChangeLog.DataUpdated = [];

                if (moment(Clearance.ClearanceDate).format("DD/MM/YYYY") != valOf("txtClearanceDate")) {
                    DataChangeLog.DataUpdated.push({ Field: "ClearanceDate", Data: { OLD: Clearance.ClearanceDate, New: valOf("txtClearanceDate") } });
                }
                if ($.trim(Clearance.ContactNumber) != valOf("txtClearanceContact")) {
                    DataChangeLog.DataUpdated.push({ Field: "ContactNumber", Data: { OLD: Clearance.ContactNumber, New: valOf("txtClearanceContact") } });
                }
                if ($.trim(Clearance.Handover) != valOf("txtClearancehandover")) {
                    DataChangeLog.DataUpdated.push({ Field: "Handover", Data: { OLD: Clearance.Handover, New: valOf("txtClearancehandover") } });
                }
                if (moment(Clearance.LastWorkingDate).format("DD/MM/YYYY") != valOf("txtClearanceLastWorkingDate")) {
                    DataChangeLog.DataUpdated.push({ Field: "LastWorkingDate", Data: { OLD: Clearance.LastWorkingDate, New: valOf("txtClearanceLastWorkingDate") } });
                }

                for (i = 1; i <= 8; i++) {
                    if (i <= Clearance.Approvals.length) {
                        if (Clearance.Approvals[i - 1].ApprovalBy != valOf("ddSupervisorApproval" + (i))) {
                            if (valOf("ddSupervisorApproval" + (i)) == 0)
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Clearance.Approvals[i - 1].Name, New: "-" } });
                            else
                                DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: Clearance.Approvals[i - 1].Name, New: textOf("ddSupervisorApproval" + (i)) } });
                        }
                    } else if (valOf("ddSupervisorApproval" + (i)) > 0) {
                        DataChangeLog.DataUpdated.push({ Field: "Approval" + i, Data: { OLD: "-", New: textOf("ddSupervisorApproval" + (i)) } });
                    }

                }
                $("#tblClearanceAssets tr").each(function (i, r) {
                    var assest = $(this).find("td:eq(0)").find(":checkbox")

                    if ($(assest).prop("checked") != (Clearance.Assets[i].ID > 0)) {
                        DataChangeLog.DataUpdated.push({
                            Field: "Asset" + (i + 1), Data: {
                                OLD: Clearance.Assets[i].Name + ":" + (Clearance.Assets[i].ID > 0 ? "True" : "False"),
                                New: Clearance.Assets[i].Name + ":" + ($(assest).prop("checked") ? "True" : "False")
                            }
                        });
                    }
                })
            }
            NewClearance = {
                ID: Clearance.ID,
                EmployeeID: valOf("ddEmployeeName"),
                ClearanceDate: valOf("txtClearanceDate"),
                ContactNumber: valOf("txtClearanceContact"),
                Handover: valOf("txtClearancehandover"),
                LastWorkingDate: valOf("txtClearanceLastWorkingDate"),
                Preparedby: valOf("txtPreparedBy"),
                Approvals: [],
                Assets: []
            };

            for (i = 1; i <= 8; i++) {
                if (valOf("ddSupervisorApproval" + (i)) > 0) {
                    NewClearance.Approvals.push({ ID: i, ApprovalBy: parseInt(valOf("ddSupervisorApproval" + (i))) });
                }
            }
            $("#tblClearanceAssets tr").each(function (i, r) {
                var assest = $(this).find("td:eq(0)").find(":checkbox")

                if ($(assest).prop("checked")) {
                    NewClearance.Assets.push({ ID: i + 1, AssetID: parseInt($(assest).attr("data-id")) })
                }

            });
            
            Post("/EmployeeAPI/UpdateEmployeeClearance", { clearance: NewClearance }).done(function (ID) {
                if (ID > 0) {
                    if (NewClearance.ID > 0)
                        swal("Employee Clearance record added", { icon: "success" })
                    else
                        swal("Employee Clearance updated added", { icon: "success" })
                    SaveLog(ID);
                    BindClearance()
                    CancelNewClearance();
                }

            })
            return false;
        }
        });



    
}

function CancelNewClearance() {
    document.getElementById("frmClearance").reset();

    Clearance = { ID: 0, Approvals: [], Assets: [] };
    SetvalOf("ddEmployeeName", 0).trigger("change")
    SetvalOf("ddEmployeeDivision", 0);
    SetvalOf("ddEmployeePosition", 0);
    SetvalOf("ddEmployeeNationality", 0);
    SetvalOf("txtClearanceDate", moment().format("DD/MM/YYYY"))
    SetvalOf("txtClearanceContact", "");
    SetvalOf("txtClearancehandover", "");
    SetvalOf("txtPreparedBy", User.Name);
    SetvalOf("txtClearanceLastWorkingDate", moment().format("DD/MM/YYYY"))
    $("#tblClearanceAssets").empty();
    for (i = 1; i <= 8; i++) {
        SetvalOf("ddSupervisorApproval" + (i), 0).trigger("change");
    }

    $("#dvEditClearance").hide();
    $("#dvClearanceList").show();

}

function NewClearance() {
    CancelNewClearance();
    $("#dvEditClearance").show();
    $("#dvClearanceList").hide();



}
